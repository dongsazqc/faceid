namespace Complate
{
    partial class FormIp
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
            txt_ip = new TextBox();
            label1 = new Label();
            btn_submit = new Button();
            SuspendLayout();
            // 
            // txt_ip
            // 
            txt_ip.Location = new Point(239, 198);
            txt_ip.Name = "txt_ip";
            txt_ip.Size = new Size(318, 23);
            txt_ip.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(239, 171);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 1;
            label1.Text = "EnterIP";
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(471, 251);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(75, 23);
            btn_submit.TabIndex = 2;
            btn_submit.Text = "submit";
            btn_submit.UseVisualStyleBackColor = true;
            btn_submit.Click += btn_submit_Click;
            // 
            // FormIp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_submit);
            Controls.Add(label1);
            Controls.Add(txt_ip);
            Name = "FormIp";
            Text = "FormIp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_ip;
        private Label label1;
        private Button btn_submit;
    }
}