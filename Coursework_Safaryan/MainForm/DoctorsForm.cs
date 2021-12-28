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
    public partial class DoctorsForm : Form
    {
        static private List<Doctor> doctors = new List<Doctor>();
        static private List<Patient> patients = new List<Patient>();
        static private IDataFilling<List<Doctor>> doctorDataProvider;
        static private IDataFilling<List<Patient>> patientDataProvider;
        static private IEntityService<List<Doctor>> doctorObj;
        static private IEntityService<List<Patient>> patientObj;
        static private List<Doctor> DoctorsDeserialize;
        static private List<Patient> PatientDeserialize;
        static public List<Doctor> Doctors
        {
            get { return doctors; }
            set { doctors = value; }
        }
        static public List<Patient> Patients
        {
            get { return patients; }
            set { patients = value; }
        }
        static void defValue()
        {
            Doctor doctor1 = new Doctor();
            doctor1.Name = "Олег";
            doctor1.Surname = "Мартиненко";
            doctor1.Patronymic = "Павлович";
            doctor1.Age = 42;
            doctor1.Speciality = "Хірург";
            doctor1.NonWorkingDays.Add("Субота, Неділя");
            doctor1.TimeOfReceipt(8, 0, 16, 0);
            doctor1.WorkTime();
            Patient patient1 = new Patient();
            patient1.Name = "Андрій";
            patient1.Surname = "Кравченко";
            patient1.Patronymic = "Іванович";
            patient1.Growth = 170;
            patient1.Weight = 70;
            patient1.Age = 30;
            patient1.DateBirth(new DateTime(19, 7, 1991));
            patient1.BloodType = "I+";
            patient1.Card.CodeCard = "000001";
            patient1.Card.DurationOfAdmission = 15;
            patient1.Card.DayOfAdmission = 22;
            patient1.Card.HourOfAdmission = 9;
            patient1.Card.MinuteOfAdmission = 30;
            MedicalAppointment m = new MedicalAppointment();
            m.ToMakeAnAppointment(doctor1, patient1);
            Doctors.Add(doctor1);
            Patients.Add(patient1);

            Doctor doctor2 = new Doctor();
            doctor2.Name = "Ірина";
            doctor2.Surname = "Гурко";
            doctor2.Patronymic = "Олександрівна";
            doctor2.Age = 36;
            doctor2.Speciality = "Косметолог";
            doctor2.NonWorkingDays.Add("Субота, Неділя");
            doctor2.TimeOfReceipt(9, 0, 14, 0);
            doctor2.WorkTime();
            Patient patient2 = new Patient();
            patient2.Name = "Наталя";
            patient2.Surname = "Сергійчук";
            patient2.Patronymic = "Петрівна";
            patient2.Growth = 164;
            patient2.Weight = 55;
            patient2.Age = 22;
            patient2.DateBirth(new DateTime(19, 7, 1991));
            patient2.BloodType = "III-";
            patient2.Card.CodeCard = "000002";
            patient2.Card.DurationOfAdmission = 15;
            patient2.Card.DayOfAdmission = 20;
            patient2.Card.HourOfAdmission = 9;
            patient2.Card.MinuteOfAdmission = 0;
            MedicalAppointment m2 = new MedicalAppointment();
            m2.ToMakeAnAppointment(doctor2, patient2);
            Doctors.Add(doctor2);
            Patients.Add(patient2);
            SerializingDataDoctor();
            SerializingDataPatient();
        }

        public static void SerializingDataDoctor()
        {
            if (Doctors != null)
            {
                doctorDataProvider = new SerializeXML<List<Doctor>>(@"D:\vs project\LabWorkNo3Pt2\LabWork3.2\DLL\xmlListStudent.xml");
                doctorObj = new EntityService<List<Doctor>>(doctorDataProvider);
                doctorObj.AddNewData(Doctors);
            }
        }
        public static void SerializingDataPatient()
        {
            if (Patients != null)
            {
                patientDataProvider = new SerializeXML<List<Patient>>(@"D:\vs project\LabWorkNo3Pt2\LabWork3.2\DLL\xmlListStudent.xml");
                patientObj = new EntityService<List<Patient>>(patientDataProvider);
                patientObj.AddNewData(Patients);
            }
        }
        public static void ListMenuDeserializeDoctor()
        {
            new EntityService<List<Doctor>>(doctorDataProvider);
            DoctorsDeserialize = doctorObj.GetData();
        }
        public static void ListMenuDeserializePatient()
        {
            new EntityService<List<Patient>>(patientDataProvider);
            PatientDeserialize = patientObj.GetData();
        }
        public DoctorsForm()
        {
            InitializeComponent();          
            doctorsBox.Items.Add(Doctors[0].Name + " " + Doctors[1].Surname + " " + Doctors[0].Patronymic);
            doctorsBox.Items.Add(Doctors[1].Name + " " + Doctors[1].Surname + " " + Doctors[1].Patronymic);
            doctorsBox.SelectedIndex = 0;
            if (doctorsBox.SelectedIndex == 0)
            {
                Initials.Text = Doctors[0].Name;
                SurnameBox.Text = Doctors[0].Surname;
                textBox2.Text = Doctors[0].Patronymic;
                ageBox.Text = Convert.ToString(Doctors[0].Age);
                Speciality.SelectedItem = Doctors[0].Speciality;
                fromTime.Text = Convert.ToString(Doctors[0].StartReceiptTime);
                toTime.Text = Convert.ToString(Doctors[0].EndReceipTime);
                nonDaysOfWeek.Text = Convert.ToString(Doctors[0].NonWorkingDays);
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();            
            mainForm mainF = new mainForm();
            mainF.Show();
        }

        private void createNewBut_Click(object sender, EventArgs e)
        {

        }

        private void doctorsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doctors[1].Name = Initials.Text;
            Doctors[1].Surname = SurnameBox.Text;
            Doctors[1].Patronymic = textBox2.Text;
            Doctors[1].Age = Convert.ToInt32(ageBox.Text);
            Doctors[1].Speciality = (string)Speciality.SelectedItem;
            Doctors[1].StartReceiptTime = Convert.ToDateTime(fromTime.Text);
            Doctors[1].EndReceipTime = Convert.ToDateTime(toTime.Text);
            List<string> dayOf = new List<string>(7);
            if(nonDaysOfWeek.Text.Contains("Понеділок"))
            {
                dayOf.Add("Понеділок");
            }
            if (nonDaysOfWeek.Text.Contains("Вівторок"))
            {
                dayOf.Add("Вівторок");
            }
            if (nonDaysOfWeek.Text.Contains("Середа"))
            {
                dayOf.Add("Середа");
            }
            if (nonDaysOfWeek.Text.Contains("Четвер"))
            {
                dayOf.Add("Четвер");
            }
            if (nonDaysOfWeek.Text.Contains("П'ятниця"))
            {
                dayOf.Add("П'ятниця");
            }
            if (nonDaysOfWeek.Text.Contains("Субота"))
            {
                dayOf.Add("Субота");
            }
            if (nonDaysOfWeek.Text.Contains("Неділя"))
            {
                dayOf.Add("Неділя");
            }
            Doctors[1].NonWorkingDays.Clear();
            Doctors[1].NonWorkingDays.AddRange(dayOf);
            SerializingDataDoctor();
            ListMenuDeserializeDoctor();
        }
    }
}
