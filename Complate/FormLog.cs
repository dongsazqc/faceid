using Complate.Data;
using Complate.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Complate
{
    public partial class FormLog : Form
    {
        public FormLog(AppDbContext appDbContext)
        {
            InitializeComponent();

        }
        private void FormLog_Load(object sender, EventArgs e)
        {
        }

        private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

    }
}
