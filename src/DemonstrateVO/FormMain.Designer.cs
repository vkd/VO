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
            this.lbLog = new System.Windows.Forms.ListBox();
            this.lbRouting = new System.Windows.Forms.ListBox();
            this.lbNearAgents = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lbSubscribed = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.btnUnsubscribe = new System.Windows.Forms.Button();
            this.btnRemoveAgent = new System.Windows.Forms.Button();
            this.btnAddAgent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbLog
            // 
            this.lbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLog.FormattingEnabled = true;
            this.lbLog.HorizontalScrollbar = true;
            this.lbLog.ItemHeight = 16;
            this.lbLog.Location = new System.Drawing.Point(12, 90);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(393, 180);
            this.lbLog.TabIndex = 3;
            // 
            // lbRouting
            // 
            this.lbRouting.FormattingEnabled = true;
            this.lbRouting.Location = new System.Drawing.Point(515, 12);
            this.lbRouting.Name = "lbRouting";
            this.lbRouting.Size = new System.Drawing.Size(150, 225);
            this.lbRouting.TabIndex = 17;
            // 
            // lbNearAgents
            // 
            this.lbNearAgents.FormattingEnabled = true;
            this.lbNearAgents.Location = new System.Drawing.Point(431, 155);
            this.lbNearAgents.Name = "lbNearAgents";
            this.lbNearAgents.Size = new System.Drawing.Size(78, 82);
            this.lbNearAgents.TabIndex = 18;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(587, 247);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 23);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lbSubscribed
            // 
            this.lbSubscribed.FormattingEnabled = true;
            this.lbSubscribed.Location = new System.Drawing.Point(431, 12);
            this.lbSubscribed.Name = "lbSubscribed";
            this.lbSubscribed.Size = new System.Drawing.Size(78, 134);
            this.lbSubscribed.TabIndex = 20;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(12, 12);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(72, 72);
            this.btnSend.TabIndex = 22;
            this.btnSend.Text = "Отправить сообщение";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(102, 12);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(72, 72);
            this.btnSubscribe.TabIndex = 23;
            this.btnSubscribe.Text = "Подписаться";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Location = new System.Drawing.Point(172, 12);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(72, 72);
            this.btnUnsubscribe.TabIndex = 24;
            this.btnUnsubscribe.Text = "Отписаться";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.btnUnsubscribe_Click);
            // 
            // btnRemoveAgent
            // 
            this.btnRemoveAgent.Location = new System.Drawing.Point(333, 12);
            this.btnRemoveAgent.Name = "btnRemoveAgent";
            this.btnRemoveAgent.Size = new System.Drawing.Size(72, 72);
            this.btnRemoveAgent.TabIndex = 26;
            this.btnRemoveAgent.Text = "Удалить агента";
            this.btnRemoveAgent.UseVisualStyleBackColor = true;
            this.btnRemoveAgent.Click += new System.EventHandler(this.btnRemoveAgent_Click);
            // 
            // btnAddAgent
            // 
            this.btnAddAgent.Location = new System.Drawing.Point(263, 12);
            this.btnAddAgent.Name = "btnAddAgent";
            this.btnAddAgent.Size = new System.Drawing.Size(72, 72);
            this.btnAddAgent.TabIndex = 25;
            this.btnAddAgent.Text = "Добавить агента";
            this.btnAddAgent.UseVisualStyleBackColor = true;
            this.btnAddAgent.Click += new System.EventHandler(this.btnAddAgent_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 281);
            this.Controls.Add(this.btnRemoveAgent);
            this.Controls.Add(this.btnAddAgent);
            this.Controls.Add(this.btnUnsubscribe);
            this.Controls.Add(this.btnSubscribe);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lbSubscribed);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lbNearAgents);
            this.Controls.Add(this.lbRouting);
            this.Controls.Add(this.lbLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "VO";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.ListBox lbRouting;
        private System.Windows.Forms.ListBox lbNearAgents;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListBox lbSubscribed;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.Button btnUnsubscribe;
        private System.Windows.Forms.Button btnRemoveAgent;
        private System.Windows.Forms.Button btnAddAgent;

    }
}

