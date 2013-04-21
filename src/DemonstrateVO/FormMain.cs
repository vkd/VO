using System.Windows.Forms;
using VirtualOrganization;
using System.Collections.Generic;

namespace DemonstrateVO
{
    public partial class FormMain : Form
    {
        Agent _agent;

        delegate void AddStringToListBox(string text);

        public FormMain()
        {
            InitializeComponent();
        }

        void _agent_ReceiveMessage(AgentMessageEventArgs e)
        {
            string msg = "[" + e.AgentMessage.SenderAgent + "]";
            if (e.AgentMessage.MessageType == MessageType.Subscribe)
                msg += " +";
            else if (e.AgentMessage.MessageType == MessageType.Unsubscribe)
                msg += " -";
            else if (e.AgentMessage.MessageType == MessageType.Hello)
                msg += " hello";
            else if (e.AgentMessage.MessageType == MessageType.Bye)
                msg += " bye";
            msg += e.AgentMessage.Subject;
            if (e.AgentMessage.MessageType == MessageType.Message)
            {
                msg += " : ";
                msg += e.AgentMessage.Text;
            }

            //MessageBox.Show(msg);

            if (lbLog.InvokeRequired || lbNearAgents.InvokeRequired 
                || lbRouting.InvokeRequired || lbSubscribed.InvokeRequired)
            {
                AddStringToListBox d = new AddStringToListBox((text) => { InvokeReceiveMessage(text); });
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                InvokeReceiveMessage(msg);
            }
            //lbLog.Items.Add(msg);
            //lbLog.SelectedIndex = lbLog.Items.Count - 1;
        }

        private void InvokeReceiveMessage(string msg)
        {
            lbLog.Items.Add(msg);
            lbLog.SelectedIndex = lbLog.Items.Count - 1;
            lbLog.SelectedIndex = -1;
            RefreshLists();
        }

        private void RefreshLists()
        {
            RefreshRouting();
            RefreshNearAgents();
            RefreshSubscribed();
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

        private void RefreshRouting()
        {
            List<string> list = _agent.GetRoutingList();

            lbRouting.Items.Clear();
            foreach (var line in list)
            {
                lbRouting.Items.Add(line);
            }
        }

        private void RefreshSubscribed()
        {
            List<string> list = _agent.GetSubscribed();

            lbSubscribed.Items.Clear();
            foreach (var line in list)
            {
                lbSubscribed.Items.Add(line);
            }
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            RefreshLists();
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            FormAgentName frmAgentName = new FormAgentName("Введите имя агента");
            frmAgentName.ShowDialog();
            if (frmAgentName.DialogResult != DialogResult.OK)
            {
                this.Close();
            }

            if (!CheckAgentName(frmAgentName.AgentName))
            {
                this.Close();
            }

            this.Text += " - " + frmAgentName.AgentName;

            _agent = new Agent(frmAgentName.AgentName);
            _agent.ReceiveMessage += new AgentMessageEventHandler(_agent_ReceiveMessage);
        }

        private bool CheckAgentName(string agentName)
        {
            if (agentName.Length == 0)
                return false;

            return true;
        }

        private void btnSend_Click(object sender, System.EventArgs e)
        {
            FormPublish frmPublish = new FormPublish();
            frmPublish.ShowDialog();

            if (frmPublish.DialogResult == DialogResult.OK)
            {
                _agent.Publish(frmPublish.Subject, frmPublish.Text);
            }

            RefreshLists();
        }

        private void btnSubscribe_Click(object sender, System.EventArgs e)
        {
            FormSubject frmSubject = new FormSubject(btnSubscribe.Text);
            frmSubject.ShowDialog();

            if (frmSubject.DialogResult == DialogResult.OK)
            {
                _agent.Subscribe(frmSubject.Subject);
            }

            RefreshLists();
        }

        private void btnUnsubscribe_Click(object sender, System.EventArgs e)
        {
            FormSubject frmSubject = new FormSubject(btnUnsubscribe.Text);
            frmSubject.ShowDialog();

            if (frmSubject.DialogResult == DialogResult.OK)
            {
                _agent.Unsubscribe(frmSubject.Subject);
            }

            RefreshLists();
        }

        private void btnAddAgent_Click(object sender, System.EventArgs e)
        {
            FormAgentName frmAgentName = new FormAgentName("Добавить агента");
            frmAgentName.ShowDialog();

            if (frmAgentName.DialogResult == DialogResult.OK)
            {
                _agent.AddNearAgent(frmAgentName.AgentName);
            }

            RefreshLists();
        }

        private void btnRemoveAgent_Click(object sender, System.EventArgs e)
        {
            FormAgentName frmAgentName = new FormAgentName("Удалить агента");
            frmAgentName.ShowDialog();

            if (frmAgentName.DialogResult == DialogResult.OK)
            {
                _agent.RemoveNearAgent(frmAgentName.AgentName);
            }

            RefreshLists();
        }
    }
}
