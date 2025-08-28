using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Complate
{
    public partial class FormIp : Form
    {
        public FormIp()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {

            string ip = txt_ip.Text.Trim();

            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("Nhập IP trước khi tiếp tục!");
                return; 
            }

            // Gán IP vào HttpClientHelper
            //HttpClientHelper.SetBaseAddress(ip);

            // Mở FormMain
            FormMain fMain = new FormMain();
            fMain.Show();

            // Ẩn form nhập IP
            this.Hide();
        }
    }
}
