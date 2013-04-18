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
            this.lblPublish = new System.Windows.Forms.Label();
            this.tbPublishSubject = new System.Windows.Forms.TextBox();
            this.btnPublish = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.tbPublishMessage = new System.Windows.Forms.TextBox();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.tbSubscribeSubject = new System.Windows.Forms.TextBox();
            this.lblSubscribe = new System.Windows.Forms.Label();
            this.btnUnsubscribe = new System.Windows.Forms.Button();
            this.tbUnsubscribeSubject = new System.Windows.Forms.TextBox();
            this.lblUnsubscribe = new System.Windows.Forms.Label();
            this.btnAddNearAgent = new System.Windows.Forms.Button();
            this.tbAddNearAgent = new System.Windows.Forms.TextBox();
            this.lblAddNearAgent = new System.Windows.Forms.Label();
            this.tbAgent = new System.Windows.Forms.TextBox();
            this.lblAgent = new System.Windows.Forms.Label();
            this.btnSetAgent = new System.Windows.Forms.Button();
            this.lbSubscribed = new System.Windows.Forms.ListBox();
            this.lbNearAgents = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPublish
            // 
            this.lblPublish.AutoSize = true;
            this.lblPublish.Location = new System.Drawing.Point(169, 67);
            this.lblPublish.Name = "lblPublish";
            this.lblPublish.Size = new System.Drawing.Size(44, 13);
            this.lblPublish.TabIndex = 0;
            this.lblPublish.Text = "Publish:";
            // 
            // tbPublishSubject
            // 
            this.tbPublishSubject.Location = new System.Drawing.Point(172, 83);
            this.tbPublishSubject.Name = "tbPublishSubject";
            this.tbPublishSubject.Size = new System.Drawing.Size(120, 20);
            this.tbPublishSubject.TabIndex = 1;
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(231, 135);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(61, 20);
            this.btnPublish.TabIndex = 2;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(12, 12);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(150, 355);
            this.lbLog.TabIndex = 3;
            // 
            // tbPublishMessage
            // 
            this.tbPublishMessage.Location = new System.Drawing.Point(172, 109);
            this.tbPublishMessage.Name = "tbPublishMessage";
            this.tbPublishMessage.Size = new System.Drawing.Size(120, 20);
            this.tbPublishMessage.TabIndex = 4;
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(231, 202);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(61, 20);
            this.btnSubscribe.TabIndex = 7;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // tbSubscribeSubject
            // 
            this.tbSubscribeSubject.Location = new System.Drawing.Point(172, 176);
            this.tbSubscribeSubject.Name = "tbSubscribeSubject";
            this.tbSubscribeSubject.Size = new System.Drawing.Size(120, 20);
            this.tbSubscribeSubject.TabIndex = 6;
            // 
            // lblSubscribe
            // 
            this.lblSubscribe.AutoSize = true;
            this.lblSubscribe.Location = new System.Drawing.Point(169, 160);
            this.lblSubscribe.Name = "lblSubscribe";
            this.lblSubscribe.Size = new System.Drawing.Size(57, 13);
            this.lblSubscribe.TabIndex = 5;
            this.lblSubscribe.Text = "Subscribe:";
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Location = new System.Drawing.Point(231, 276);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(61, 20);
            this.btnUnsubscribe.TabIndex = 10;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.btnUnsubscribe_Click);
            // 
            // tbUnsubscribeSubject
            // 
            this.tbUnsubscribeSubject.Location = new System.Drawing.Point(172, 250);
            this.tbUnsubscribeSubject.Name = "tbUnsubscribeSubject";
            this.tbUnsubscribeSubject.Size = new System.Drawing.Size(120, 20);
            this.tbUnsubscribeSubject.TabIndex = 9;
            // 
            // lblUnsubscribe
            // 
            this.lblUnsubscribe.AutoSize = true;
            this.lblUnsubscribe.Location = new System.Drawing.Point(169, 234);
            this.lblUnsubscribe.Name = "lblUnsubscribe";
            this.lblUnsubscribe.Size = new System.Drawing.Size(69, 13);
            this.lblUnsubscribe.TabIndex = 8;
            this.lblUnsubscribe.Text = "Unsubscribe:";
            // 
            // btnAddNearAgent
            // 
            this.btnAddNearAgent.Location = new System.Drawing.Point(199, 348);
            this.btnAddNearAgent.Name = "btnAddNearAgent";
            this.btnAddNearAgent.Size = new System.Drawing.Size(90, 20);
            this.btnAddNearAgent.TabIndex = 13;
            this.btnAddNearAgent.Text = "Add near agent";
            this.btnAddNearAgent.UseVisualStyleBackColor = true;
            this.btnAddNearAgent.Click += new System.EventHandler(this.btnAddNearAgent_Click);
            // 
            // tbAddNearAgent
            // 
            this.tbAddNearAgent.Location = new System.Drawing.Point(169, 322);
            this.tbAddNearAgent.Name = "tbAddNearAgent";
            this.tbAddNearAgent.Size = new System.Drawing.Size(120, 20);
            this.tbAddNearAgent.TabIndex = 12;
            // 
            // lblAddNearAgent
            // 
            this.lblAddNearAgent.AutoSize = true;
            this.lblAddNearAgent.Location = new System.Drawing.Point(166, 306);
            this.lblAddNearAgent.Name = "lblAddNearAgent";
            this.lblAddNearAgent.Size = new System.Drawing.Size(83, 13);
            this.lblAddNearAgent.TabIndex = 11;
            this.lblAddNearAgent.Text = "Add near agent:";
            // 
            // tbAgent
            // 
            this.tbAgent.Location = new System.Drawing.Point(213, 12);
            this.tbAgent.Name = "tbAgent";
            this.tbAgent.Size = new System.Drawing.Size(79, 20);
            this.tbAgent.TabIndex = 14;
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Location = new System.Drawing.Point(169, 15);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(38, 13);
            this.lblAgent.TabIndex = 15;
            this.lblAgent.Text = "Agent:";
            // 
            // btnSetAgent
            // 
            this.btnSetAgent.Location = new System.Drawing.Point(231, 38);
            this.btnSetAgent.Name = "btnSetAgent";
            this.btnSetAgent.Size = new System.Drawing.Size(61, 20);
            this.btnSetAgent.TabIndex = 16;
            this.btnSetAgent.Text = "Set agent";
            this.btnSetAgent.UseVisualStyleBackColor = true;
            this.btnSetAgent.Click += new System.EventHandler(this.btnSetAgent_Click);
            // 
            // lbSubscribed
            // 
            this.lbSubscribed.FormattingEnabled = true;
            this.lbSubscribed.Location = new System.Drawing.Point(298, 160);
            this.lbSubscribed.Name = "lbSubscribed";
            this.lbSubscribed.Size = new System.Drawing.Size(78, 121);
            this.lbSubscribed.TabIndex = 17;
            // 
            // lbNearAgents
            // 
            this.lbNearAgents.FormattingEnabled = true;
            this.lbNearAgents.Location = new System.Drawing.Point(298, 293);
            this.lbNearAgents.Name = "lbNearAgents";
            this.lbNearAgents.Size = new System.Drawing.Size(78, 82);
            this.lbNearAgents.TabIndex = 18;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(298, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 23);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 378);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lbNearAgents);
            this.Controls.Add(this.lbSubscribed);
            this.Controls.Add(this.btnSetAgent);
            this.Controls.Add(this.lblAgent);
            this.Controls.Add(this.tbAgent);
            this.Controls.Add(this.btnAddNearAgent);
            this.Controls.Add(this.tbAddNearAgent);
            this.Controls.Add(this.lblAddNearAgent);
            this.Controls.Add(this.btnUnsubscribe);
            this.Controls.Add(this.tbUnsubscribeSubject);
            this.Controls.Add(this.lblUnsubscribe);
            this.Controls.Add(this.btnSubscribe);
            this.Controls.Add(this.tbSubscribeSubject);
            this.Controls.Add(this.lblSubscribe);
            this.Controls.Add(this.tbPublishMessage);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.tbPublishSubject);
            this.Controls.Add(this.lblPublish);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPublish;
        private System.Windows.Forms.TextBox tbPublishSubject;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.TextBox tbPublishMessage;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.TextBox tbSubscribeSubject;
        private System.Windows.Forms.Label lblSubscribe;
        private System.Windows.Forms.Button btnUnsubscribe;
        private System.Windows.Forms.TextBox tbUnsubscribeSubject;
        private System.Windows.Forms.Label lblUnsubscribe;
        private System.Windows.Forms.Button btnAddNearAgent;
        private System.Windows.Forms.TextBox tbAddNearAgent;
        private System.Windows.Forms.Label lblAddNearAgent;
        private System.Windows.Forms.TextBox tbAgent;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.Button btnSetAgent;
        private System.Windows.Forms.ListBox lbSubscribed;
        private System.Windows.Forms.ListBox lbNearAgents;
        private System.Windows.Forms.Button btnRefresh;

    }
}

