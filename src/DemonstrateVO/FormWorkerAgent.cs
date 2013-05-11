using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VirtualOrganization;

namespace DemonstrateVO
{
    public partial class FormWorkerAgent : Form
    {
        WorkerAgent _agent;

        delegate void AddStringToListBox(string text);

        public FormWorkerAgent(string agentName, string workerType, int cost)
        {
            InitializeComponent();

            this.Text += " - " + agentName + " (" + workerType + " = " + cost + ")";

            _agent = new WorkerAgent(agentName, cost);
            _agent.Subscribe(workerType);
            _agent.ReceiveMessage += new AgentMessageEventHandler(_agent_ReceiveMessage);
        }

        private void FormWorkerAgent_Load(object sender, EventArgs e)
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

            if (e.AgentMessage.MessageType == MessageType.Message)
            {
                if (MessageBox.Show(
                        _agent.AgentName + ": " + e.AgentMessage.Text,
                        "Принять задачу?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    InvokeWriteToLog("Принято: " + e.AgentMessage.Text);
                    _agent.AcceptMessage(e.AgentMessage.Owner, e.AgentMessage.Subject);
                }
            }
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
    }
}
