namespace DemonstrateVO
{
    partial class FormStartPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStartPage));
            this.gbAgentType = new System.Windows.Forms.GroupBox();
            this.rbWorkerAgent = new System.Windows.Forms.RadioButton();
            this.rbInitiatorAgent = new System.Windows.Forms.RadioButton();
            this.rbBuyerAgent = new System.Windows.Forms.RadioButton();
            this.gbAgentName = new System.Windows.Forms.GroupBox();
            this.tbAgentName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbWorkType = new System.Windows.Forms.GroupBox();
            this.tbWorkerType = new System.Windows.Forms.TextBox();
            this.gbCostAgent = new System.Windows.Forms.GroupBox();
            this.nudCostAgent = new System.Windows.Forms.NumericUpDown();
            this.gbAgentType.SuspendLayout();
            this.gbAgentName.SuspendLayout();
            this.gbWorkType.SuspendLayout();
            this.gbCostAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCostAgent)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAgentType
            // 
            this.gbAgentType.Controls.Add(this.rbWorkerAgent);
            this.gbAgentType.Controls.Add(this.rbInitiatorAgent);
            this.gbAgentType.Controls.Add(this.rbBuyerAgent);
            this.gbAgentType.Location = new System.Drawing.Point(12, 12);
            this.gbAgentType.Name = "gbAgentType";
            this.gbAgentType.Size = new System.Drawing.Size(167, 158);
            this.gbAgentType.TabIndex = 0;
            this.gbAgentType.TabStop = false;
            this.gbAgentType.Text = "Выберите тип агента";
            // 
            // rbWorkerAgent
            // 
            this.rbWorkerAgent.AutoSize = true;
            this.rbWorkerAgent.Location = new System.Drawing.Point(6, 65);
            this.rbWorkerAgent.Name = "rbWorkerAgent";
            this.rbWorkerAgent.Size = new System.Drawing.Size(67, 17);
            this.rbWorkerAgent.TabIndex = 2;
            this.rbWorkerAgent.Text = "Рабочий";
            this.rbWorkerAgent.UseVisualStyleBackColor = true;
            this.rbWorkerAgent.CheckedChanged += new System.EventHandler(this.rbWorkerAgent_CheckedChanged);
            // 
            // rbInitiatorAgent
            // 
            this.rbInitiatorAgent.AutoSize = true;
            this.rbInitiatorAgent.Location = new System.Drawing.Point(6, 42);
            this.rbInitiatorAgent.Name = "rbInitiatorAgent";
            this.rbInitiatorAgent.Size = new System.Drawing.Size(80, 17);
            this.rbInitiatorAgent.TabIndex = 1;
            this.rbInitiatorAgent.Text = "Инициатор";
            this.rbInitiatorAgent.UseVisualStyleBackColor = true;
            this.rbInitiatorAgent.CheckedChanged += new System.EventHandler(this.rbInitiatorAgent_CheckedChanged);
            // 
            // rbBuyerAgent
            // 
            this.rbBuyerAgent.AutoSize = true;
            this.rbBuyerAgent.Checked = true;
            this.rbBuyerAgent.Location = new System.Drawing.Point(6, 19);
            this.rbBuyerAgent.Name = "rbBuyerAgent";
            this.rbBuyerAgent.Size = new System.Drawing.Size(85, 17);
            this.rbBuyerAgent.TabIndex = 0;
            this.rbBuyerAgent.TabStop = true;
            this.rbBuyerAgent.Text = "Покупатель";
            this.rbBuyerAgent.UseVisualStyleBackColor = true;
            this.rbBuyerAgent.CheckedChanged += new System.EventHandler(this.rbBuyerAgent_CheckedChanged);
            // 
            // gbAgentName
            // 
            this.gbAgentName.Controls.Add(this.tbAgentName);
            this.gbAgentName.Location = new System.Drawing.Point(185, 12);
            this.gbAgentName.Name = "gbAgentName";
            this.gbAgentName.Size = new System.Drawing.Size(270, 50);
            this.gbAgentName.TabIndex = 1;
            this.gbAgentName.TabStop = false;
            this.gbAgentName.Text = "Введите имя агента";
            // 
            // tbAgentName
            // 
            this.tbAgentName.Location = new System.Drawing.Point(6, 18);
            this.tbAgentName.Name = "tbAgentName";
            this.tbAgentName.Size = new System.Drawing.Size(256, 20);
            this.tbAgentName.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(309, 176);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 26);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(385, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 26);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbWorkType
            // 
            this.gbWorkType.Controls.Add(this.tbWorkerType);
            this.gbWorkType.Location = new System.Drawing.Point(185, 68);
            this.gbWorkType.Name = "gbWorkType";
            this.gbWorkType.Size = new System.Drawing.Size(270, 48);
            this.gbWorkType.TabIndex = 22;
            this.gbWorkType.TabStop = false;
            this.gbWorkType.Text = "Введите тип работ агента";
            // 
            // tbWorkerType
            // 
            this.tbWorkerType.Enabled = false;
            this.tbWorkerType.Location = new System.Drawing.Point(6, 19);
            this.tbWorkerType.Name = "tbWorkerType";
            this.tbWorkerType.Size = new System.Drawing.Size(256, 20);
            this.tbWorkerType.TabIndex = 4;
            // 
            // gbCostAgent
            // 
            this.gbCostAgent.Controls.Add(this.nudCostAgent);
            this.gbCostAgent.Location = new System.Drawing.Point(185, 122);
            this.gbCostAgent.Name = "gbCostAgent";
            this.gbCostAgent.Size = new System.Drawing.Size(270, 48);
            this.gbCostAgent.TabIndex = 23;
            this.gbCostAgent.TabStop = false;
            this.gbCostAgent.Text = "Введите стоимость работ";
            // 
            // nudCostAgent
            // 
            this.nudCostAgent.Enabled = false;
            this.nudCostAgent.Location = new System.Drawing.Point(6, 19);
            this.nudCostAgent.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCostAgent.Name = "nudCostAgent";
            this.nudCostAgent.Size = new System.Drawing.Size(120, 20);
            this.nudCostAgent.TabIndex = 5;
            // 
            // FormStartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 208);
            this.Controls.Add(this.gbCostAgent);
            this.Controls.Add(this.gbWorkType);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbAgentName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbAgentType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStartPage";
            this.Text = "Выберите параметры агента";
            this.gbAgentType.ResumeLayout(false);
            this.gbAgentType.PerformLayout();
            this.gbAgentName.ResumeLayout(false);
            this.gbAgentName.PerformLayout();
            this.gbWorkType.ResumeLayout(false);
            this.gbWorkType.PerformLayout();
            this.gbCostAgent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCostAgent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAgentType;
        private System.Windows.Forms.RadioButton rbWorkerAgent;
        private System.Windows.Forms.RadioButton rbInitiatorAgent;
        private System.Windows.Forms.RadioButton rbBuyerAgent;
        private System.Windows.Forms.GroupBox gbAgentName;
        private System.Windows.Forms.TextBox tbAgentName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbWorkType;
        private System.Windows.Forms.TextBox tbWorkerType;
        private System.Windows.Forms.GroupBox gbCostAgent;
        private System.Windows.Forms.NumericUpDown nudCostAgent;
    }
}