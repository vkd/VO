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
    public partial class FormInitiatorAgent : Form
    {
        List<string> _tasks = new List<string>();
        List<AgentMessage> _taskedAgent = new List<AgentMessage>();

        string _acceptedAgent;
        string _acceptedTask;

        InitiatorAgent _agent;

        delegate void AddStringToListBox(string text);

        public FormInitiatorAgent(string agentName, string workType)
        {
            InitializeComponent();

            lbTasks.Items.Clear();

            this.Text += " - " + agentName + " (" + workType + ")";

            _agent = new InitiatorAgent(agentName);
            _agent.Subscribe(workType);
            _agent.ReceiveMessage += new AgentMessageEventHandler(_agent_ReceiveMessage);
        }

        private void FormInitiatorAgent_Load(object sender, EventArgs e)
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

        private bool CheckCompleteAllTasks()
        {
            foreach (var task in _tasks)
	        {
                if (!_taskedAgent.Exists(a => a.Subject == task))
                    return false;
	        }

            return true;
        }

        private int CalcCost(string text)
        {
            return Convert.ToInt32(text.Substring(text.IndexOf(':') + 2));
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

            InvokeWriteToLog(msg);
        }

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

        private void InvokeReceiveMessage(string msg)
        {
            lbLog.Items.Add(msg);
            lbLog.SelectedIndex = lbLog.Items.Count - 1;
            lbLog.SelectedIndex = -1;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            lbTasks.Items.Add(tbNewTask.Text);
            _tasks.Add(tbNewTask.Text);
            tbNewTask.Text = "";
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            lbTasks.Items.Remove(tbNewTask.Text);
            _tasks.Remove(tbNewTask.Text);
            tbNewTask.Text = "";
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
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
    }
}
