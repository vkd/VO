namespace DemonstrateVO
{
    partial class FormInitiatorAgent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInitiatorAgent));
            this.lbLog = new System.Windows.Forms.ListBox();
            this.lbTasks = new System.Windows.Forms.ListBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.tbNewTask = new System.Windows.Forms.TextBox();
            this.btnRemoveAgent = new System.Windows.Forms.Button();
            this.btnAddAgent = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lbNearAgents = new System.Windows.Forms.ListBox();
            this.gbTasks = new System.Windows.Forms.GroupBox();
            this.lblNewTask = new System.Windows.Forms.Label();
            this.gbNearAgents = new System.Windows.Forms.GroupBox();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.gbTasks.SuspendLayout();
            this.gbNearAgents.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLog
            // 
            this.lbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLog.FormattingEnabled = true;
            this.lbLog.HorizontalScrollbar = true;
            this.lbLog.ItemHeight = 16;
            this.lbLog.Location = new System.Drawing.Point(6, 19);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(434, 180);
            this.lbLog.TabIndex = 4;
            // 
            // lbTasks
            // 
            this.lbTasks.FormattingEnabled = true;
            this.lbTasks.Items.AddRange(new object[] {
            "Tasks"});
            this.lbTasks.Location = new System.Drawing.Point(6, 19);
            this.lbTasks.Name = "lbTasks";
            this.lbTasks.Size = new System.Drawing.Size(100, 134);
            this.lbTasks.TabIndex = 7;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(112, 61);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(77, 23);
            this.btnAddTask.TabIndex = 8;
            this.btnAddTask.Text = "Добавить";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Location = new System.Drawing.Point(195, 61);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(63, 23);
            this.btnRemoveTask.TabIndex = 9;
            this.btnRemoveTask.Text = "Удалить";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // tbNewTask
            // 
            this.tbNewTask.Location = new System.Drawing.Point(112, 35);
            this.tbNewTask.Name = "tbNewTask";
            this.tbNewTask.Size = new System.Drawing.Size(146, 20);
            this.tbNewTask.TabIndex = 10;
            // 
            // btnRemoveAgent
            // 
            this.btnRemoveAgent.Location = new System.Drawing.Point(6, 109);
            this.btnRemoveAgent.Name = "btnRemoveAgent";
            this.btnRemoveAgent.Size = new System.Drawing.Size(80, 46);
            this.btnRemoveAgent.TabIndex = 34;
            this.btnRemoveAgent.Text = "Удалить агента";
            this.btnRemoveAgent.UseVisualStyleBackColor = true;
            this.btnRemoveAgent.Click += new System.EventHandler(this.btnRemoveAgent_Click);
            // 
            // btnAddAgent
            // 
            this.btnAddAgent.Location = new System.Drawing.Point(6, 57);
            this.btnAddAgent.Name = "btnAddAgent";
            this.btnAddAgent.Size = new System.Drawing.Size(80, 46);
            this.btnAddAgent.TabIndex = 33;
            this.btnAddAgent.Text = "Добавить агента";
            this.btnAddAgent.UseVisualStyleBackColor = true;
            this.btnAddAgent.Click += new System.EventHandler(this.btnAddAgent_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 23);
            this.btnRefresh.TabIndex = 32;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lbNearAgents
            // 
            this.lbNearAgents.FormattingEnabled = true;
            this.lbNearAgents.Location = new System.Drawing.Point(92, 19);
            this.lbNearAgents.Name = "lbNearAgents";
            this.lbNearAgents.Size = new System.Drawing.Size(78, 134);
            this.lbNearAgents.TabIndex = 31;
            // 
            // gbTasks
            // 
            this.gbTasks.Controls.Add(this.lblNewTask);
            this.gbTasks.Controls.Add(this.lbTasks);
            this.gbTasks.Controls.Add(this.tbNewTask);
            this.gbTasks.Controls.Add(this.btnRemoveTask);
            this.gbTasks.Controls.Add(this.btnAddTask);
            this.gbTasks.Location = new System.Drawing.Point(12, 12);
            this.gbTasks.Name = "gbTasks";
            this.gbTasks.Size = new System.Drawing.Size(264, 165);
            this.gbTasks.TabIndex = 35;
            this.gbTasks.TabStop = false;
            this.gbTasks.Text = "Список задач";
            // 
            // lblNewTask
            // 
            this.lblNewTask.AutoSize = true;
            this.lblNewTask.Location = new System.Drawing.Point(109, 19);
            this.lblNewTask.Name = "lblNewTask";
            this.lblNewTask.Size = new System.Drawing.Size(138, 13);
            this.lblNewTask.TabIndex = 36;
            this.lblNewTask.Text = "Введите название задачи";
            // 
            // gbNearAgents
            // 
            this.gbNearAgents.Controls.Add(this.btnAddAgent);
            this.gbNearAgents.Controls.Add(this.lbNearAgents);
            this.gbNearAgents.Controls.Add(this.btnRemoveAgent);
            this.gbNearAgents.Controls.Add(this.btnRefresh);
            this.gbNearAgents.Location = new System.Drawing.Point(282, 12);
            this.gbNearAgents.Name = "gbNearAgents";
            this.gbNearAgents.Size = new System.Drawing.Size(175, 166);
            this.gbNearAgents.TabIndex = 36;
            this.gbNearAgents.TabStop = false;
            this.gbNearAgents.Text = "Соседние агенты";
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.lbLog);
            this.gbLog.Location = new System.Drawing.Point(12, 183);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(445, 207);
            this.gbLog.TabIndex = 37;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Лог сообщений";
            // 
            // FormInitiatorAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 397);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.gbNearAgents);
            this.Controls.Add(this.gbTasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInitiatorAgent";
            this.Text = "Инициаторный агент";
            this.Load += new System.EventHandler(this.FormInitiatorAgent_Load);
            this.gbTasks.ResumeLayout(false);
            this.gbTasks.PerformLayout();
            this.gbNearAgents.ResumeLayout(false);
            this.gbLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.ListBox lbTasks;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.TextBox tbNewTask;
        private System.Windows.Forms.Button btnRemoveAgent;
        private System.Windows.Forms.Button btnAddAgent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListBox lbNearAgents;
        private System.Windows.Forms.GroupBox gbTasks;
        private System.Windows.Forms.Label lblNewTask;
        private System.Windows.Forms.GroupBox gbNearAgents;
        private System.Windows.Forms.GroupBox gbLog;
    }
}