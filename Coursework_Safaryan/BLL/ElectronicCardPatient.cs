using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DataValidation;
namespace BLL
{
    public class ElectronicCardPatient : Patient
    {
        private string codeCard;
        private string recept;
        private int durationOfAdmission;
        public string CodeCard
        {
            get { return codeCard; }
            set
            {
                if(DataValid.CodeCard.IsMatch(value) == true)
                {
                    codeCard = value;
                }
                else
                {
                    throw new CatchExceptions("Код введено не вірно!");
                }
            }
        }
        public string Receptions(List<DateTime> receptions, Doctor doctor)
        {
            recept = "Лікар: \n" + doctor.Surname + " " + doctor.Name + " " + doctor.Patronymic +
                "\nСпеціальність лікаря: " + doctor.Speciality +
                ";\n Час прийому: " + Convert.ToString(receptions[0]) + " - " + 
                Convert.ToString(receptions.Last());

            return recept;
            
        }
        public int DayOfAdmission
        {
            get; set;
        }
        public int HourOfAdmission
        {
            get; set;
        }
        public int MinuteOfAdmission
        {
            get; set;
        }
        public int DurationOfAdmission
        {
            get { return durationOfAdmission; }
            set
            {
                if (DataValid.DurationOfAdmission(value) == true)
                {
                    durationOfAdmission = value;
                }
                else
                {
                    throw new CatchExceptions("Тривалість прийому введено не вірно!");
                }
            }
        }
    }
}
