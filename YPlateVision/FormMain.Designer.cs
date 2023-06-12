namespace YPlateVision
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listBoxPictures = new System.Windows.Forms.ListBox();
            this.pictureBoxOnlyPlate = new System.Windows.Forms.PictureBox();
            this.pictureBoxSrc = new System.Windows.Forms.PictureBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.buttonDetectPlate = new System.Windows.Forms.Button();
            this.buttonRecognize = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelConf = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.recognizeFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerPictures = new System.Windows.Forms.SplitContainer();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRecoHTTP = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonRecoAll = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOnlyPlate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSrc)).BeginInit();
            this.contextMenuStripIcon.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPictures)).BeginInit();
            this.splitContainerPictures.Panel1.SuspendLayout();
            this.splitContainerPictures.Panel2.SuspendLayout();
            this.splitContainerPictures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxPictures
            // 
            this.listBoxPictures.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxPictures.FormattingEnabled = true;
            this.listBoxPictures.ItemHeight = 31;
            this.listBoxPictures.Location = new System.Drawing.Point(12, 4);
            this.listBoxPictures.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxPictures.Name = "listBoxPictures";
            this.listBoxPictures.Size = new System.Drawing.Size(287, 190);
            this.listBoxPictures.TabIndex = 4;
            this.listBoxPictures.SelectedIndexChanged += new System.EventHandler(this.ListBoxPictures_SelectedIndexChanged);
            // 
            // pictureBoxOnlyPlate
            // 
            this.pictureBoxOnlyPlate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxOnlyPlate.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxOnlyPlate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxOnlyPlate.Name = "pictureBoxOnlyPlate";
            this.pictureBoxOnlyPlate.Size = new System.Drawing.Size(613, 238);
            this.pictureBoxOnlyPlate.TabIndex = 25;
            this.pictureBoxOnlyPlate.TabStop = false;
            // 
            // pictureBoxSrc
            // 
            this.pictureBoxSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxSrc.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSrc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxSrc.Name = "pictureBoxSrc";
            this.pictureBoxSrc.Size = new System.Drawing.Size(1224, 802);
            this.pictureBoxSrc.TabIndex = 26;
            this.pictureBoxSrc.TabStop = false;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNumber.Location = new System.Drawing.Point(688, 121);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(212, 51);
            this.labelNumber.TabIndex = 27;
            this.labelNumber.Text = "NUMBER";
            // 
            // buttonDetectPlate
            // 
            this.buttonDetectPlate.Location = new System.Drawing.Point(28, 32);
            this.buttonDetectPlate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDetectPlate.Name = "buttonDetectPlate";
            this.buttonDetectPlate.Size = new System.Drawing.Size(208, 58);
            this.buttonDetectPlate.TabIndex = 28;
            this.buttonDetectPlate.Text = "Найти номер";
            this.buttonDetectPlate.UseVisualStyleBackColor = true;
            this.buttonDetectPlate.Click += new System.EventHandler(this.ButtonDetectPlate_Click);
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.Location = new System.Drawing.Point(28, 108);
            this.buttonRecognize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(208, 58);
            this.buttonRecognize.TabIndex = 29;
            this.buttonRecognize.Text = "Распознать";
            this.buttonRecognize.UseVisualStyleBackColor = true;
            this.buttonRecognize.Click += new System.EventHandler(this.ButtonRecognize_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(1312, 69);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(61, 58);
            this.buttonSave.TabIndex = 30;
            this.buttonSave.Text = "S";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStripIcon;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Распознавание номеров";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStripIcon
            // 
            this.contextMenuStripIcon.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStripIcon.Name = "contextMenuStripIcon";
            this.contextMenuStripIcon.Size = new System.Drawing.Size(200, 84);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(199, 40);
            this.showToolStripMenuItem.Text = "Показать";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(199, 40);
            this.exitToolStripMenuItem.Text = "Выйти";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // labelConf
            // 
            this.labelConf.AutoSize = true;
            this.labelConf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelConf.Location = new System.Drawing.Point(1475, 31);
            this.labelConf.Name = "labelConf";
            this.labelConf.Size = new System.Drawing.Size(0, 37);
            this.labelConf.TabIndex = 31;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 271);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(581, 596);
            this.richTextBox1.TabIndex = 32;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(631, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(328, 58);
            this.button1.TabIndex = 33;
            this.button1.Text = "Распознать (новый метод)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.recognizeFolderToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(1845, 44);
            this.menuStripMain.TabIndex = 34;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openDirectoryToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(88, 40);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(309, 40);
            this.openToolStripMenuItem.Text = "Открыть...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // openDirectoryToolStripMenuItem
            // 
            this.openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            this.openDirectoryToolStripMenuItem.Size = new System.Drawing.Size(309, 40);
            this.openDirectoryToolStripMenuItem.Text = "Открыть папку...";
            this.openDirectoryToolStripMenuItem.Click += new System.EventHandler(this.OpenDirectoryToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(309, 40);
            this.exitToolStripMenuItem1.Text = "Выйти";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
            // 
            // recognizeFolderToolStripMenuItem
            // 
            this.recognizeFolderToolStripMenuItem.Enabled = false;
            this.recognizeFolderToolStripMenuItem.Name = "recognizeFolderToolStripMenuItem";
            this.recognizeFolderToolStripMenuItem.Size = new System.Drawing.Size(291, 40);
            this.recognizeFolderToolStripMenuItem.Text = "Распознать всю папку";
            this.recognizeFolderToolStripMenuItem.Click += new System.EventHandler(this.RecognizeFolderToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(154, 40);
            this.settingsToolStripMenuItem.Text = "Настройки";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // splitContainerPictures
            // 
            this.splitContainerPictures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerPictures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerPictures.Location = new System.Drawing.Point(0, 0);
            this.splitContainerPictures.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerPictures.Name = "splitContainerPictures";
            // 
            // splitContainerPictures.Panel1
            // 
            this.splitContainerPictures.Panel1.Controls.Add(this.pictureBoxOnlyPlate);
            this.splitContainerPictures.Panel1.Controls.Add(this.richTextBox1);
            this.splitContainerPictures.Panel1MinSize = 0;
            // 
            // splitContainerPictures.Panel2
            // 
            this.splitContainerPictures.Panel2.Controls.Add(this.pictureBoxSrc);
            this.splitContainerPictures.Size = new System.Drawing.Size(1845, 804);
            this.splitContainerPictures.SplitterDistance = 615;
            this.splitContainerPictures.TabIndex = 35;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 44);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.groupBox1);
            this.splitContainerMain.Panel1.Controls.Add(this.buttonRecoHTTP);
            this.splitContainerMain.Panel1.Controls.Add(this.buttonStop);
            this.splitContainerMain.Panel1.Controls.Add(this.buttonRecoAll);
            this.splitContainerMain.Panel1.Controls.Add(this.button1);
            this.splitContainerMain.Panel1.Controls.Add(this.buttonSave);
            this.splitContainerMain.Panel1.Controls.Add(this.labelNumber);
            this.splitContainerMain.Panel1.Controls.Add(this.listBoxPictures);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerPictures);
            this.splitContainerMain.Size = new System.Drawing.Size(1845, 1006);
            this.splitContainerMain.SplitterDistance = 198;
            this.splitContainerMain.TabIndex = 36;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDetectPlate);
            this.groupBox1.Controls.Add(this.buttonRecognize);
            this.groupBox1.Location = new System.Drawing.Point(308, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(267, 189);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // buttonRecoHTTP
            // 
            this.buttonRecoHTTP.Location = new System.Drawing.Point(987, 28);
            this.buttonRecoHTTP.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRecoHTTP.Name = "buttonRecoHTTP";
            this.buttonRecoHTTP.Size = new System.Drawing.Size(318, 56);
            this.buttonRecoHTTP.TabIndex = 36;
            this.buttonRecoHTTP.Text = "Распознать через HTTP";
            this.buttonRecoHTTP.UseVisualStyleBackColor = true;
            this.buttonRecoHTTP.Click += new System.EventHandler(this.ButtonRecoHTTP_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(1689, 69);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(115, 58);
            this.buttonStop.TabIndex = 35;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Visible = false;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // buttonRecoAll
            // 
            this.buttonRecoAll.Location = new System.Drawing.Point(1395, 69);
            this.buttonRecoAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRecoAll.Name = "buttonRecoAll";
            this.buttonRecoAll.Size = new System.Drawing.Size(275, 58);
            this.buttonRecoAll.TabIndex = 34;
            this.buttonRecoAll.Text = "Распознать всю папку";
            this.buttonRecoAll.UseVisualStyleBackColor = true;
            this.buttonRecoAll.Visible = false;
            this.buttonRecoAll.Click += new System.EventHandler(this.ButtonRecoAll_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1845, 1050);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.labelConf);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "YPlateVision - Распознавание автомобильных номеров V1.3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOnlyPlate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSrc)).EndInit();
            this.contextMenuStripIcon.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitContainerPictures.Panel1.ResumeLayout(false);
            this.splitContainerPictures.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPictures)).EndInit();
            this.splitContainerPictures.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPictures;
        private System.Windows.Forms.PictureBox pictureBoxOnlyPlate;
        private System.Windows.Forms.PictureBox pictureBoxSrc;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Button buttonDetectPlate;
        private System.Windows.Forms.Button buttonRecognize;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripIcon;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label labelConf;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.SplitContainer splitContainerPictures;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonRecoAll;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ToolStripMenuItem recognizeFolderToolStripMenuItem;
        private System.Windows.Forms.Button buttonRecoHTTP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

