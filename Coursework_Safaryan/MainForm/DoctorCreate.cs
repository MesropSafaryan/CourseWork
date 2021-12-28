using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class DoctorCreate : Form
    {
        public DoctorCreate()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorsForm doctorsForm = new DoctorsForm();
            doctorsForm.Show();
        }

        private void CloseBut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
