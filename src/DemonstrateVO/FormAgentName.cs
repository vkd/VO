using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemonstrateVO
{
    public partial class FormAgentName : Form
    {
        public FormAgentName(string title)
        {
            InitializeComponent();

            this.Text = title;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AgentName = tbAgent.Text;
        }

        public string AgentName
        {
            get;
            private set;
        }

        private void FormAgentName_Load(object sender, EventArgs e)
        {
            tbAgent.Focus();
        }

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