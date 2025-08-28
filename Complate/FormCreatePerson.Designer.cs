namespace Complate
{
    partial class FormCreatePerson
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            dtp_Birthday = new DateTimePicker();
            txt_imgdata = new TextBox();
            label1 = new Label();
            txt_Imurl = new TextBox();
            lb39 = new Label();
            btn_Capture = new Button();
            txt_Address = new TextBox();
            label12 = new Label();
            cbx_Gender = new ComboBox();
            txt_Telnum = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label3 = new Label();
            txt_Name = new TextBox();
            label2 = new Label();
            label4 = new Label();
            btn_createuser = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(83, 69);
            panel1.Name = "panel1";
            panel1.Size = new Size(182, 247);
            panel1.TabIndex = 55;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(97, 90);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(153, 201);
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // dtp_Birthday
            // 
            dtp_Birthday.Location = new Point(372, 146);
            dtp_Birthday.Name = "dtp_Birthday";
            dtp_Birthday.Size = new Size(200, 23);
            dtp_Birthday.TabIndex = 54;
            // 
            // txt_imgdata
            // 
            txt_imgdata.Location = new Point(372, 296);
            txt_imgdata.Margin = new Padding(3, 2, 3, 2);
            txt_imgdata.Name = "txt_imgdata";
            txt_imgdata.Size = new Size(190, 23);
            txt_imgdata.TabIndex = 53;
            txt_imgdata.TextChanged += txt_imgdata_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(307, 301);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 52;
            label1.Text = "imgdata";
            // 
            // txt_Imurl
            // 
            txt_Imurl.Location = new Point(373, 256);
            txt_Imurl.Margin = new Padding(3, 2, 3, 2);
            txt_Imurl.Name = "txt_Imurl";
            txt_Imurl.Size = new Size(190, 23);
            txt_Imurl.TabIndex = 51;
            txt_Imurl.TextChanged += txt_Imurl_TextChanged;
            // 
            // lb39
            // 
            lb39.AutoSize = true;
            lb39.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lb39.Location = new Point(308, 261);
            lb39.Name = "lb39";
            lb39.Size = new Size(43, 15);
            lb39.TabIndex = 50;
            lb39.Text = "imgurl";
            // 
            // btn_Capture
            // 
            btn_Capture.BackColor = Color.Lime;
            btn_Capture.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Capture.ForeColor = SystemColors.ControlText;
            btn_Capture.Location = new Point(109, 321);
            btn_Capture.Margin = new Padding(3, 2, 3, 2);
            btn_Capture.Name = "btn_Capture";
            btn_Capture.Size = new Size(123, 51);
            btn_Capture.TabIndex = 49;
            btn_Capture.Text = "Take Photo";
            btn_Capture.UseVisualStyleBackColor = false;
            btn_Capture.Click += btn_Capture_Click;
            // 
            // txt_Address
            // 
            txt_Address.Location = new Point(373, 215);
            txt_Address.Margin = new Padding(3, 2, 3, 2);
            txt_Address.Name = "txt_Address";
            txt_Address.Size = new Size(190, 23);
            txt_Address.TabIndex = 48;
            txt_Address.TextChanged += txt_Address_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(309, 218);
            label12.Name = "label12";
            label12.Size = new Size(51, 15);
            label12.TabIndex = 47;
            label12.Text = "Address";
            // 
            // cbx_Gender
            // 
            cbx_Gender.FormattingEnabled = true;
            cbx_Gender.Location = new Point(372, 113);
            cbx_Gender.Margin = new Padding(3, 2, 3, 2);
            cbx_Gender.Name = "cbx_Gender";
            cbx_Gender.Size = new Size(122, 23);
            cbx_Gender.TabIndex = 46;
            cbx_Gender.SelectedIndexChanged += cbx_Gender_SelectedIndexChanged;
            // 
            // txt_Telnum
            // 
            txt_Telnum.Location = new Point(373, 174);
            txt_Telnum.Margin = new Padding(3, 2, 3, 2);
            txt_Telnum.Name = "txt_Telnum";
            txt_Telnum.Size = new Size(190, 23);
            txt_Telnum.TabIndex = 45;
            txt_Telnum.TextChanged += txt_Telnum_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(309, 146);
            label8.Name = "label8";
            label8.Size = new Size(54, 15);
            label8.TabIndex = 44;
            label8.Text = "Birthday";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(309, 180);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 43;
            label7.Text = "Telnum";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(308, 113);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 42;
            label3.Text = "Gender";
            // 
            // txt_Name
            // 
            txt_Name.Location = new Point(373, 69);
            txt_Name.Margin = new Padding(3, 2, 3, 2);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(190, 23);
            txt_Name.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(313, 72);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 56;
            label2.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(83, 18);
            label4.Name = "label4";
            label4.Size = new Size(176, 25);
            label4.TabIndex = 57;
            label4.Text = "Create Person New";
            // 
            // btn_createuser
            // 
            btn_createuser.BackColor = Color.Lime;
            btn_createuser.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_createuser.ForeColor = SystemColors.ControlText;
            btn_createuser.Location = new Point(607, 174);
            btn_createuser.Margin = new Padding(3, 2, 3, 2);
            btn_createuser.Name = "btn_createuser";
            btn_createuser.Size = new Size(123, 51);
            btn_createuser.TabIndex = 58;
            btn_createuser.Text = "Create";
            btn_createuser.UseVisualStyleBackColor = false;
            btn_createuser.Click += btn_createuser_Click;
            // 
            // FormCreatePerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cyan;
            ClientSize = new Size(742, 415);
            Controls.Add(btn_createuser);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(dtp_Birthday);
            Controls.Add(txt_imgdata);
            Controls.Add(label1);
            Controls.Add(txt_Imurl);
            Controls.Add(lb39);
            Controls.Add(btn_Capture);
            Controls.Add(txt_Address);
            Controls.Add(label12);
            Controls.Add(cbx_Gender);
            Controls.Add(txt_Telnum);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(txt_Name);
            Name = "FormCreatePerson";
            Text = "CreatePersons";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private DateTimePicker dtp_Birthday;
        private TextBox txt_imgdata;
        private Label label1;
        private TextBox txt_Imurl;
        private Label lb39;
        private Button btn_Capture;
        private TextBox txt_Address;
        private Label label12;
        private ComboBox cbx_Gender;
        private TextBox txt_Telnum;
        private Label label8;
        private Label label7;
        private Label label3;
        private TextBox txt_Name;
        private Label label2;
        private Label label4;
        private Button btn_createuser;
    }
}