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
            btn_Add = new Button();
            label2 = new Label();
            txt_Name = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            txt_CardType = new TextBox();
            txt_Address = new TextBox();
            txt_Native = new TextBox();
            txt_Telnum = new TextBox();
            cbx_Gender = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            txt_Notes = new TextBox();
            txt_Nation = new TextBox();
            txt_PersonType = new TextBox();
            btn_Del = new Button();
            btn_Edit = new Button();
            pictureBox1 = new PictureBox();
            btn_Capture = new Button();
            lb39 = new Label();
            txt_Imurl = new TextBox();
            txt_imgdata = new TextBox();
            label1 = new Label();
            dtp_Birthday = new DateTimePicker();
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
            // btn_Add
            // 
            btn_Add.BackColor = SystemColors.Control;
            btn_Add.Location = new Point(30, 414);
            btn_Add.Margin = new Padding(3, 2, 3, 2);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(82, 22);
            btn_Add.TabIndex = 1;
            btn_Add.Text = "Add";
            btn_Add.UseVisualStyleBackColor = false;
            btn_Add.Click += btn_Add_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(643, 66);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 4;
            label2.Text = "Name";
            // 
            // txt_Name
            // 
            txt_Name.Location = new Point(707, 63);
            txt_Name.Margin = new Padding(3, 2, 3, 2);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(190, 23);
            txt_Name.TabIndex = 5;
            txt_Name.TextChanged += txt_Name_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(643, 99);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 6;
            label3.Text = "Gender";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(643, 257);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 7;
            label4.Text = "Address";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(643, 401);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 8;
            label5.Text = "CardType";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(643, 179);
            label7.Name = "label7";
            label7.Size = new Size(47, 15);
            label7.TabIndex = 10;
            label7.Text = "Telnum";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(643, 140);
            label8.Name = "label8";
            label8.Size = new Size(51, 15);
            label8.TabIndex = 11;
            label8.Text = "Birthday";
            // 
            // txt_CardType
            // 
            txt_CardType.Location = new Point(707, 395);
            txt_CardType.Margin = new Padding(3, 2, 3, 2);
            txt_CardType.Name = "txt_CardType";
            txt_CardType.Size = new Size(190, 23);
            txt_CardType.TabIndex = 12;
            // 
            // txt_Address
            // 
            txt_Address.Location = new Point(707, 252);
            txt_Address.Margin = new Padding(3, 2, 3, 2);
            txt_Address.Name = "txt_Address";
            txt_Address.Size = new Size(190, 23);
            txt_Address.TabIndex = 13;
            // 
            // txt_Native
            // 
            txt_Native.Location = new Point(707, 216);
            txt_Native.Margin = new Padding(3, 2, 3, 2);
            txt_Native.Name = "txt_Native";
            txt_Native.Size = new Size(190, 23);
            txt_Native.TabIndex = 14;
            txt_Native.TextChanged += txt_Native_TextChanged;
            // 
            // txt_Telnum
            // 
            txt_Telnum.Location = new Point(707, 173);
            txt_Telnum.Margin = new Padding(3, 2, 3, 2);
            txt_Telnum.Name = "txt_Telnum";
            txt_Telnum.Size = new Size(190, 23);
            txt_Telnum.TabIndex = 15;
            txt_Telnum.TextChanged += txt_Telnum_TextChanged;
            // 
            // cbx_Gender
            // 
            cbx_Gender.FormattingEnabled = true;
            cbx_Gender.Location = new Point(707, 99);
            cbx_Gender.Margin = new Padding(3, 2, 3, 2);
            cbx_Gender.Name = "cbx_Gender";
            cbx_Gender.Size = new Size(122, 23);
            cbx_Gender.TabIndex = 17;
            cbx_Gender.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(643, 221);
            label10.Name = "label10";
            label10.Size = new Size(41, 15);
            label10.TabIndex = 20;
            label10.Text = "Native";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(643, 297);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 21;
            label11.Text = "Notes";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(643, 369);
            label12.Name = "label12";
            label12.Size = new Size(43, 15);
            label12.TabIndex = 22;
            label12.Text = "Nation";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(642, 334);
            label13.Name = "label13";
            label13.Size = new Size(68, 15);
            label13.TabIndex = 23;
            label13.Text = "PersonType";
            // 
            // txt_Notes
            // 
            txt_Notes.Location = new Point(707, 291);
            txt_Notes.Margin = new Padding(3, 2, 3, 2);
            txt_Notes.Name = "txt_Notes";
            txt_Notes.Size = new Size(190, 23);
            txt_Notes.TabIndex = 27;
            // 
            // txt_Nation
            // 
            txt_Nation.Location = new Point(707, 366);
            txt_Nation.Margin = new Padding(3, 2, 3, 2);
            txt_Nation.Name = "txt_Nation";
            txt_Nation.Size = new Size(190, 23);
            txt_Nation.TabIndex = 28;
            // 
            // txt_PersonType
            // 
            txt_PersonType.Location = new Point(720, 329);
            txt_PersonType.Margin = new Padding(3, 2, 3, 2);
            txt_PersonType.Name = "txt_PersonType";
            txt_PersonType.Size = new Size(176, 23);
            txt_PersonType.TabIndex = 29;
            // 
            // btn_Del
            // 
            btn_Del.BackColor = SystemColors.Control;
            btn_Del.Location = new Point(306, 414);
            btn_Del.Margin = new Padding(3, 2, 3, 2);
            btn_Del.Name = "btn_Del";
            btn_Del.Size = new Size(82, 22);
            btn_Del.TabIndex = 30;
            btn_Del.Text = "Del";
            btn_Del.UseVisualStyleBackColor = false;
            btn_Del.Click += btn_Del_Click;
            // 
            // btn_Edit
            // 
            btn_Edit.BackColor = SystemColors.Control;
            btn_Edit.Location = new Point(169, 414);
            btn_Edit.Margin = new Padding(3, 2, 3, 2);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new Size(82, 22);
            btn_Edit.TabIndex = 31;
            btn_Edit.Text = "Edit";
            btn_Edit.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(10, 440);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(226, 124);
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btn_Capture
            // 
            btn_Capture.Location = new Point(255, 493);
            btn_Capture.Margin = new Padding(3, 2, 3, 2);
            btn_Capture.Name = "btn_Capture";
            btn_Capture.Size = new Size(82, 22);
            btn_Capture.TabIndex = 33;
            btn_Capture.Text = "button1";
            btn_Capture.UseVisualStyleBackColor = true;
            btn_Capture.Click += btn_Capture_Click;
            // 
            // lb39
            // 
            lb39.AutoSize = true;
            lb39.Location = new Point(642, 435);
            lb39.Name = "lb39";
            lb39.Size = new Size(42, 15);
            lb39.TabIndex = 34;
            lb39.Text = "imgurl";
            // 
            // txt_Imurl
            // 
            txt_Imurl.Location = new Point(707, 430);
            txt_Imurl.Margin = new Padding(3, 2, 3, 2);
            txt_Imurl.Name = "txt_Imurl";
            txt_Imurl.Size = new Size(190, 23);
            txt_Imurl.TabIndex = 35;
            txt_Imurl.TextChanged += txt_Imurl_TextChanged;
            // 
            // txt_imgdata
            // 
            txt_imgdata.Location = new Point(706, 470);
            txt_imgdata.Margin = new Padding(3, 2, 3, 2);
            txt_imgdata.Name = "txt_imgdata";
            txt_imgdata.Size = new Size(190, 23);
            txt_imgdata.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(641, 475);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 36;
            label1.Text = "imgdata";
            // 
            // dtp_Birthday
            // 
            dtp_Birthday.Location = new Point(706, 140);
            dtp_Birthday.Name = "dtp_Birthday";
            dtp_Birthday.Size = new Size(200, 23);
            dtp_Birthday.TabIndex = 38;
            // 
            // FormUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 585);
            Controls.Add(dtp_Birthday);
            Controls.Add(txt_imgdata);
            Controls.Add(label1);
            Controls.Add(txt_Imurl);
            Controls.Add(lb39);
            Controls.Add(btn_Capture);
            Controls.Add(pictureBox1);
            Controls.Add(btn_Edit);
            Controls.Add(btn_Del);
            Controls.Add(txt_PersonType);
            Controls.Add(txt_Nation);
            Controls.Add(txt_Notes);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(cbx_Gender);
            Controls.Add(txt_Telnum);
            Controls.Add(txt_Native);
            Controls.Add(txt_Address);
            Controls.Add(txt_CardType);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txt_Name);
            Controls.Add(label2);
            Controls.Add(btn_Add);
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
        private Button btn_Add;
        private Label label2;
        private TextBox txt_Name;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private TextBox txt_CardType;
        private TextBox txt_Address;
        private TextBox txt_Native;
        private TextBox txt_Telnum;
        private ComboBox cbx_Gender;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox txt_Notes;
        private TextBox txt_Nation;
        private TextBox txt_PersonType;
        private Button btn_Del;
        private Button btn_Edit;
        private PictureBox pictureBox1;
        private Button btn_Capture;
        private Label lb39;
        private TextBox txt_Imurl;
        private TextBox txt_imgdata;
        private Label label1;
        private DateTimePicker dtp_Birthday;
    }
}
