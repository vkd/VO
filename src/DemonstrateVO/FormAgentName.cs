using System;
using System.Windows.Forms;

namespace DemonstrateVO
{
    /// <summary>
    /// Class form for input name of agent
    /// </summary>
    public partial class FormAgentName : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">Title of window</param>
        public FormAgentName(string title)
        {
            InitializeComponent();

            this.Text = title;
        }

        /// <summary>
        /// Press OK
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            AgentName = tbAgent.Text;
        }

        /// <summary>
        /// Name of agent
        /// </summary>
        public string AgentName
        {
            get;
            private set;
        }

        /// <summary>
        /// Press CANCEL
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void FormAgentName_Load(object sender, EventArgs e)
        {
            tbAgent.Focus();
        }

        /// <summary>
        /// Press key on tbAgent
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">KeyEventArgs</param>
        private void tbAgent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnOK_Click(sender, new EventArgs());
                DialogResult = DialogResult.OK;
                //Close();
            }
        }
    }
}