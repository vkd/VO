﻿namespace DemonstrateVO
{
    partial class FormBuyerAgent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuyerAgent));
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.btnRemoveAgent = new System.Windows.Forms.Button();
            this.btnAddAgent = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lbNearAgents = new System.Windows.Forms.ListBox();
            this.gbNearAgents = new System.Windows.Forms.GroupBox();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.gbNearAgents.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(12, 12);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(75, 46);
            this.btnCreateOrder.TabIndex = 0;
            this.btnCreateOrder.Text = "Создать заказ";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // lbLog
            // 
            this.lbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLog.FormattingEnabled = true;
            this.lbLog.HorizontalScrollbar = true;
            this.lbLog.ItemHeight = 16;
            this.lbLog.Location = new System.Drawing.Point(6, 19);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(377, 180);
            this.lbLog.TabIndex = 4;
            // 
            // btnRemoveAgent
            // 
            this.btnRemoveAgent.Location = new System.Drawing.Point(6, 107);
            this.btnRemoveAgent.Name = "btnRemoveAgent";
            this.btnRemoveAgent.Size = new System.Drawing.Size(80, 46);
            this.btnRemoveAgent.TabIndex = 30;
            this.btnRemoveAgent.Text = "Удалить агента";
            this.btnRemoveAgent.UseVisualStyleBackColor = true;
            this.btnRemoveAgent.Click += new System.EventHandler(this.btnRemoveAgent_Click);
            // 
            // btnAddAgent
            // 
            this.btnAddAgent.Location = new System.Drawing.Point(6, 55);
            this.btnAddAgent.Name = "btnAddAgent";
            this.btnAddAgent.Size = new System.Drawing.Size(80, 46);
            this.btnAddAgent.TabIndex = 29;
            this.btnAddAgent.Text = "Добавить агента";
            this.btnAddAgent.UseVisualStyleBackColor = true;
            this.btnAddAgent.Click += new System.EventHandler(this.btnAddAgent_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 23);
            this.btnRefresh.TabIndex = 28;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lbNearAgents
            // 
            this.lbNearAgents.FormattingEnabled = true;
            this.lbNearAgents.Location = new System.Drawing.Point(92, 19);
            this.lbNearAgents.Name = "lbNearAgents";
            this.lbNearAgents.Size = new System.Drawing.Size(163, 134);
            this.lbNearAgents.TabIndex = 27;
            // 
            // gbNearAgents
            // 
            this.gbNearAgents.Controls.Add(this.lbNearAgents);
            this.gbNearAgents.Controls.Add(this.btnRemoveAgent);
            this.gbNearAgents.Controls.Add(this.btnRefresh);
            this.gbNearAgents.Controls.Add(this.btnAddAgent);
            this.gbNearAgents.Location = new System.Drawing.Point(140, 12);
            this.gbNearAgents.Name = "gbNearAgents";
            this.gbNearAgents.Size = new System.Drawing.Size(265, 161);
            this.gbNearAgents.TabIndex = 31;
            this.gbNearAgents.TabStop = false;
            this.gbNearAgents.Text = "Соседние агенты";
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.lbLog);
            this.gbLog.Location = new System.Drawing.Point(12, 179);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(393, 205);
            this.gbLog.TabIndex = 32;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Лог сообщений";
            // 
            // FormBuyerAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 391);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.gbNearAgents);
            this.Controls.Add(this.btnCreateOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBuyerAgent";
            this.Text = "Покупательный агент";
            this.Load += new System.EventHandler(this.FormBuyerAgent_Load);
            this.gbNearAgents.ResumeLayout(false);
            this.gbLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button btnRemoveAgent;
        private System.Windows.Forms.Button btnAddAgent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListBox lbNearAgents;
        private System.Windows.Forms.GroupBox gbNearAgents;
        private System.Windows.Forms.GroupBox gbLog;
    }
}