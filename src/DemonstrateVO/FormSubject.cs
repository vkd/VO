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
    public partial class FormSubject : Form
    {
        private string _actionType = "";

        public FormSubject(string actionType)
        {
            _actionType = actionType;
            InitializeComponent();
        }

        private void FormSubject_Load(object sender, EventArgs e)
        {
            this.Text = _actionType;
            tbSubscribeSubject.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Subject = tbSubscribeSubject.Text;
        }

        public string Subject
        {
            get;
            private set;
        }

        private void tbSubscribeSubject_KeyDown(object sender, KeyEventArgs e)
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
