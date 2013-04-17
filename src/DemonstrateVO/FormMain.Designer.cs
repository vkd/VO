namespace DemonstrateVO
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbAgentName1 = new System.Windows.Forms.TextBox();
            this.btnSend1 = new System.Windows.Forms.Button();
            this.btnReceive2 = new System.Windows.Forms.Button();
            this.tbAgentName2 = new System.Windows.Forms.TextBox();
            this.tbMessage1 = new System.Windows.Forms.TextBox();
            this.tbMessage2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbAgentName1
            // 
            this.tbAgentName1.Location = new System.Drawing.Point(29, 12);
            this.tbAgentName1.Name = "tbAgentName1";
            this.tbAgentName1.Size = new System.Drawing.Size(100, 20);
            this.tbAgentName1.TabIndex = 0;
            this.tbAgentName1.Text = "agent01";
            // 
            // btnSend1
            // 
            this.btnSend1.Location = new System.Drawing.Point(29, 64);
            this.btnSend1.Name = "btnSend1";
            this.btnSend1.Size = new System.Drawing.Size(100, 23);
            this.btnSend1.TabIndex = 1;
            this.btnSend1.Text = "Send";
            this.btnSend1.UseVisualStyleBackColor = true;
            this.btnSend1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReceive2
            // 
            this.btnReceive2.Location = new System.Drawing.Point(162, 64);
            this.btnReceive2.Name = "btnReceive2";
            this.btnReceive2.Size = new System.Drawing.Size(100, 23);
            this.btnReceive2.TabIndex = 3;
            this.btnReceive2.Text = "Receive";
            this.btnReceive2.UseVisualStyleBackColor = true;
            this.btnReceive2.Click += new System.EventHandler(this.btnReceive2_Click);
            // 
            // tbAgentName2
            // 
            this.tbAgentName2.Location = new System.Drawing.Point(162, 12);
            this.tbAgentName2.Name = "tbAgentName2";
            this.tbAgentName2.Size = new System.Drawing.Size(100, 20);
            this.tbAgentName2.TabIndex = 2;
            this.tbAgentName2.Text = "agent01";
            // 
            // tbMessage1
            // 
            this.tbMessage1.Location = new System.Drawing.Point(29, 38);
            this.tbMessage1.Name = "tbMessage1";
            this.tbMessage1.Size = new System.Drawing.Size(100, 20);
            this.tbMessage1.TabIndex = 4;
            // 
            // tbMessage2
            // 
            this.tbMessage2.Location = new System.Drawing.Point(162, 38);
            this.tbMessage2.Name = "tbMessage2";
            this.tbMessage2.Size = new System.Drawing.Size(100, 20);
            this.tbMessage2.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbMessage2);
            this.Controls.Add(this.tbMessage1);
            this.Controls.Add(this.btnReceive2);
            this.Controls.Add(this.tbAgentName2);
            this.Controls.Add(this.btnSend1);
            this.Controls.Add(this.tbAgentName1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAgentName1;
        private System.Windows.Forms.Button btnSend1;
        private System.Windows.Forms.Button btnReceive2;
        private System.Windows.Forms.TextBox tbAgentName2;
        private System.Windows.Forms.TextBox tbMessage1;
        private System.Windows.Forms.TextBox tbMessage2;
    }
}

