namespace Complate
{
    partial class FormUser
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            label2 = new Label();
            txt_Name = new TextBox();
            label3 = new Label();
            label7 = new Label();
            label8 = new Label();
            txt_Telnum = new TextBox();
            cbx_Gender = new ComboBox();
            label12 = new Label();
            txt_Address = new TextBox();
            btn_Del = new Button();
            btn_Edit = new Button();
            pictureBox1 = new PictureBox();
            lb39 = new Label();
            txt_Imurl = new TextBox();
            txt_imgdata = new TextBox();
            label1 = new Label();
            dtp_Birthday = new DateTimePicker();
            panel1 = new Panel();
            btn_excel = new Button();
            label4 = new Label();
            btn_create = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 9);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(525, 388);
            dataGridView1.TabIndex = 0;
            dataGridView1.AllowUserToDeleteRowsChanged += dataGridView1_AllowUserToDeleteRowsChanged;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.Scroll += dataGridView1_Scroll;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(566, 29);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 4;
            label2.Text = "Name";
            // 
            // txt_Name
            // 
            txt_Name.Location = new Point(630, 26);
            txt_Name.Margin = new Padding(3, 2, 3, 2);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(190, 23);
            txt_Name.TabIndex = 5;
            txt_Name.TextChanged += txt_Name_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(566, 62);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 6;
            label3.Text = "Gender";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(566, 142);
            label7.Name = "label7";
            label7.Size = new Size(47, 15);
            label7.TabIndex = 10;
            label7.Text = "Telnum";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(566, 103);
            label8.Name = "label8";
            label8.Size = new Size(51, 15);
            label8.TabIndex = 11;
            label8.Text = "Birthday";
            // 
            // txt_Telnum
            // 
            txt_Telnum.Location = new Point(630, 136);
            txt_Telnum.Margin = new Padding(3, 2, 3, 2);
            txt_Telnum.Name = "txt_Telnum";
            txt_Telnum.Size = new Size(190, 23);
            txt_Telnum.TabIndex = 15;
            txt_Telnum.TextChanged += txt_Telnum_TextChanged;
            // 
            // cbx_Gender
            // 
            cbx_Gender.FormattingEnabled = true;
            cbx_Gender.Location = new Point(630, 62);
            cbx_Gender.Margin = new Padding(3, 2, 3, 2);
            cbx_Gender.Name = "cbx_Gender";
            cbx_Gender.Size = new Size(122, 23);
            cbx_Gender.TabIndex = 17;
            cbx_Gender.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(566, 180);
            label12.Name = "label12";
            label12.Size = new Size(49, 15);
            label12.TabIndex = 22;
            label12.Text = "Address";
            // 
            // txt_Address
            // 
            txt_Address.Location = new Point(630, 177);
            txt_Address.Margin = new Padding(3, 2, 3, 2);
            txt_Address.Name = "txt_Address";
            txt_Address.Size = new Size(190, 23);
            txt_Address.TabIndex = 28;
            // 
            // btn_Del
            // 
            btn_Del.BackColor = SystemColors.Control;
            btn_Del.Location = new Point(297, 414);
            btn_Del.Margin = new Padding(3, 2, 3, 2);
            btn_Del.Name = "btn_Del";
            btn_Del.Size = new Size(88, 29);
            btn_Del.TabIndex = 30;
            btn_Del.Text = "Del";
            btn_Del.UseVisualStyleBackColor = false;
            btn_Del.Click += btn_Del_Click;
            // 
            // btn_Edit
            // 
            btn_Edit.BackColor = SystemColors.Control;
            btn_Edit.Location = new Point(99, 414);
            btn_Edit.Margin = new Padding(3, 2, 3, 2);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new Size(86, 29);
            btn_Edit.TabIndex = 31;
            btn_Edit.Text = "Edit";
            btn_Edit.UseVisualStyleBackColor = false;
            btn_Edit.Click += btn_Edit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(629, 321);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(153, 188);
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lb39
            // 
            lb39.AutoSize = true;
            lb39.Location = new Point(565, 223);
            lb39.Name = "lb39";
            lb39.Size = new Size(42, 15);
            lb39.TabIndex = 34;
            lb39.Text = "imgurl";
            // 
            // txt_Imurl
            // 
            txt_Imurl.Location = new Point(630, 218);
            txt_Imurl.Margin = new Padding(3, 2, 3, 2);
            txt_Imurl.Name = "txt_Imurl";
            txt_Imurl.Size = new Size(190, 23);
            txt_Imurl.TabIndex = 35;
            txt_Imurl.TextChanged += txt_Imurl_TextChanged;
            // 
            // txt_imgdata
            // 
            txt_imgdata.Location = new Point(629, 258);
            txt_imgdata.Margin = new Padding(3, 2, 3, 2);
            txt_imgdata.Name = "txt_imgdata";
            txt_imgdata.Size = new Size(190, 23);
            txt_imgdata.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(564, 263);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 36;
            label1.Text = "imgdata";
            // 
            // dtp_Birthday
            // 
            dtp_Birthday.Location = new Point(629, 103);
            dtp_Birthday.Name = "dtp_Birthday";
            dtp_Birthday.Size = new Size(200, 23);
            dtp_Birthday.TabIndex = 38;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(587, 292);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 237);
            panel1.TabIndex = 39;
            // 
            // btn_excel
            // 
            btn_excel.BackColor = Color.Red;
            btn_excel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_excel.ForeColor = Color.White;
            btn_excel.Location = new Point(322, 447);
            btn_excel.Margin = new Padding(3, 2, 3, 2);
            btn_excel.Name = "btn_excel";
            btn_excel.Size = new Size(140, 46);
            btn_excel.TabIndex = 40;
            btn_excel.Text = "Click here!";
            btn_excel.UseVisualStyleBackColor = false;
            btn_excel.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(1, 457);
            label4.Name = "label4";
            label4.Size = new Size(315, 25);
            label4.TabIndex = 41;
            label4.Text = "Export the user list to an Excel file.";
            // 
            // btn_create
            // 
            btn_create.BackColor = Color.Lime;
            btn_create.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_create.ForeColor = Color.Black;
            btn_create.Location = new Point(947, 11);
            btn_create.Margin = new Padding(3, 2, 3, 2);
            btn_create.Name = "btn_create";
            btn_create.Size = new Size(193, 46);
            btn_create.TabIndex = 42;
            btn_create.Text = "+ Create new";
            btn_create.UseVisualStyleBackColor = false;
            btn_create.Click += btn_create_Click;
            // 
            // FormUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 585);
            Controls.Add(pictureBox1);
            Controls.Add(btn_create);
            Controls.Add(label4);
            Controls.Add(btn_excel);
            Controls.Add(panel1);
            Controls.Add(dtp_Birthday);
            Controls.Add(txt_imgdata);
            Controls.Add(label1);
            Controls.Add(txt_Imurl);
            Controls.Add(lb39);
            Controls.Add(btn_Edit);
            Controls.Add(btn_Del);
            Controls.Add(txt_Address);
            Controls.Add(label12);
            Controls.Add(cbx_Gender);
            Controls.Add(txt_Telnum);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(txt_Name);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormUser";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label2;
        private TextBox txt_Name;
        private Label label3;
        private Label label7;
        private Label label8;
        private TextBox txt_Telnum;
        private ComboBox cbx_Gender;
        private Label label12;
        private TextBox txt_Address;
        private Button btn_Del;
        private Button btn_Edit;
        private PictureBox pictureBox1;
        private Label lb39;
        private TextBox txt_Imurl;
        private TextBox txt_imgdata;
        private Label label1;
        private DateTimePicker dtp_Birthday;
        private Panel panel1;
        private Button btn_excel;
        private Label label4;
        private Button btn_create;
    }
}
