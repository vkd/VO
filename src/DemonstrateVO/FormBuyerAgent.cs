using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VirtualOrganization;

namespace DemonstrateVO
{
    /// <summary>
    /// Class form for buyer agent
    /// </summary>
    public partial class FormBuyerAgent : Form
    {
        /// <summary>
        /// Agent
        /// </summary>
        BuyerAgent _agent;

        /// <summary>
        /// Delegate for add string to listBox
        /// </summary>
        /// <param name="text"></param>
        delegate void AddStringToListBox(string text);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="agentName">Name of agent</param>
        public FormBuyerAgent(string agentName)
        {
            InitializeComponent();

            this.Text += " - " + agentName;

            _agent = new BuyerAgent(agentName);
            _agent.ReceiveMessage += new AgentMessageEventHandler(_agent_ReceiveMessage);
        }

        /// <summary>
        /// Press Create Order
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            FormPublish frmPub = new FormPublish();
            if (frmPub.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _agent.CreateOrder(frmPub.Subject, frmPub.TextMsg);
            }
        }

        /// <summary>
        /// Load form
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void FormBuyerAgent_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Check of agent name
        /// </summary>
        /// <param name="agentName">Name of agent</param>
        /// <returns>Name is correct</returns>
        private bool CheckAgentName(string agentName)
        {
            if (agentName.Length == 0)
                return false;

            return true;
        }

        /// <summary>
        /// Receive message
        /// </summary>
        /// <param name="e">AgentMessageEventArgs</param>
        void _agent_ReceiveMessage(AgentMessageEventArgs e)
        {
            WriteMessageToLogList(e.AgentMessage);
        }

        /// <summary>
        /// Write message to log list
        /// </summary>
        /// <param name="agentMessage">Agent message</param>
        private void WriteMessageToLogList(AgentMessage agentMessage)
        {
            string msg = "[" + agentMessage.SenderAgent + "]";
            if (agentMessage.MessageType == MessageType.Subscribe)
                msg += " +" + agentMessage.Subject;
            else if (agentMessage.MessageType == MessageType.Unsubscribe)
                msg += " -" + agentMessage.Subject;
            else if (agentMessage.MessageType == MessageType.Hello)
                msg += " Установлено соединение с " + agentMessage.SenderAgent;
            else if (agentMessage.MessageType == MessageType.Bye)
                msg += " Закрыто соединение с " + agentMessage.SenderAgent;
            //msg += agentMessage.Subject;
            if (agentMessage.MessageType == MessageType.Message)
            {
                msg += " : ";
                msg += agentMessage.Text;
            }

            if (lbLog.InvokeRequired)
            {
                AddStringToListBox d = new AddStringToListBox((text) => { InvokeReceiveMessage(text); });
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                InvokeReceiveMessage(msg);
            }
        }

        /// <summary>
        /// Invoke when need add string to lbLog where receive message
        /// </summary>
        /// <param name="msg">Added string</param>
        private void InvokeReceiveMessage(string msg)
        {
            lbLog.Items.Add(msg);
            lbLog.SelectedIndex = lbLog.Items.Count - 1;
            lbLog.SelectedIndex = -1;
        }

        /// <summary>
        /// Press Remove agent
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnRemoveAgent_Click(object sender, EventArgs e)
        {
            FormAgentName frmAgentName = new FormAgentName("Удалить агента");
            frmAgentName.ShowDialog();

            if (frmAgentName.DialogResult == DialogResult.OK)
            {
                _agent.RemoveNearAgent(frmAgentName.AgentName);
            }

            RefreshNearAgents();
        }

        /// <summary>
        /// Press Add agent
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnAddAgent_Click(object sender, EventArgs e)
        {
            FormAgentName frmAgentName = new FormAgentName("Добавить агента");
            frmAgentName.ShowDialog();

            if (frmAgentName.DialogResult == DialogResult.OK)
            {
                _agent.AddNearAgent(frmAgentName.AgentName);
            }

            RefreshNearAgents();
        }

        /// <summary>
        /// Refresh near agents
        /// </summary>
        private void RefreshNearAgents()
        {
            List<string> list = _agent.GetNearAgents();

            lbNearAgents.Items.Clear();
            foreach (var line in list)
            {
                lbNearAgents.Items.Add(line);
            }
        }

        /// <summary>
        /// Press Refresh
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshNearAgents();
        }
    }
}
