using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BLL.DataValidation
{
    public static class DataValid
    {
        public static readonly Regex Name = new Regex("[a-zA-Zа-яА-ЯіїІЇйЙ]{0,200}" );
        public static readonly Regex Surname = new Regex("[a-zA-Zа-яА-ЯіїІЇйЙ]{0,200}");
        public static readonly Regex Patronymic = new Regex("[a-zA-Zа-яА-ЯіїІЇйЙ]{0,200}");
        public static bool Age(int age)
        {
            if (age > 0 && age < 121)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Doctor methods
        public static bool Speciality(string speciality)
        {
            
            if(speciality == "Терапевт" || speciality == "Реабілітолог" || speciality == "Ревматолог" ||
                speciality == "Рентгенолог" || speciality == "Рефлексотерапевт" || speciality == "Терапевт" ||
                speciality == "Сексолог" || speciality == "Сексопатолог" || speciality == "Сімейний лікар" ||
                speciality == "Стоматолог" || speciality == "Дантист" || speciality == "Токсиколог" ||
                speciality == "Травматолог" || speciality == "Трансплантолог" || speciality == "Уролог" ||
                speciality == "Фармацевт" || speciality == "Фоніатр" || speciality == "Фтизіатр" ||
                speciality == "Хірург" || speciality == "Ембріолог" || speciality == "Ендокринолог" ||
                speciality == "Еферентолог" || speciality == "Маммолог" || speciality == "Онколог-маммолог" ||
                speciality == "Мануальный терапевт" || speciality == "Остеопат" || speciality == "Медсестра" ||
                speciality == "Медична сестра" || speciality == "Медбрат" || speciality == "Міколог" ||
                speciality == "Нарколог" || speciality == "Невролог" || speciality == "Невропатолог" || speciality == "Нейрохірург" ||
                speciality == "Неонатолог" || speciality == "Нефролог" || speciality == "Нутриціолог" || speciality == "Онколог" ||
                speciality == "Хірург-онколог" || speciality == "Ортопед" || speciality == "Оториноларинголог" ||
                speciality == "Отоларинголог" || speciality == "ЛОР" || speciality == "Офтальмолог" ||
                speciality == "Окуліст" || speciality == "Патологоанатом" || speciality == "Педіатр" ||
                speciality == "Подолог" || speciality == "Провізор" || speciality == "Проктолог" ||
                speciality == "Психіатр" || speciality == "Психотерапевт" || speciality == "Пульмонолог" || speciality == "Радіолог" ||
                speciality == "Акушер-гінеколог" || speciality == "Аллерголог-імунолог" || speciality == "Андролог" || 
                speciality == "Анестезіолог-реаніматолог" || speciality == "Ароматерапевт" || speciality == "Бактеріолог" || 
                speciality == "Венеролог" || speciality == "Вертебролог" || speciality == "Лікар функціональної діагностики" || 
                speciality == "Гастроентеролог" || speciality == "Гематолог" || speciality == "Геріатр" || speciality == "Геронтолог" || 
                speciality == "Гірудотерапевт" || speciality == "Дерматолог" || speciality == "Дієтолог" || speciality == "Інфекціоніст" || 
                speciality == "Кардіолог" || speciality == "Кардіохірург" || speciality == "Функціональний діагност" || 
                speciality == "Кінезітерапевт" || speciality == "Комбустіолог" || speciality == "Опіковий хірург" || speciality == "Косметолог")
            {
                return true;
            }
            else { return false; }
        }

        #endregion

        #region Patient methods
        public static readonly Regex CodeCard = new Regex("[0-9]{6}");
        public static bool Growth (double growth)
        {
            if (growth > 25 && growth < 270)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Weight(double weight)
        {
            if (weight > 1 && weight < 500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool BloodType(string bloodType)
        {
            if (bloodType == "I+" || bloodType == "I-" || bloodType == "II+" || bloodType == "II-"
                || bloodType == "III+" || bloodType == "III-" || bloodType == "IV+" || bloodType == "IV-")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DateBirth(DateTime dateBirth)
        {
            DateTime old = new DateTime(1900, 1, 1);
            if(dateBirth.CompareTo(old) == 1 && dateBirth.CompareTo(DateTime.Now) == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DurationOfAdmission(int minutes)
        {
            if (minutes >= 5 && minutes <= 180)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}