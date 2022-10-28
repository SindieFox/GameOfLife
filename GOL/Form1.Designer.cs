
namespace GOL {
    partial class Form1 {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.trackBarTime = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.genomeCheckBox8 = new System.Windows.Forms.CheckBox();
            this.genomeCheckBox7 = new System.Windows.Forms.CheckBox();
            this.genomeCheckBox6 = new System.Windows.Forms.CheckBox();
            this.genomeCheckBox5 = new System.Windows.Forms.CheckBox();
            this.genomeCheckBox4 = new System.Windows.Forms.CheckBox();
            this.genomeCheckBox3 = new System.Windows.Forms.CheckBox();
            this.genomeCheckBox2 = new System.Windows.Forms.CheckBox();
            this.genomeCheckBox1 = new System.Windows.Forms.CheckBox();
            this.genomeCheckBox0 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonRandomFill = new System.Windows.Forms.Button();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 737);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Меню";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.labelTime);
            this.groupBox4.Controls.Add(this.trackBarTime);
            this.groupBox4.Location = new System.Drawing.Point(6, 283);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(164, 243);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Скорость";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(6, 20);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(35, 13);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "label1";
            // 
            // trackBarTime
            // 
            this.trackBarTime.Location = new System.Drawing.Point(6, 39);
            this.trackBarTime.Maximum = 3100;
            this.trackBarTime.Minimum = 100;
            this.trackBarTime.Name = "trackBarTime";
            this.trackBarTime.Size = new System.Drawing.Size(152, 45);
            this.trackBarTime.SmallChange = 50;
            this.trackBarTime.TabIndex = 0;
            this.trackBarTime.TickFrequency = 200;
            this.trackBarTime.Value = 100;
            this.trackBarTime.ValueChanged += new System.EventHandler(this.trackBarTime_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.genomeCheckBox8);
            this.groupBox3.Controls.Add(this.genomeCheckBox7);
            this.groupBox3.Controls.Add(this.genomeCheckBox6);
            this.groupBox3.Controls.Add(this.genomeCheckBox5);
            this.groupBox3.Controls.Add(this.genomeCheckBox4);
            this.groupBox3.Controls.Add(this.genomeCheckBox3);
            this.groupBox3.Controls.Add(this.genomeCheckBox2);
            this.groupBox3.Controls.Add(this.genomeCheckBox1);
            this.groupBox3.Controls.Add(this.genomeCheckBox0);
            this.groupBox3.Location = new System.Drawing.Point(6, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(164, 87);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Геном клетки";
            // 
            // genomeCheckBox8
            // 
            this.genomeCheckBox8.AutoSize = true;
            this.genomeCheckBox8.Location = new System.Drawing.Point(126, 65);
            this.genomeCheckBox8.Name = "genomeCheckBox8";
            this.genomeCheckBox8.Size = new System.Drawing.Size(32, 17);
            this.genomeCheckBox8.TabIndex = 8;
            this.genomeCheckBox8.Text = "8";
            this.genomeCheckBox8.UseVisualStyleBackColor = true;
            this.genomeCheckBox8.CheckedChanged += new System.EventHandler(this.genome_Changed);
            // 
            // genomeCheckBox7
            // 
            this.genomeCheckBox7.AutoSize = true;
            this.genomeCheckBox7.Location = new System.Drawing.Point(126, 42);
            this.genomeCheckBox7.Name = "genomeCheckBox7";
            this.genomeCheckBox7.Size = new System.Drawing.Size(32, 17);
            this.genomeCheckBox7.TabIndex = 7;
            this.genomeCheckBox7.Text = "7";
            this.genomeCheckBox7.UseVisualStyleBackColor = true;
            this.genomeCheckBox7.CheckedChanged += new System.EventHandler(this.genome_Changed);
            // 
            // genomeCheckBox6
            // 
            this.genomeCheckBox6.AutoSize = true;
            this.genomeCheckBox6.Location = new System.Drawing.Point(126, 19);
            this.genomeCheckBox6.Name = "genomeCheckBox6";
            this.genomeCheckBox6.Size = new System.Drawing.Size(32, 17);
            this.genomeCheckBox6.TabIndex = 6;
            this.genomeCheckBox6.Text = "6";
            this.genomeCheckBox6.UseVisualStyleBackColor = true;
            this.genomeCheckBox6.CheckedChanged += new System.EventHandler(this.genome_Changed);
            // 
            // genomeCheckBox5
            // 
            this.genomeCheckBox5.AutoSize = true;
            this.genomeCheckBox5.Location = new System.Drawing.Point(66, 65);
            this.genomeCheckBox5.Name = "genomeCheckBox5";
            this.genomeCheckBox5.Size = new System.Drawing.Size(32, 17);
            this.genomeCheckBox5.TabIndex = 5;
            this.genomeCheckBox5.Text = "5";
            this.genomeCheckBox5.UseVisualStyleBackColor = true;
            this.genomeCheckBox5.CheckedChanged += new System.EventHandler(this.genome_Changed);
            // 
            // genomeCheckBox4
            // 
            this.genomeCheckBox4.AutoSize = true;
            this.genomeCheckBox4.Location = new System.Drawing.Point(66, 42);
            this.genomeCheckBox4.Name = "genomeCheckBox4";
            this.genomeCheckBox4.Size = new System.Drawing.Size(32, 17);
            this.genomeCheckBox4.TabIndex = 4;
            this.genomeCheckBox4.Text = "4";
            this.genomeCheckBox4.UseVisualStyleBackColor = true;
            this.genomeCheckBox4.CheckedChanged += new System.EventHandler(this.genome_Changed);
            // 
            // genomeCheckBox3
            // 
            this.genomeCheckBox3.AutoSize = true;
            this.genomeCheckBox3.Location = new System.Drawing.Point(66, 19);
            this.genomeCheckBox3.Name = "genomeCheckBox3";
            this.genomeCheckBox3.Size = new System.Drawing.Size(32, 17);
            this.genomeCheckBox3.TabIndex = 3;
            this.genomeCheckBox3.Text = "3";
            this.genomeCheckBox3.UseVisualStyleBackColor = true;
            this.genomeCheckBox3.CheckedChanged += new System.EventHandler(this.genome_Changed);
            // 
            // genomeCheckBox2
            // 
            this.genomeCheckBox2.AutoSize = true;
            this.genomeCheckBox2.Location = new System.Drawing.Point(6, 65);
            this.genomeCheckBox2.Name = "genomeCheckBox2";
            this.genomeCheckBox2.Size = new System.Drawing.Size(32, 17);
            this.genomeCheckBox2.TabIndex = 2;
            this.genomeCheckBox2.Text = "2";
            this.genomeCheckBox2.UseVisualStyleBackColor = true;
            this.genomeCheckBox2.CheckedChanged += new System.EventHandler(this.genome_Changed);
            // 
            // genomeCheckBox1
            // 
            this.genomeCheckBox1.AutoSize = true;
            this.genomeCheckBox1.Location = new System.Drawing.Point(6, 42);
            this.genomeCheckBox1.Name = "genomeCheckBox1";
            this.genomeCheckBox1.Size = new System.Drawing.Size(32, 17);
            this.genomeCheckBox1.TabIndex = 1;
            this.genomeCheckBox1.Text = "1";
            this.genomeCheckBox1.UseVisualStyleBackColor = true;
            this.genomeCheckBox1.CheckedChanged += new System.EventHandler(this.genome_Changed);
            // 
            // genomeCheckBox0
            // 
            this.genomeCheckBox0.AutoSize = true;
            this.genomeCheckBox0.Location = new System.Drawing.Point(6, 19);
            this.genomeCheckBox0.Name = "genomeCheckBox0";
            this.genomeCheckBox0.Size = new System.Drawing.Size(32, 17);
            this.genomeCheckBox0.TabIndex = 0;
            this.genomeCheckBox0.Text = "0";
            this.genomeCheckBox0.UseVisualStyleBackColor = true;
            this.genomeCheckBox0.CheckedChanged += new System.EventHandler(this.genome_Changed);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonSave);
            this.groupBox2.Controls.Add(this.buttonLoad);
            this.groupBox2.Controls.Add(this.buttonClear);
            this.groupBox2.Controls.Add(this.buttonRandomFill);
            this.groupBox2.Controls.Add(this.buttonStartStop);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 165);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Управление";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(85, 127);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(73, 30);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.Location = new System.Drawing.Point(6, 127);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(73, 30);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Загрузить";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(6, 91);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(152, 30);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonRandomFill
            // 
            this.buttonRandomFill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRandomFill.Location = new System.Drawing.Point(6, 55);
            this.buttonRandomFill.Name = "buttonRandomFill";
            this.buttonRandomFill.Size = new System.Drawing.Size(152, 30);
            this.buttonRandomFill.TabIndex = 1;
            this.buttonRandomFill.Text = "Заполнить случайно";
            this.buttonRandomFill.UseVisualStyleBackColor = true;
            this.buttonRandomFill.Click += new System.EventHandler(this.buttonRandomFillClick);
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartStop.Location = new System.Drawing.Point(6, 19);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(152, 30);
            this.buttonStartStop.TabIndex = 0;
            this.buttonStartStop.Text = "Старт -стоп";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStopClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(194, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(978, 737);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRandomFill;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.TrackBar trackBarTime;
        private System.Windows.Forms.CheckBox genomeCheckBox8;
        private System.Windows.Forms.CheckBox genomeCheckBox7;
        private System.Windows.Forms.CheckBox genomeCheckBox6;
        private System.Windows.Forms.CheckBox genomeCheckBox5;
        private System.Windows.Forms.CheckBox genomeCheckBox4;
        private System.Windows.Forms.CheckBox genomeCheckBox3;
        private System.Windows.Forms.CheckBox genomeCheckBox2;
        private System.Windows.Forms.CheckBox genomeCheckBox1;
        private System.Windows.Forms.CheckBox genomeCheckBox0;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
    }
}

