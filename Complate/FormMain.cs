using Complate.Data;
using Microsoft.EntityFrameworkCore;
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
    public partial class FormMain : Form
    {
        private AppDbContext _context;


        public FormMain()
        {
            InitializeComponent();

            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseMySql(
                "Server=localhost;Database=FaceDeviceDB;User=root;Password=Sazqc@123;",
                new MySqlServerVersion(new Version(8, 0, 43))
            )
            .Options;

            _context = new AppDbContext(options);
        }

        private Form currentFormChild;
        private void openChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            int x = (pn_mid.Width - childForm.Width) / 2;
            int y = (pn_mid.Height - childForm.Height) / 2;
            childForm.Location = new Point(x, y);
            pn_mid.Controls.Add(childForm);
            pn_mid.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            openChildForm(new FormUser(_context));

        }


        private void btn_checkin_Click(object sender, EventArgs e)
        {
            openChildForm(new FormCheckin(_context));
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            openChildForm(new FormLog(_context));
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void FormMain_Load_1(object sender, EventArgs e)
        {

        }

        private void pn_mid_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
