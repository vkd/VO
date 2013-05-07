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
    public partial class FormPublish : Form
    {
        public FormPublish()
        {
            InitializeComponent();
        }

        private void FormPublish_Load(object sender, EventArgs e)
        {
            tbPublishSubject.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Subject = tbPublishSubject.Text;
            Text = tbPublishMessage.Text;
        }

        public string Subject
        {
            get;
            private set;
        }

        public string Text
        {
            get;
            private set;
        }

        private void tbPublishSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                tbPublishMessage.Focus();
            }
        }

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
