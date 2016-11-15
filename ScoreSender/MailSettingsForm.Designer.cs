namespace ScoreSender
{
    partial class MailSettingsForm
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
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.bbCancel = new System.Windows.Forms.Button();
            this.bbOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMailFrom = new System.Windows.Forms.TextBox();
            this.tbSmtpServer = new System.Windows.Forms.TextBox();
            this.tbSmtpPort = new System.Windows.Forms.TextBox();
            this.tbMailUser = new System.Windows.Forms.TextBox();
            this.tbMailPassword = new System.Windows.Forms.TextBox();
            this.lbMessageSubject = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMessageSubject = new System.Windows.Forms.TextBox();
            this.tbMessageBody = new System.Windows.Forms.TextBox();
            this.pnlButtons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.bbOk);
            this.pnlButtons.Controls.Add(this.bbCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 265);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(387, 50);
            this.pnlButtons.TabIndex = 0;
            // 
            // bbCancel
            // 
            this.bbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bbCancel.Location = new System.Drawing.Point(197, 10);
            this.bbCancel.Name = "bbCancel";
            this.bbCancel.Size = new System.Drawing.Size(75, 32);
            this.bbCancel.TabIndex = 0;
            this.bbCancel.Text = "Отмена";
            this.bbCancel.UseVisualStyleBackColor = true;
            // 
            // bbOk
            // 
            this.bbOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bbOk.Location = new System.Drawing.Point(278, 10);
            this.bbOk.Name = "bbOk";
            this.bbOk.Size = new System.Drawing.Size(75, 32);
            this.bbOk.TabIndex = 1;
            this.bbOk.Text = "Ok";
            this.bbOk.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbMessageBody);
            this.groupBox1.Controls.Add(this.tbMessageSubject);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbMessageSubject);
            this.groupBox1.Controls.Add(this.tbMailPassword);
            this.groupBox1.Controls.Add(this.tbMailUser);
            this.groupBox1.Controls.Add(this.tbSmtpPort);
            this.groupBox1.Controls.Add(this.tbSmtpServer);
            this.groupBox1.Controls.Add(this.tbMailFrom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 255);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройка отправки почтовых сообщений";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Адрес отправителя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Сервер SMTP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(10, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Порт";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(10, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Учетная запись";
            // 
            // tbMailFrom
            // 
            this.tbMailFrom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMailFrom.Location = new System.Drawing.Point(140, 29);
            this.tbMailFrom.Name = "tbMailFrom";
            this.tbMailFrom.Size = new System.Drawing.Size(210, 23);
            this.tbMailFrom.TabIndex = 5;
            // 
            // tbSmtpServer
            // 
            this.tbSmtpServer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSmtpServer.Location = new System.Drawing.Point(140, 61);
            this.tbSmtpServer.Name = "tbSmtpServer";
            this.tbSmtpServer.Size = new System.Drawing.Size(210, 23);
            this.tbSmtpServer.TabIndex = 6;
            // 
            // tbSmtpPort
            // 
            this.tbSmtpPort.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSmtpPort.Location = new System.Drawing.Point(140, 90);
            this.tbSmtpPort.Name = "tbSmtpPort";
            this.tbSmtpPort.Size = new System.Drawing.Size(210, 23);
            this.tbSmtpPort.TabIndex = 7;
            // 
            // tbMailUser
            // 
            this.tbMailUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMailUser.Location = new System.Drawing.Point(140, 120);
            this.tbMailUser.Name = "tbMailUser";
            this.tbMailUser.Size = new System.Drawing.Size(210, 23);
            this.tbMailUser.TabIndex = 8;
            // 
            // tbMailPassword
            // 
            this.tbMailPassword.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMailPassword.Location = new System.Drawing.Point(140, 152);
            this.tbMailPassword.Name = "tbMailPassword";
            this.tbMailPassword.PasswordChar = '*';
            this.tbMailPassword.Size = new System.Drawing.Size(210, 23);
            this.tbMailPassword.TabIndex = 9;
            // 
            // lbMessageSubject
            // 
            this.lbMessageSubject.AutoSize = true;
            this.lbMessageSubject.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMessageSubject.Location = new System.Drawing.Point(10, 190);
            this.lbMessageSubject.Name = "lbMessageSubject";
            this.lbMessageSubject.Size = new System.Drawing.Size(108, 16);
            this.lbMessageSubject.TabIndex = 10;
            this.lbMessageSubject.Text = "Тема сообщения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(10, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Текст сообщения";
            // 
            // tbMessageSubject
            // 
            this.tbMessageSubject.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMessageSubject.Location = new System.Drawing.Point(140, 186);
            this.tbMessageSubject.Name = "tbMessageSubject";
            this.tbMessageSubject.Size = new System.Drawing.Size(210, 23);
            this.tbMessageSubject.TabIndex = 12;
            // 
            // tbMessageBody
            // 
            this.tbMessageBody.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMessageBody.Location = new System.Drawing.Point(140, 220);
            this.tbMessageBody.Name = "tbMessageBody";
            this.tbMessageBody.Size = new System.Drawing.Size(210, 23);
            this.tbMessageBody.TabIndex = 13;
            // 
            // MailSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 315);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MailSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки email";
            this.pnlButtons.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button bbOk;
        private System.Windows.Forms.Button bbCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbMailPassword;
        private System.Windows.Forms.TextBox tbMailUser;
        private System.Windows.Forms.TextBox tbSmtpPort;
        private System.Windows.Forms.TextBox tbSmtpServer;
        private System.Windows.Forms.TextBox tbMailFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMessageBody;
        private System.Windows.Forms.TextBox tbMessageSubject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbMessageSubject;
    }
}