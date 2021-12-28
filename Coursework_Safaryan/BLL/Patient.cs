using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DataValidation;
namespace BLL
{
    [Serializable]
    public class Patient : BasicCharacteristics
    {
        private double growth;
        private double weight;
        private string bloodType;
        private DateTime dateBirth;
        public double Growth
        {
            get { return growth; }
            set
            {
                if (DataValid.Growth(value) == true)
                {
                    growth = value;
                }
                else
                {
                    throw new CatchExceptions("Зріст введено неправильно!");
                }
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (DataValid.Weight(value) == true)
                {
                    weight = value;
                }
                else
                {
                    throw new CatchExceptions("Вага введена неправильно!");
                }
            }
        }
        public string BloodType
        {
            get { return bloodType; }
            set
            {
                if (DataValid.BloodType(value) == true)
                {
                    bloodType = value;
                }
                else
                {
                    throw new CatchExceptions("Група крові введена неправильно!");
                }
            }
        }
        public DateTime DateBirth
        {
            get { return dateBirth; }
            set
            {
                if (DataValid.DateBirth(value) == true)
                {
                    dateBirth = value;
                }
                else
                {
                    throw new CatchExceptions("Дата народження введено неправильно!");
                }
            }
        }
    }
}
