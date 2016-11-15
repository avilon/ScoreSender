namespace ScoreSender
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.edQuart = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tbDataFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.pnlWorkArea = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lbInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lbMonitor = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edQuart)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTop.Controls.Add(this.lbMonitor);
            this.pnlTop.Controls.Add(this.edQuart);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.button3);
            this.pnlTop.Controls.Add(this.tbDataFile);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.button2);
            this.pnlTop.Controls.Add(this.button1);
            this.pnlTop.Controls.Add(this.btnRun);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(437, 120);
            this.pnlTop.TabIndex = 0;
            // 
            // edQuart
            // 
            this.edQuart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edQuart.Location = new System.Drawing.Point(391, 73);
            this.edQuart.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.edQuart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edQuart.Name = "edQuart";
            this.edQuart.Size = new System.Drawing.Size(34, 20);
            this.edQuart.TabIndex = 7;
            this.edQuart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edQuart.ValueChanged += new System.EventHandler(this.edQuart_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Квартал";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(305, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbDataFile
            // 
            this.tbDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDataFile.Location = new System.Drawing.Point(15, 73);
            this.tbDataFile.Name = "tbDataFile";
            this.tbDataFile.Size = new System.Drawing.Size(284, 20);
            this.tbDataFile.TabIndex = 4;
            this.tbDataFile.TextChanged += new System.EventHandler(this.tbDataFile_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Файл с показателями";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Настройки";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(350, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 8);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(97, 32);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Разослать";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // pnlWorkArea
            // 
            this.pnlWorkArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWorkArea.Location = new System.Drawing.Point(6, 126);
            this.pnlWorkArea.Name = "pnlWorkArea";
            this.pnlWorkArea.Size = new System.Drawing.Size(425, 186);
            this.pnlWorkArea.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 326);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(437, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lbInfo
            // 
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(118, 17);
            this.lbInfo.Text = "toolStripStatusLabel1";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // lbMonitor
            // 
            this.lbMonitor.AutoSize = true;
            this.lbMonitor.Location = new System.Drawing.Point(20, 100);
            this.lbMonitor.Name = "lbMonitor";
            this.lbMonitor.Size = new System.Drawing.Size(35, 13);
            this.lbMonitor.TabIndex = 8;
            this.lbMonitor.Text = "label3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 348);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pnlWorkArea);
            this.Controls.Add(this.pnlTop);
            this.Name = "MainForm";
            this.Text = "Рассылка плановых показателей";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edQuart)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlWorkArea;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lbInfo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbDataFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.NumericUpDown edQuart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMonitor;

    }
}

