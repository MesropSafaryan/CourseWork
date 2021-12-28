using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Reception
    {
        private List<DateTime> checking = new List<DateTime>();
        private Doctor doctor = new Doctor();
        private ElectronicCardPatient patient = new ElectronicCardPatient();
        public List<DateTime> Checking { get { return checking; } }
        public Reception(Doctor doc, ElectronicCardPatient pat)
        {
            doctor = doc;
            patient = pat;
        }
        public List<DateTime> SpaceForRecordedPatients()
        {
            DateTime StartPoint = new DateTime(2021, 12, patient.DayOfAdmission, patient.HourOfAdmission, patient.MinuteOfAdmission, 0);
            bool checkS = false;
            for (int i = 0; i < doctor.WorkTime.Count; i++)
            {
                if(doctor.WorkTime[i] == StartPoint && doctor.WorkTime.Contains(StartPoint.AddMinutes(patient.DurationOfAdmission)))
                {
                    checkS = true;
                }
            }
            if (checkS == true)
            {
                for (int j = 0; j < doctor.WorkTime.Count; j++)
                {
                    if (doctor.WorkTime[j] == StartPoint)
                    {
                        for (int i = 0; i <= patient.DurationOfAdmission; i++)
                        {
                            checking.Add(doctor.WorkTime[j + i]);
                        }
                        if (checking.Last() == StartPoint.AddMinutes(patient.DurationOfAdmission))
                        {
                            for (int i = 0; i < patient.DurationOfAdmission; i++)
                            {
                                doctor.WorkTime.RemoveAt(j + i);
                                j--;
                            }
                            patient.Receptions(checking, doctor);
                            doctor.RecordedPatients(checking, patient);
                            return checking;
                        }                       
                    }
                }
            }            
            return null;

        }
        public string StrSpaceForRecordedPatients()
        {
            List<DateTime> copy = SpaceForRecordedPatients();
            string beginning = Convert.ToString(copy[0]);
            string ending = Convert.ToString(copy.Last());
            string result = "Прийом у: \n" + doctor.Name + " " + doctor.Surname + " " +  doctor.Patronymic 
                + " \nСпеціальність: " + doctor.Speciality + "; \nПаціент: " + patient.Name+ " " + patient.Surname + 
                " " + patient.Patronymic + " \nКод електронної картки: " + patient.CodeCard + " \nЧас прийому: " + 
                beginning + " - " + ending + "\n___________________________________________________________________\n";
            
            return result;
        }
    }
}