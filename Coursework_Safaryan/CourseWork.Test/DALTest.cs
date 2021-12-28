using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using BLL.DataValidation;
using BLL;
using PL_Console;
using DAL.Interface;
using EntityService.Interface;
using EntityService;

namespace CourseWork.Test
{
    [TestClass]
    public class DALTest
    {
       
        [TestMethod]
        public void SerializeAndDeserialize()
        {
            List<Doctor> doctors = new List<Doctor>();
            Doctor doctor = new Doctor();
            doctor.Name = "Ff";
            doctor.Surname = "Fdf";
            doctor.Patronymic = "kds";
            doctor.Age = 19;
            doctor.Speciality = "Терапевт";
            doctor.TimeOfReceipt(8, 0, 10, 0);
            doctor.WorkTimeFilling();
            IDataFilling<List<Doctor>> doctorDataProvider;
            IEntityService<List<Doctor>> doctorObj;
            List<Doctor> DoctorsDeserialize;

            doctors.Add(doctor);
            doctorDataProvider = new SerializeXML<List<Doctor>>(@"D:\vs project\Coursework_Safaryan\XML\DocTest.xml");
            doctorObj = new EntityService<List<Doctor>>(doctorDataProvider);
            doctorObj.AddNewData(doctors);

            new EntityService<List<Doctor>>(doctorDataProvider);
            DoctorsDeserialize = doctorObj.GetData();

            if((DoctorsDeserialize[0].Name == doctors[0].Name) && (DoctorsDeserialize[0].Surname == doctors[0].Surname) && (DoctorsDeserialize[0].Patronymic == doctors[0].Patronymic) &&
                (DoctorsDeserialize[0].Speciality == doctors[0].Speciality) && (DoctorsDeserialize[0].Age == doctors[0].Age) && (DoctorsDeserialize[0].StartReceiptTime == doctors[0].StartReceiptTime) && (DoctorsDeserialize[0].EndReceipTime == doctors[0].EndReceipTime))
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
