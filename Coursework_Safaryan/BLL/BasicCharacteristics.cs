using BLL.DataValidation;

namespace BLL
{
    public abstract class BasicCharacteristics
    {
        private string name, surname, patronymic;
        private int age;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public string Patronymic
        {
            get
            {
                return patronymic;
            }
            set
            {
                patronymic = value;
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (DataValid.Age(value) == true)
                {
                    age = value;
                }
                else
                {
                    throw new CatchExceptions("Вік введено неправильно!");
                }
            }
        }
    }
}
