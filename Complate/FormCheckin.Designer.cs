namespace Complate
{
    partial class FormCheckin
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
            pbFace = new PictureBox();
            txtName = new TextBox();
            txtTime = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txt_idcard = new TextBox();
            dtg_historycheck = new DataGridView();
            btn_day = new Button();
            btn_7day = new Button();
            btn_month = new Button();
            label3 = new Label();
            lblWarning = new Label();
            ((System.ComponentModel.ISupportInitialize)pbFace).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtg_historycheck).BeginInit();
            SuspendLayout();
            // 
            // pbFace
            // 
            pbFace.Location = new Point(12, 23);
            pbFace.Name = "pbFace";
            pbFace.Size = new Size(197, 200);
            pbFace.TabIndex = 5;
            pbFace.TabStop = false;
            pbFace.Click += pictureBox1_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(285, 52);
            txtName.Name = "txtName";
            txtName.Size = new Size(218, 23);
            txtName.TabIndex = 7;
            // 
            // txtTime
            // 
            txtTime.Location = new Point(285, 86);
            txtTime.Name = "txtTime";
            txtTime.Size = new Size(218, 23);
            txtTime.TabIndex = 8;
            txtTime.TextChanged += textBox3_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(236, 60);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 9;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(232, 19);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 13;
            label2.Text = "Id card";
            // 
            // txt_idcard
            // 
            txt_idcard.Location = new Point(285, 16);
            txt_idcard.Name = "txt_idcard";
            txt_idcard.Size = new Size(218, 23);
            txt_idcard.TabIndex = 12;
            // 
            // dtg_historycheck
            // 
            dtg_historycheck.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_historycheck.Location = new Point(232, 138);
            dtg_historycheck.Name = "dtg_historycheck";
            dtg_historycheck.Size = new Size(618, 264);
            dtg_historycheck.TabIndex = 14;
            dtg_historycheck.CellClick += dtg_historycheck_CellClick;
            dtg_historycheck.CellContentClick += dtg_historycheck_CellContentClick;
            // 
            // btn_day
            // 
            btn_day.Location = new Point(343, 428);
            btn_day.Name = "btn_day";
            btn_day.Size = new Size(75, 23);
            btn_day.TabIndex = 15;
            btn_day.Text = "day";
            btn_day.UseVisualStyleBackColor = true;
            btn_day.Click += btn_day_Click;
            // 
            // btn_7day
            // 
            btn_7day.Location = new Point(520, 428);
            btn_7day.Name = "btn_7day";
            btn_7day.Size = new Size(75, 23);
            btn_7day.TabIndex = 16;
            btn_7day.Text = "7 day";
            btn_7day.UseVisualStyleBackColor = true;
            // 
            // btn_month
            // 
            btn_month.Location = new Point(704, 428);
            btn_month.Name = "btn_month";
            btn_month.Size = new Size(75, 23);
            btn_month.TabIndex = 17;
            btn_month.Text = "month";
            btn_month.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(218, 94);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 18;
            label3.Text = "Time Sub";
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Location = new Point(12, 238);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(30, 15);
            lblWarning.TabIndex = 19;
            lblWarning.Text = "Nob";
            // 
            // FormCheckin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 476);
            Controls.Add(lblWarning);
            Controls.Add(label3);
            Controls.Add(btn_month);
            Controls.Add(btn_7day);
            Controls.Add(btn_day);
            Controls.Add(dtg_historycheck);
            Controls.Add(label2);
            Controls.Add(txt_idcard);
            Controls.Add(label1);
            Controls.Add(txtTime);
            Controls.Add(txtName);
            Controls.Add(pbFace);
            Name = "FormCheckin";
            Text = "FormCheckin";
            Load += FormCheckin_Load;
            ((System.ComponentModel.ISupportInitialize)pbFace).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtg_historycheck).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pbFace;
        private TextBox txtName;
        private TextBox txtTime;
        private Label label1;
        private Label label2;
        private TextBox txt_idcard;
        private DataGridView dtg_historycheck;
        private Button btn_day;
        private Button btn_7day;
        private Button btn_month;
        private Label label3;
        private Label lblWarning;
    }
}