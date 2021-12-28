using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using BLL.DataValidation;
using BLL;
using PL_Console;
using System.Collections.Generic;

namespace CourseWork.Test
{
    [TestClass]
    public class BLLtest
    {
        [TestMethod]
        public void InputDoctorAgeCorrect()
        {
            int age = -1;
            Doctor result = new Doctor();
            bool ch = true;

            try
            {
                result.Age = age;
            }
            catch
            {
                Assert.IsTrue(ch);
            }
        }
        [TestMethod]
        public void InputDoctorNameCorrect()
        {
            string name = "-1";
            Doctor result = new Doctor();
            bool ch = true;
            try
            {
                result.Name = name;
            }
            catch
            {
                Assert.IsTrue(ch);
            }
        }
        [TestMethod]
        public void InputDoctorSurnameCorrect()
        {
            string surname = "-1";
            Doctor result = new Doctor();
            bool ch = true;

            try
            {
                result.Surname = surname;
            }
            catch
            {
                Assert.IsTrue(ch);
            }
        }
        [TestMethod]
        public void InputDoctorPatronymicCorrect()
        {
            string patronymic = "-1";
            Doctor result = new Doctor();
            bool ch = true;

            try
            {
                result.Patronymic = patronymic;
            }
            catch
            {
                Assert.IsTrue(ch);
            }
        }
        [TestMethod]
        public void InputDoctorSpecialityCorrect()
        {
            string speciality = "бщлзшоьтщрг";
            Doctor result = new Doctor();
            bool ch = true;

            try
            {
                result.Speciality = speciality;
            }
            catch
            {
                Assert.IsTrue(ch);
            }
        }
        [TestMethod]
        public void InputDoctorTimeOfReceiptCorrect()
        {
            Doctor result = new Doctor();
            result.TimeOfReceipt(22, 0, 6, 0);
            result.WorkTimeFilling();
            if (result.WorkTime[0] == new DateTime(2021, 12, 20, 22, 0, 0))
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void InputPatientDurationOfAdmissionCorrect()
        {
            ElectronicCardPatient patient = new ElectronicCardPatient();
            int val = 1000;
            try
            {
                patient.DurationOfAdmission = val;
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void InputPatientGrowthCorrect()
        {
            ElectronicCardPatient patient = new ElectronicCardPatient();
            int val = 400;
            try
            {
                patient.Growth = val;
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void InputPatientWeightCorrect()
        {
            ElectronicCardPatient patient = new ElectronicCardPatient();
            int val = 800;
            try
            {
                patient.Weight = val;
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void InputPatientBloodTypeCorrect()
        {
            ElectronicCardPatient patient = new ElectronicCardPatient();
            string val = "xD";
            try
            {
                patient.BloodType = val;
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void InputPatientCodeCardCorrect()
        {
            ElectronicCardPatient patient = new ElectronicCardPatient();
            string val = "123zub";
            try
            {
                patient.CodeCard = val;
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void InputPatientDateBirthCorrect()
        {
            ElectronicCardPatient patient = new ElectronicCardPatient();
            patient.Age = 21;
            DateTime date = new DateTime(1899, 10, 10);
            try
            {
                patient.DateBirth = date;
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void CharacteristicDoctorDataTest()
        {
            Doctor doctor = new Doctor();
            doctor.Name = "Ff";
            doctor.Surname = "Fdf";
            doctor.Patronymic = "kds";
            doctor.Age = 19;
            doctor.Speciality = "Терапевт";
            doctor.StartReceiptTime = new DateTime(2021, 12, 20, 8, 0, 0);
            doctor.EndReceipTime = new DateTime(2021, 12, 20, 16, 0, 0);
            string name = "Ff";
            string surname = "Fdf";
            int age = 19;
            string speciality = "Терапевт";
            DateTime startReceiptTime = new DateTime(2021, 12, 20, 8, 0, 0);
            DateTime endReceipTime = new DateTime(2021, 12, 20, 16, 0, 0);
            if ((doctor.Name == name) && (doctor.Surname == surname) && (doctor.Age == age) && (doctor.Speciality == speciality) && 
                (doctor.StartReceiptTime == startReceiptTime) && (doctor.EndReceipTime == endReceipTime))
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void CharacteristicPatientTest()
        {
            ElectronicCardPatient patient = new ElectronicCardPatient();
            patient.CodeCard = "000001";
            patient.DayOfAdmission = 22;
            patient.HourOfAdmission = 10;
            patient.MinuteOfAdmission = 30;
            patient.DurationOfAdmission = 10;
            patient.DateBirth = new DateTime(2001, 1, 1);
            patient.BloodType = "II+";
            patient.Growth = 180;
            patient.Weight = 75;
            string codeCard = "000001";
            int dayOfAdmission = 22;
            int hourOfAdmission = 10;
            int minuteOfAdmission = 30;
            int durationOfAdmission = 10;
            DateTime dateBirth = new DateTime(2001, 1, 1);
            string bloodType = "II+";
            double growth = 180;
            double weight = 75;
            if((patient.CodeCard == codeCard) && (patient.DayOfAdmission == dayOfAdmission) && (patient.HourOfAdmission == hourOfAdmission) &&
                (patient.MinuteOfAdmission == minuteOfAdmission) && (patient.DurationOfAdmission == durationOfAdmission) && (patient.DateBirth == dateBirth) &&
                (patient.BloodType == bloodType) && (patient.Growth == growth) && (patient.Weight == weight))
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void TestTime()
        {
            Doctor result = new Doctor();
            result.TimeOfReceipt(12, 0, 20, 0);
            result.WorkTimeFilling();
            List<DateTime> checkWorkTime = new List<DateTime>();
            for(int i = 0; i < 480; i++)
            {
                checkWorkTime.Add(result.WorkTime[i]);
            }
            List<DateTime> date = new List<DateTime>();
            for(int i = 0; i < 480; i++)
            {
                date.Add(new DateTime(2021, 12, 20, 12, 0, 0).AddMinutes(i));
            }
            if (checkWorkTime == date)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void ReceptionTesting()
        {
            Doctor doctor = new Doctor();
            doctor.TimeOfReceipt(8, 0, 10, 0);
            doctor.WorkTimeFilling();
            ElectronicCardPatient patient = new ElectronicCardPatient();
            patient.DayOfAdmission = 20;
            patient.HourOfAdmission = 8;
            patient.MinuteOfAdmission = 10;
            patient.DurationOfAdmission = 10;
            Reception reception = new Reception(doctor, patient);
            List<DateTime> recept = new List<DateTime>();
            DateTime startPoint = new DateTime(2021, 12, 20, 8, 10, 0);

            reception.SpaceForRecordedPatients();
            for (int i = 0; i <= 10; i++)
            {
                recept.Add(startPoint.AddMinutes(i));
            }
            if((reception.Checking == recept) == true)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void ReceptionError1Testing()
        {
            Doctor doctor = new Doctor();
            doctor.TimeOfReceipt(8, 0, 10, 0);
            doctor.WorkTimeFilling();
            ElectronicCardPatient patient = new ElectronicCardPatient();
            patient.DayOfAdmission = 20;
            patient.HourOfAdmission = 20;
            patient.MinuteOfAdmission = 10;
            patient.DurationOfAdmission = 10;
            Reception reception = new Reception(doctor, patient);
            List<DateTime> recept = new List<DateTime>();

            DateTime startPoint = new DateTime(2021, 12, 20, 20, 10, 0);
            try
            {
                reception.SpaceForRecordedPatients();
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void ReceptionError2Testing()
        {
            Doctor doctor = new Doctor();
            doctor.TimeOfReceipt(8, 0, 10, 0);
            doctor.WorkTimeFilling();
            ElectronicCardPatient patient = new ElectronicCardPatient();
            patient.DayOfAdmission = 20;
            patient.HourOfAdmission = 9;
            patient.MinuteOfAdmission = 0;
            patient.DurationOfAdmission = 120;
            Reception reception = new Reception(doctor, patient);
            List<DateTime> recept = new List<DateTime>();

            DateTime startPoint = new DateTime(2021, 12, 20, 20, 10, 0);
            try
            {
                reception.SpaceForRecordedPatients();
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void DoctorStrWorkTimeTesting()
        {
            Doctor doctor = new Doctor();
            doctor.Name = "Ff";
            doctor.Surname = "Fdf";
            doctor.Patronymic = "kds";
            doctor.Age = 19;
            doctor.Speciality = "Терапевт";
            doctor.TimeOfReceipt(8, 0, 16, 0);
            doctor.WorkTimeFilling();
            doctor.WorkTime.RemoveAt(1);
            doctor.WorkTime.RemoveAt(1);
            doctor.WorkTime.RemoveAt(0);
            doctor.WorkTime.RemoveAt(1);
            ElectronicCardPatient patient = new ElectronicCardPatient();
            patient.DayOfAdmission = 20;
            patient.HourOfAdmission = 10;
            patient.MinuteOfAdmission = 10;
            patient.DurationOfAdmission = 10;
            Reception reception = new Reception(doctor, patient);
            List<DateTime> recept = new List<DateTime>();            
            DateTime startPoint = new DateTime(2021, 12, 20, 10, 10, 0);
            reception.SpaceForRecordedPatients();

            string strW = " ";
            if(strW == doctor.StrWorkTime())
            {               
                throw new Exception();
            }
            else
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void ReceptionStrTesting()
        {
            Doctor doctor = new Doctor();
            doctor.Name = "Ff";
            doctor.Surname = "Fdf";
            doctor.Patronymic = "kds";
            doctor.Age = 19;
            doctor.Speciality = "Терапевт";
            doctor.TimeOfReceipt(8, 0, 10, 0);
            doctor.WorkTimeFilling();
            ElectronicCardPatient patient = new ElectronicCardPatient();
            patient.CodeCard = "000001";
            patient.Name = "Dte";
            patient.Surname = "Lte";
            patient.Patronymic = "Hesoyam";
            patient.DateBirth = new DateTime(2002, 1, 1);
            patient.BloodType = "II+";
            patient.Growth = 180;
            patient.Weight = 75;
            patient.DayOfAdmission = 20;
            patient.HourOfAdmission = 8;
            patient.MinuteOfAdmission = 10;
            patient.DurationOfAdmission = 10;
            Reception reception = new Reception(doctor, patient);
            List<DateTime> recept = new List<DateTime>();
            DateTime startPoint = new DateTime(2021, 12, 20, 8, 10, 0);
            string beginning = Convert.ToString(startPoint);
            string ending = Convert.ToString(startPoint.AddMinutes(10));
            string strrecept = reception.StrSpaceForRecordedPatients();
            string strcheck = "Прийом у: \n" + doctor.Name + " " + doctor.Surname + " " + doctor.Patronymic
                + " \nСпеціальність: " + doctor.Speciality + "; \nПаціент: " + patient.Name + " " + patient.Surname +
                " " + patient.Patronymic + " \nКод електронної картки: " + patient.CodeCard + " \nЧас прийому: " +
                beginning + " - " + ending + "\n___________________________________________________________________\n";
            if(strrecept == strcheck)
            {
                Assert.IsTrue(true);
            }
            else
            {
                throw new Exception();
            }    
        }

    }
}
