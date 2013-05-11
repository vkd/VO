using System;
using System.Windows.Forms;

namespace DemonstrateVO
{
    /// <summary>
    /// Class form for publish a message
    /// </summary>
    public partial class FormPublish : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormPublish()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load form
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void FormPublish_Load(object sender, EventArgs e)
        {
            tbPublishSubject.Focus();
        }

        /// <summary>
        /// Press OK
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Subject = tbPublishSubject.Text;
            TextMsg = tbPublishMessage.Text;
        }

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject
        {
            get;
            private set;
        }

        /// <summary>
        /// Test of message
        /// </summary>
        public string TextMsg
        {
            get;
            private set;
        }

        /// <summary>
        /// Press key on tbPublishSubject
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbPublishSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                tbPublishMessage.Focus();
            }
        }

        /// <summary>
        /// Press key on tbPublishMessage
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbPublishMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnOK_Click(sender, new EventArgs());
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
