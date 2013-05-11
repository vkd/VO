using System;
using System.Windows.Forms;

namespace DemonstrateVO
{
    /// <summary>
    /// Class form of choise type of agent
    /// </summary>
    public partial class FormStartPage : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormStartPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Change checked to buyer agent
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void rbBuyerAgent_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged();
        }

        /// <summary>
        /// Checked changed
        /// </summary>
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

        /// <summary>
        /// Change checked to initiator agent
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void rbInitiatorAgent_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged();
        }

        /// <summary>
        /// Change checked to worker agent
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void rbWorkerAgent_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged();
        }

        /// <summary>
        /// Press OK
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
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
