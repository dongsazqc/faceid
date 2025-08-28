namespace Complate
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            pn_left = new Panel();
            btn_checkin = new Button();
            btn_user = new Button();
            pictureBox1 = new PictureBox();
            pn_top = new Panel();
            label1 = new Label();
            pn_mid = new Panel();
            pn_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pn_top.SuspendLayout();
            SuspendLayout();
            // 
            // pn_left
            // 
            pn_left.BackColor = Color.Brown;
            pn_left.Controls.Add(btn_checkin);
            pn_left.Controls.Add(btn_user);
            pn_left.Controls.Add(pictureBox1);
            pn_left.Location = new Point(-1, 2);
            pn_left.Name = "pn_left";
            pn_left.Size = new Size(219, 825);
            pn_left.TabIndex = 0;
            pn_left.Paint += panel1_Paint;
            // 
            // btn_checkin
            // 
            btn_checkin.BackColor = Color.FromArgb(192, 192, 0);
            btn_checkin.FlatStyle = FlatStyle.Flat;
            btn_checkin.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_checkin.Location = new Point(0, 249);
            btn_checkin.Name = "btn_checkin";
            btn_checkin.Size = new Size(219, 42);
            btn_checkin.TabIndex = 3;
            btn_checkin.Text = "Checkin";
            btn_checkin.UseVisualStyleBackColor = false;
            btn_checkin.Click += btn_checkin_Click;
            // 
            // btn_user
            // 
            btn_user.BackColor = Color.FromArgb(192, 192, 0);
            btn_user.FlatStyle = FlatStyle.Flat;
            btn_user.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_user.Location = new Point(0, 211);
            btn_user.Name = "btn_user";
            btn_user.Size = new Size(219, 42);
            btn_user.TabIndex = 1;
            btn_user.Text = "User";
            btn_user.UseVisualStyleBackColor = false;
            btn_user.Click += btn_user_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(219, 147);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pn_top
            // 
            pn_top.BackColor = Color.Black;
            pn_top.Controls.Add(label1);
            pn_top.Location = new Point(219, 2);
            pn_top.Name = "pn_top";
            pn_top.Size = new Size(1192, 99);
            pn_top.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.WhiteSmoke;
            label1.Font = new Font("Tahoma", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(518, 29);
            label1.Name = "label1";
            label1.Size = new Size(77, 33);
            label1.TabIndex = 0;
            label1.Text = "Gym";
            // 
            // pn_mid
            // 
            pn_mid.BackColor = Color.RosyBrown;
            pn_mid.Location = new Point(219, 107);
            pn_mid.Name = "pn_mid";
            pn_mid.Size = new Size(1192, 720);
            pn_mid.TabIndex = 2;
            pn_mid.Paint += pn_mid_Paint;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1414, 824);
            Controls.Add(pn_mid);
            Controls.Add(pn_top);
            Controls.Add(pn_left);
            Name = "FormMain";
            Text = "FormMain";
            Load += FormMain_Load_1;
            pn_left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pn_top.ResumeLayout(false);
            pn_top.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pn_left;
        private Button btn_user;
        private PictureBox pictureBox1;
        private Panel pn_top;
        private Panel pn_mid;
        private Button btn_checkin;
        private Label label1;
    }
}