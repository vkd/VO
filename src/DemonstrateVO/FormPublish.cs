﻿using System;
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
            TextMsg = tbPublishMessage.Text;
        }

        public string Subject
        {
            get;
            private set;
        }

        public string TextMsg
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
