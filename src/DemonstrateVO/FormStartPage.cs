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
    public partial class FormStartPage : Form
    {
        public FormStartPage()
        {
            InitializeComponent();
        }

        private void rbBuyerAgent_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged();
        }

        private void CheckedChanged()
        {
            if (rbBuyerAgent.Checked)
            {
                tbWorkerType.Enabled = false;
                nudCostAgent.Enabled = false;
            }
            else if (rbInitiatorAgent.Checked)
            {
                tbWorkerType.Enabled = true;
                nudCostAgent.Enabled = false;
            }
            else if (rbWorkerAgent.Checked)
            {
                tbWorkerType.Enabled = true;
                nudCostAgent.Enabled = true;
            }
            else
            {
                tbWorkerType.Enabled = false;
                nudCostAgent.Enabled = false;
            }
        }

        private void rbInitiatorAgent_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged();
        }

        private void rbWorkerAgent_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbAgentName.Text == "")
            {
                MessageBox.Show("Не указано имя агента", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form frm = null;

            if (rbBuyerAgent.Checked)
            {
                frm = new FormBuyerAgent(tbAgentName.Text);
            }
            else if (rbInitiatorAgent.Checked)
            {
                frm = new FormInitiatorAgent(tbAgentName.Text, tbWorkerType.Text);
            }
            else if (rbWorkerAgent.Checked)
            {
                frm = new FormWorkerAgent(tbAgentName.Text, tbWorkerType.Text, (int)nudCostAgent.Value);
            }
            else
            {
                
            }

            this.Visible = false;
            if (frm != null)
            {
                //frm.Visible = true;
                frm.ShowDialog();
            }
            this.Close();
        }
    }
}
