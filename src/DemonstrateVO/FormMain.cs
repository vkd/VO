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

        private void btnSetAgent_Click(object sender, System.EventArgs e)
        {
            _agent = new Agent(tbAgent.Text);
            _agent.ReceiveMessage += new AgentMessageEventHandler(_agent_ReceiveMessage);
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
            Refresh();
        }

        private void Refresh()
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

        private void btnPublish_Click(object sender, System.EventArgs e)
        {
            _agent.Publish(tbPublishSubject.Text, tbPublishMessage.Text);
            Refresh();
        }

        private void btnSubscribe_Click(object sender, System.EventArgs e)
        {
            _agent.Subscribe(tbSubscribeSubject.Text);
            Refresh();
        }

        private void btnUnsubscribe_Click(object sender, System.EventArgs e)
        {
            _agent.Unsubscribe(tbUnsubscribeSubject.Text);
            Refresh();
        }

        private void btnAddNearAgent_Click(object sender, System.EventArgs e)
        {
            _agent.AddNearAgent(tbAddNearAgent.Text);
            Refresh();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            Refresh();
        }

        private void btnRemoveNearAgent_Click(object sender, System.EventArgs e)
        {
            _agent.RemoveNearAgent(tbAddNearAgent.Text);
        }
    }
}
