namespace Pikabu_BestComment
{
    partial class GUISettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUISettings));
            this.label1 = new System.Windows.Forms.Label();
            this.IntervalTextBox = new System.Windows.Forms.TextBox();
            this.dataLocationLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.deleteDataButton = new System.Windows.Forms.Button();
            this.notificateCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.commentsQuantityTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Период обновления(в минутах):";
            // 
            // IntervalTextBox
            // 
            this.IntervalTextBox.Location = new System.Drawing.Point(257, 10);
            this.IntervalTextBox.Name = "IntervalTextBox";
            this.IntervalTextBox.Size = new System.Drawing.Size(124, 26);
            this.IntervalTextBox.TabIndex = 1;
            // 
            // dataLocationLabel
            // 
            this.dataLocationLabel.AutoSize = true;
            this.dataLocationLabel.Location = new System.Drawing.Point(13, 74);
            this.dataLocationLabel.Name = "dataLocationLabel";
            this.dataLocationLabel.Size = new System.Drawing.Size(644, 18);
            this.dataLocationLabel.TabIndex = 2;
            this.dataLocationLabel.Text = "Программа хранит данные в C:\\Users\\Test\\AppData\\Roaming\\Pikabu - Top Comments";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(591, 252);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 30);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(510, 252);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 30);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "ОК";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // deleteDataButton
            // 
            this.deleteDataButton.Location = new System.Drawing.Point(16, 95);
            this.deleteDataButton.Name = "deleteDataButton";
            this.deleteDataButton.Size = new System.Drawing.Size(159, 27);
            this.deleteDataButton.TabIndex = 5;
            this.deleteDataButton.Text = "Удалить данные.";
            this.deleteDataButton.UseVisualStyleBackColor = true;
            this.deleteDataButton.Click += new System.EventHandler(this.deleteDataButton_Click);
            // 
            // notificateCheckBox
            // 
            this.notificateCheckBox.AutoSize = true;
            this.notificateCheckBox.Checked = true;
            this.notificateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.notificateCheckBox.Location = new System.Drawing.Point(16, 129);
            this.notificateCheckBox.Name = "notificateCheckBox";
            this.notificateCheckBox.Size = new System.Drawing.Size(320, 22);
            this.notificateCheckBox.TabIndex = 6;
            this.notificateCheckBox.Text = "Уведомлять меня о новом комментарии.";
            this.notificateCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Количество комментариев:";
            // 
            // commentsQuantityTextBox
            // 
            this.commentsQuantityTextBox.Location = new System.Drawing.Point(257, 40);
            this.commentsQuantityTextBox.Name = "commentsQuantityTextBox";
            this.commentsQuantityTextBox.Size = new System.Drawing.Size(124, 26);
            this.commentsQuantityTextBox.TabIndex = 8;
            // 
            // GUISettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 294);
            this.Controls.Add(this.commentsQuantityTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.notificateCheckBox);
            this.Controls.Add(this.deleteDataButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.dataLocationLabel);
            this.Controls.Add(this.IntervalTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUISettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.Shown += new System.EventHandler(this.GUISettings_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IntervalTextBox;
        private System.Windows.Forms.Label dataLocationLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button deleteDataButton;
        private System.Windows.Forms.CheckBox notificateCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox commentsQuantityTextBox;
    }
}