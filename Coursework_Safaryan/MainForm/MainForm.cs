using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DAL.Interface;
using BLL;
using EntityService;
using EntityService.Interface;
using PL;

namespace PL
{
    public partial class mainForm : Form
    {
        
        public mainForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorsForm doctorsForm = new DoctorsForm();
            doctorsForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientsForm patientsForm = new PatientsForm();
            patientsForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
