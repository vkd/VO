using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VirtualOrganization;

namespace DemonstrateVO
{
    public partial class FormBuyerAgent : Form
    {
        BuyerAgent _agent;

        delegate void AddStringToListBox(string text);

        public FormBuyerAgent(string agentName)
        {
            InitializeComponent();

            this.Text += " - " + agentName;

            _agent = new BuyerAgent(agentName);
            _agent.ReceiveMessage += new AgentMessageEventHandler(_agent_ReceiveMessage);
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            FormPublish frmPub = new FormPublish();
            if (frmPub.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _agent.CreateOrder(frmPub.Subject, frmPub.TextMsg);
            }
        }

        private void FormBuyerAgent_Load(object sender, EventArgs e)
        {

        }

        private bool CheckAgentName(string agentName)
        {
            if (agentName.Length == 0)
                return false;

            return true;
        }

        void _agent_ReceiveMessage(AgentMessageEventArgs e)
        {
            WriteMessageToLogList(e.AgentMessage);
        }

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

        private void InvokeReceiveMessage(string msg)
        {
            lbLog.Items.Add(msg);
            lbLog.SelectedIndex = lbLog.Items.Count - 1;
            lbLog.SelectedIndex = -1;
        }

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

        private void RefreshNearAgents()
        {
            List<string> list = _agent.GetNearAgents();

            lbNearAgents.Items.Clear();
            foreach (var line in list)
            {
                lbNearAgents.Items.Add(line);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshNearAgents();
        }
    }
}
