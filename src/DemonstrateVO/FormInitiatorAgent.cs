using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VirtualOrganization;

namespace DemonstrateVO
{
    /// <summary>
    /// Class form for initiator agent
    /// </summary>
    public partial class FormInitiatorAgent : Form
    {
        /// <summary>
        /// List of tasks
        /// </summary>
        List<string> _tasks = new List<string>();
        
        /// <summary>
        /// List of tasked agent messages
        /// </summary>
        List<AgentMessage> _taskedAgent = new List<AgentMessage>();

        /// <summary>
        /// Accepted agent name
        /// </summary>
        string _acceptedAgent;

        /// <summary>
        /// Accepted agent task
        /// </summary>
        string _acceptedTask;

        /// <summary>
        /// Agent
        /// </summary>
        InitiatorAgent _agent;

        /// <summary>
        /// Delegate for add string to listBox
        /// </summary>
        /// <param name="text"></param>
        delegate void AddStringToListBox(string text);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="agentName">Name of agent</param>
        /// <param name="workType">Type of work</param>
        public FormInitiatorAgent(string agentName, string workType)
        {
            InitializeComponent();

            lbTasks.Items.Clear();

            this.Text += " - " + agentName + " (" + workType + ")";

            _agent = new InitiatorAgent(agentName);
            _agent.Subscribe(workType);
            _agent.ReceiveMessage += new AgentMessageEventHandler(_agent_ReceiveMessage);
        }

        /// <summary>
        /// Load form
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void FormInitiatorAgent_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Check agent name
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
        /// <param name="e">AgentMessaeEventArgs</param>
        void _agent_ReceiveMessage(AgentMessageEventArgs e)
        {
            WriteMessageToLogList(e.AgentMessage);

            if (e.AgentMessage.Text != null && e.AgentMessage.Text.Length > 8)
            {
                if (e.AgentMessage.Text.Substring(0, "Принято [".Length) == "Принято [")
                {
                    AcceptTask(e.AgentMessage);
                    return;
                }
            }

            if (e.AgentMessage.MessageType == MessageType.Message)
            {
                if (MessageBox.Show(
                        _agent.AgentName + ": " + e.AgentMessage.Text,
                        "Принять заказ?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    InvokeWriteToLog("Принято: " + e.AgentMessage.Text);
                    _acceptedAgent = e.AgentMessage.Owner;
                    _acceptedTask = e.AgentMessage.Subject;

                    CreateAllOrder();
                    //_agent.AcceptMessage(e.AgentMessage.Owner);
                }
            }
        }

        /// <summary>
        /// Create all order for worker agents
        /// </summary>
        private void CreateAllOrder()
        {
            foreach (var t in _tasks)
            {
                _agent.CreateTask(t, t);
            }

            if (CheckCompleteAllTasks())
            {
                _agent.AcceptMessage(_acceptedAgent, _acceptedTask);
            }
        }

        /// <summary>
        /// Receive accept message
        /// </summary>
        /// <param name="agentMessage">Accepted message</param>
        private void AcceptTask(AgentMessage agentMessage)
        {
            int cost = CalcCost(agentMessage.Text);

            int index = _taskedAgent.FindIndex(a => a.Subject == agentMessage.Subject);

            if (index >= 0)
            {
                int oldCost = CalcCost(_taskedAgent[index].Text);
                if (oldCost > cost)
                    _taskedAgent[index] = agentMessage;
            }
            else
            {
                int startIndex = agentMessage.Text.IndexOf('[') + 1;
                int endIndex = agentMessage.Text.IndexOf(']');
                string newTask = agentMessage.Text.Substring(startIndex, endIndex - startIndex);
                AgentMessage msg = agentMessage;
                msg.Subject = newTask;
                _taskedAgent.Add(msg);
            }

            if (CheckCompleteAllTasks())
            {
                _agent.AcceptMessage(_acceptedAgent, _acceptedTask);
            }
        }

        /// <summary>
        /// Check for all tasks completed
        /// </summary>
        /// <returns>All tasks completed</returns>
        private bool CheckCompleteAllTasks()
        {
            foreach (var task in _tasks)
	        {
                if (!_taskedAgent.Exists(a => a.Subject == task))
                    return false;
	        }

            return true;
        }

        /// <summary>
        /// Calculate cost from string
        /// </summary>
        /// <param name="text">Message text</param>
        /// <returns>Cost of work</returns>
        private int CalcCost(string text)
        {
            return Convert.ToInt32(text.Substring(text.IndexOf(':') + 2));
        }

        /// <summary>
        /// Write message to Log list
        /// </summary>
        /// <param name="agentMessage">AgentMessage</param>
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

            InvokeWriteToLog(msg);
        }

        /// <summary>
        /// Invoke when need add string to lbLog where receive message
        /// </summary>
        /// <param name="msg">Added string</param>
        private void InvokeWriteToLog(string msg)
        {
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
        /// Press Add task
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            lbTasks.Items.Add(tbNewTask.Text);
            _tasks.Add(tbNewTask.Text);
            tbNewTask.Text = "";
        }

        /// <summary>
        /// Press Remove task
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            lbTasks.Items.Remove(tbNewTask.Text);
            _tasks.Remove(tbNewTask.Text);
            tbNewTask.Text = "";
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
        /// Press Refresh
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
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
    }
}
