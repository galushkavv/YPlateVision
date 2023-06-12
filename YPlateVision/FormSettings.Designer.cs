namespace YPlateVision
{
    partial class FormSettings
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxMinPlate = new System.Windows.Forms.TextBox();
            this.dataGridViewAngles = new System.Windows.Forms.DataGridView();
            this.file = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.angle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMinSymbol = new System.Windows.Forms.TextBox();
            this.checkBoxAllowClose = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.checkBoxRearrange = new System.Windows.Forms.CheckBox();
            this.checkBoxStartTray = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAngles)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 887);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 57);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBoxMinPlate
            // 
            this.textBoxMinPlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMinPlate.Location = new System.Drawing.Point(790, 125);
            this.textBoxMinPlate.Name = "textBoxMinPlate";
            this.textBoxMinPlate.Size = new System.Drawing.Size(177, 44);
            this.textBoxMinPlate.TabIndex = 1;
            // 
            // dataGridViewAngles
            // 
            this.dataGridViewAngles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAngles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.file,
            this.angle});
            this.dataGridViewAngles.Location = new System.Drawing.Point(255, 558);
            this.dataGridViewAngles.Name = "dataGridViewAngles";
            this.dataGridViewAngles.RowTemplate.Height = 33;
            this.dataGridViewAngles.Size = new System.Drawing.Size(712, 289);
            this.dataGridViewAngles.TabIndex = 2;
            // 
            // file
            // 
            this.file.HeaderText = "Файл";
            this.file.Name = "file";
            this.file.Width = 200;
            // 
            // angle
            // 
            this.angle.HeaderText = "Угол";
            this.angle.Name = "angle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(36, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(675, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Минимальная уверенность для рамки номера:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(107, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(604, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "Минимальная уверенность для символов:";
            // 
            // textBoxMinSymbol
            // 
            this.textBoxMinSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMinSymbol.Location = new System.Drawing.Point(790, 187);
            this.textBoxMinSymbol.Name = "textBoxMinSymbol";
            this.textBoxMinSymbol.Size = new System.Drawing.Size(177, 44);
            this.textBoxMinSymbol.TabIndex = 4;
            // 
            // checkBoxAllowClose
            // 
            this.checkBoxAllowClose.AutoSize = true;
            this.checkBoxAllowClose.Checked = true;
            this.checkBoxAllowClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAllowClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxAllowClose.Location = new System.Drawing.Point(114, 249);
            this.checkBoxAllowClose.Name = "checkBoxAllowClose";
            this.checkBoxAllowClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxAllowClose.Size = new System.Drawing.Size(617, 41);
            this.checkBoxAllowClose.TabIndex = 6;
            this.checkBoxAllowClose.Text = "Сворачивать окно при попытке закрыть";
            this.checkBoxAllowClose.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(35, 498);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(932, 37);
            this.label3.TabIndex = 7;
            this.label3.Text = "Углы поворота изображений для файлов с разными названиями:";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxComment.Location = new System.Drawing.Point(173, 54);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(794, 44);
            this.textBoxComment.TabIndex = 8;
            // 
            // checkBoxRearrange
            // 
            this.checkBoxRearrange.AutoSize = true;
            this.checkBoxRearrange.Checked = true;
            this.checkBoxRearrange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRearrange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxRearrange.Location = new System.Drawing.Point(150, 436);
            this.checkBoxRearrange.Name = "checkBoxRearrange";
            this.checkBoxRearrange.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxRearrange.Size = new System.Drawing.Size(814, 41);
            this.checkBoxRearrange.TabIndex = 9;
            this.checkBoxRearrange.Text = "Ставить буквы в начало квадратного номера прицепа";
            this.checkBoxRearrange.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartTray
            // 
            this.checkBoxStartTray.AutoSize = true;
            this.checkBoxStartTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxStartTray.Location = new System.Drawing.Point(373, 307);
            this.checkBoxStartTray.Name = "checkBoxStartTray";
            this.checkBoxStartTray.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStartTray.Size = new System.Drawing.Size(358, 41);
            this.checkBoxStartTray.TabIndex = 10;
            this.checkBoxStartTray.Text = "Запускать свёрнутым";
            this.checkBoxStartTray.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(334, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 37);
            this.label4.TabIndex = 12;
            this.label4.Text = "Порт для HTTP-сервера:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPort.Location = new System.Drawing.Point(790, 371);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(177, 44);
            this.textBoxPort.TabIndex = 11;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 986);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.checkBoxStartTray);
            this.Controls.Add(this.checkBoxRearrange);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxAllowClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMinSymbol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewAngles);
            this.Controls.Add(this.textBoxMinPlate);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAngles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxMinPlate;
        private System.Windows.Forms.DataGridView dataGridViewAngles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMinSymbol;
        private System.Windows.Forms.CheckBox checkBoxAllowClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn file;
        private System.Windows.Forms.DataGridViewTextBoxColumn angle;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.CheckBox checkBoxRearrange;
        private System.Windows.Forms.CheckBox checkBoxStartTray;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPort;
    }
}