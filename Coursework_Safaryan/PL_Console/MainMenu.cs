using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interface;
using BLL;
using EntityService;
using EntityService.Interface;

namespace PL_Console
{
    public static class MainMenu
    {
        static private List<Doctor> doctors = new List<Doctor>();
        static private List<ElectronicCardPatient> patients = new List<ElectronicCardPatient>();
        static private IDataFilling<List<Doctor>> doctorDataProvider;
        static private IDataFilling<List<ElectronicCardPatient>> patientDataProvider;
        static private IEntityService<List<Doctor>> doctorObj;
        static private IEntityService<List<ElectronicCardPatient>> patientObj;
        static private List<Doctor> DoctorsDeserialize;
        static private List<ElectronicCardPatient> PatientDeserialize;
        static private List<Doctor> Doctors
        {
            get { return doctors; }
            set { doctors = value; }
        }
        static private List<ElectronicCardPatient> Patients
        {
            get { return patients; }
            set { patients = value; }
        }
        static private void defValue()
        {
            Doctor doctor1 = new Doctor();
            doctor1.Name = "Олег";
            doctor1.Surname = "Мартиненко";
            doctor1.Patronymic = "Павлович";
            doctor1.Age = 42;
            doctor1.Speciality = "Хірург";
            doctor1.TimeOfReceipt(8, 0, 16, 0);
            doctor1.WorkTimeFilling();
            ElectronicCardPatient patient1 = new ElectronicCardPatient();
            patient1.Name = "Андрій";
            patient1.Surname = "Кравченко";
            patient1.Patronymic = "Іванович";
            patient1.Growth = 170;
            patient1.Weight = 70;
            patient1.Age = 30;
            patient1.DateBirth = new DateTime(1991, 1, 1);
            patient1.BloodType = "I+";
            patient1.CodeCard = "000001";
            patient1.DurationOfAdmission = 15;
            patient1.DayOfAdmission = 20;
            patient1.HourOfAdmission = 8;
            patient1.MinuteOfAdmission = 10;
            //MedicalAppointment m = new MedicalAppointment();
            //m.ToMakeAnAppointment(doctor1, patient1);
            Doctors.Add(doctor1);
            Patients.Add(patient1);

            Doctor doctor2 = new Doctor();
            doctor2.Name = "Ірина";
            doctor2.Surname = "Гурко";
            doctor2.Patronymic = "Олександрівна";
            doctor2.Age = 36;
            doctor2.Speciality = "Косметолог";
            doctor2.TimeOfReceipt(9, 0, 14, 0);
            doctor2.WorkTimeFilling();
            ElectronicCardPatient patient2 = new ElectronicCardPatient();
            patient2.Name = "Наталя";
            patient2.Surname = "Сергійчук";
            patient2.Patronymic = "Петрівна";
            patient2.Growth = 164;
            patient2.Weight = 55;
            patient2.Age = 22;
            patient2.DateBirth = new DateTime(1990, 7, 6);
            patient2.BloodType = "III-";
            patient2.CodeCard = "000002";
            patient2.DurationOfAdmission = 15;
            patient2.DayOfAdmission = 20;
            patient2.HourOfAdmission = 9;
            patient2.MinuteOfAdmission = 0;
           // MedicalAppointment m2 = new MedicalAppointment();
            //m2.ToMakeAnAppointment(doctor2, patient2);
            Doctors.Add(doctor2);
            Patients.Add(patient2);
            //return m.ToMakeAnAppointment(doctor1, patient1);
        }
        private static void DoctorInfo(Doctor doctor)
        {
            Console.WriteLine("Ім'я: " + doctor.Name);
            Console.WriteLine("Прізвище: " + doctor.Surname);
            Console.WriteLine("По-батькові: " + doctor.Patronymic);
            Console.WriteLine("Вік: " + doctor.Age);
            Console.WriteLine("Спеціальність: " + doctor.Speciality);
            Console.WriteLine("Початок робочого часу: " + doctor.StartReceiptTime);
            Console.WriteLine("Кінець робочого часу: " + doctor.EndReceipTime);
            Console.WriteLine("____________________________________\n");
        }
        private static void PatientInfo(ElectronicCardPatient patient)
        {
            Console.WriteLine("Ім'я: " + patient.Name);
            Console.WriteLine("Прізвище: " + patient.Surname);
            Console.WriteLine("По-батькові: " + patient.Patronymic);
            Console.WriteLine("Вік: " + patient.Age);
            Console.WriteLine("Дата народження: " + patient.DateBirth);
            Console.WriteLine("Зріст: " + patient.Growth);
            Console.WriteLine("Вага: " + patient.Weight);
            Console.WriteLine("Група крові: " + patient.BloodType);
            Console.WriteLine("Номер електронної мед. картки: " + patient.CodeCard);
            Console.WriteLine("Бажаний прийом у лікаря: " + patient.DayOfAdmission + ".12.2021, о " +
                patient.HourOfAdmission + ":" + patient.MinuteOfAdmission);
            Console.WriteLine("Тривалість прийому: " + patient.DurationOfAdmission + "хв");
            Console.WriteLine("____________________________________\n");
        }
        private static void CheckValue(object obj, string declaration)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(declaration);
                    obj = Console.ReadLine();
                    break;
                }
                catch
                {
                    Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                }
            }
        }
        private static void CheckIntValue(object obj, string declaration)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(declaration);
                    obj = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                }
            }
        }
        private static void CheckDoubleValue(object obj, string declaration)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(declaration);
                    obj = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                }
            }
        }
        private static void SerializingDataDoctor()
        {
            if (Doctors != null)
            {
                doctorDataProvider = new SerializeXML<List<Doctor>>(@"D:\vs project\Coursework_Safaryan\XML\Doctors.xml");
                doctorObj = new EntityService<List<Doctor>>(doctorDataProvider);
                doctorObj.AddNewData(Doctors);
            }
        }
        private static void SerializingDataPatient()
        {
            if (Patients != null)
            {
                patientDataProvider = new SerializeXML<List<ElectronicCardPatient>>(@"D:\vs project\Coursework_Safaryan\XML\Patients.xml");
                patientObj = new EntityService<List<ElectronicCardPatient>>(patientDataProvider);
                patientObj.AddNewData(Patients);
            }
        }
        private static void DeserializeDoctor()
        {
            new EntityService<List<Doctor>>(doctorDataProvider);
            DoctorsDeserialize = doctorObj.GetData();
        }
        private static void DeserializePatient()
        {
            new EntityService<List<ElectronicCardPatient>>(patientDataProvider);
            PatientDeserialize = patientObj.GetData();
        }
        private static void ListMenuDeserializeDoctor()
        {
            new EntityService<List<Doctor>>(doctorDataProvider);
            DoctorsDeserialize = doctorObj.GetData();
            foreach (var doct in DoctorsDeserialize)
            {
                Console.WriteLine("Лікар:");
                DoctorInfo(doct);
            }
        }
        private static void ListMenuDeserializePatient()
        {
            new EntityService<List<ElectronicCardPatient>>(patientDataProvider);
            PatientDeserialize = patientObj.GetData();
            foreach (var pat in PatientDeserialize)
            {
                Console.WriteLine("Паціент:");
                PatientInfo(pat);
            }
        }

        private static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("Виберіть операцію:\n1. Перейти в меню по роботі з лікарями; " +
                "\n2. Перейти в меню по роботі з паціентами " + "\n3. Перейти в меню роботи над прийомами; \n4. Здійснити пошук;\n5. Вийти;");
        }
        private static string Choice()
        {
            string c = Console.ReadLine();
            return c;
        }
        private static void DoctorDataInput()
        {
            for (int i = 0; i < 1;)
            {
                Doctor doc = new Doctor();

                Console.WriteLine("Лікар:");
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть ім'я: ");
                        doc.Name = Console.ReadLine();
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть Прізвище: ");
                        doc.Surname = Console.ReadLine();
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть по-батькові: ");
                        doc.Patronymic = Console.ReadLine();
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть спеціальність: ");
                        doc.Speciality = Console.ReadLine();
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть вік: ");
                        doc.Age = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }             
                while (true)
                {
                    try
                    {
                        Console.Write("Введіть годину з скількох починається робота лікаря: ");
                        int hS = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введіть хвилини: ");
                        int mS = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введіть годину завершення роботи: ");
                        int hE = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введіть хвилини по завершенню роботи: ");
                        int mE  = Convert.ToInt32(Console.Read());
                        doc.TimeOfReceipt(hS, mS, hE, mE);
                        doc.WorkTimeFilling();
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильно введена інформація. Введіть ще раз:");
                    }
                }
                Doctors.Add(doc);
                Console.Write("Бажаєте ввести дані ще одного лікаря?: ");
                for (int j = 0; j < 1;)
                {
                    string a = Console.ReadLine();
                    if (a == "ні")
                    {
                        SerializingDataDoctor();
                        Console.Clear();
                        j++;
                        i++;
                        StartMenu();
                    }
                    else if (a == "так")
                    {
                        Console.Clear();
                        j++;
                    }
                    else
                    {
                        Console.WriteLine("Неправильно введені дані. Введіть \"так \" або \"ні\"");
                    }
                }
            }
        }
        private static void PatientDataInput()
        {
            
            for (int i = 0; i < 1;)
            {
                ElectronicCardPatient pat = new ElectronicCardPatient();

                Console.WriteLine("Паціент:");
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть ім'я: ");
                        pat.Name = Console.ReadLine();
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть прізвище: ");
                        pat.Surname = Console.ReadLine();
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть по-батькові: ");
                        pat.Patronymic = Console.ReadLine();
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть вік: ");
                        pat.Age = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть групу крові: ");
                        pat.BloodType = Console.ReadLine();
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть зріст: ");
                        pat.Growth = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть вагу: ");
                        pat.Weight = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.Write("Введіть день народження (рік, місяць, число): ");
                        DateTime a = Convert.ToDateTime(Console.ReadLine());
                        pat.DateBirth = a;
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильно введена інформація. Введіть день народження ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть код електроної медичної картки: ");
                        pat.CodeCard = Console.ReadLine();
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть тривалість прийому: ");
                        pat.DurationOfAdmission = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть день числа прийому(з 20 по 26): ");
                        pat.DayOfAdmission = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть годину прийому: ");
                        pat.HourOfAdmission = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введіть хвилини прийому: ");
                        pat.MinuteOfAdmission = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                    }
                }
                Patients.Add(pat);
                Console.Write("Бажаєте ввести дані ще одного пацієнта?: ");
                for (int j = 0; j < 1;)
                {
                    string a = Console.ReadLine();
                    if (a == "ні")
                    {
                        SerializingDataPatient();
                        Console.Clear();
                        j++;
                        i++;

                        StartMenu();
                    }
                    else if (a == "так")
                    {
                        Console.Clear();
                        j++;
                    }
                    else
                    {
                        Console.WriteLine("Неправильно введені дані. Введіть \"так \" або \"ні\"");
                    }
                }
            }
        }
        private static void DoctorMenu()
        {
            for (int k = 0; k < 1;)
            { Console.Clear();
                Console.WriteLine("1. Показати дані; \n2. Видалити лікаря; \n3. Змінити дані про лікаря;  \n4. Додати лікаря; \n5. Повернутись;");
                switch (Choice())
                {
                    case ("1"):
                        {
                            ListMenuDeserializeDoctor();
                            Console.ReadKey();
                            break;
                        }
                    case ("2"):
                        {
                            Console.WriteLine("Виберіть, якого лікаря видалити:");
                            int i = 0;
                            foreach (var doct in Doctors)
                            {
                                i++;
                                Console.WriteLine("Лікар №" + i);
                                DoctorInfo(doct);
                            }
                            int s;
                            while (true)
                            {
                                try
                                {
                                    s = Convert.ToInt32(Console.ReadLine());
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                }
                            }
                            if (s > i || s < 1)
                            {
                                Console.WriteLine("Введено неправильне значення. Спробуйте ще раз");
                            }
                            else
                            {
                                Doctors.RemoveAt(s - 1);
                                SerializingDataDoctor();
                            }
                            break;
                        }
                    case ("3"):
                        {
                            Console.Clear();
                            Console.WriteLine("Виберіть, параметри якого лікаря ви хочете змінити:");
                            int i = 0;
                            foreach (var doct in Doctors)
                            {
                                i++;
                                Console.WriteLine("Лікар №" + i);
                                DoctorInfo(doct);
                            }
                            Console.Write("Введіть номер лікаря, чиї характеристики ви хочете змінити: ");
                            int s;
                            while (true)
                            {
                                try
                                { 
                                    s = Convert.ToInt32(Console.ReadLine());
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                }
                            }
                            if (s > i || s < 1)
                            {
                                Console.WriteLine("Введено неправильне значення. Спробуйте ще раз");
                            }
                            else
                            {
                                for (int j = 0; j < 1;)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Лікар №" + (s - 1));
                                    DoctorInfo(Doctors[s - 1]);
                                    Console.WriteLine("Для того аби вийти введіть \"Exit\"");
                                    Console.WriteLine("Оберіть що хочете змінити з усіх варіантів (введіь найменування англійською, наприклад \"Name\"):" +
                                        "\nName, Surname, Patronymic, Age, Speciality, StartReceiptTime");
                                    switch (Console.ReadLine())
                                    {
                                        case ("Name"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення Name: ");
                                                        Doctors[s - 1].Name = Console.ReadLine();
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }                                               
                                                break;
                                            }
                                        case ("Surname"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення Surname: ");
                                                        Doctors[s - 1].Surname = Console.ReadLine();
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }
                                        case ("Patronymic"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення Patronymic: ");
                                                        Doctors[s - 1].Patronymic = Console.ReadLine();
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                CheckValue(Doctors[s - 1].Patronymic, "Введіть нове значення Patronymic: ");
                                                break;
                                            }
                                        case ("Age"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення Age: ");
                                                        Doctors[s - 1].Age = Convert.ToInt32(Console.ReadLine()); ;
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                    
                                                }
                                                break;
                                            }
                                        case ("Speciality"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення Speciality: ");
                                                        Doctors[s - 1].Speciality = Console.ReadLine();
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                CheckValue(Doctors[s - 1].Speciality, "Введіть нове значення Speciality: ");
                                                break;
                                            }
                                        
                                        case ("StartReceiptTime"):
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Введіть нове значення StartReceiptTime: ");
                                                Console.Write("Година: ");
                                                int sH = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Хвилина: ");
                                                int sM = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Введіть нове значення EndReceiptTime: ");
                                                int eH = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Хвилина: ");
                                                int eM = Convert.ToInt32(Console.ReadLine());
                                                while (true)
                                                {
                                                    try 
                                                    { 
                                                        Doctors[s - 1].TimeOfReceipt(sH, sM, eH, eM);
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                SerializingDataDoctor();
                                                break;
                                            }
                                        case ("Exit"):
                                            {
                                                j++;
                                                break;
                                            }
                                        default:
                                            Console.WriteLine("Неправильно введені дані. Спробуйте ще раз");
                                            Console.ReadLine();
                                            break;
                                    }
                                }
                                
                                SerializingDataDoctor();
                            }
                            break;
                        }
                    case ("4"):
                        {
                            DoctorDataInput();
                            SerializingDataDoctor();
                            break;
                        }
                    case ("5"):
                        {
                            k++;
                            break;
                        }
                    default:
                        Console.WriteLine("Неправильно введені дані. Введіть цифру від 1 до 5");
                        break;
                }
            }
        }
        private static void PatientMenu()
        {
            for (int k = 0; k < 1;)
            {
                Console.Clear();
                Console.WriteLine("1. Показати дані; \n2. Додати паціента; \n3. Змінити дані електронної картки паціента;  " +
                    "\n4. Видалити паціента; \n5. Повернутись;");
                switch (Choice())
                {
                    case ("1"):
                        {
                            ListMenuDeserializePatient();
                            Console.ReadKey();
                            break;
                        }
                    case ("2"):
                        {
                            PatientDataInput();
                            break;
                        }
                    case ("3"):
                        {
                            Console.Clear();
                            Console.WriteLine("Виберіть, параметри якого пацієнта ви хочете змінити:");
                            int i = 0;
                            foreach (var pat in PatientDeserialize)
                            {
                                i++;
                                Console.WriteLine("Пацієнт №" + i);
                                PatientInfo(pat);
                            }
                            int s;
                            while (true)
                            {
                                try
                                {
                                    s = Convert.ToInt32(Console.ReadLine());
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                }
                            }
                            if (s > i || s < 1)
                            {
                                Console.WriteLine("Введено неправильне значення. Спробуйте ще раз");
                            }
                            else
                            {
                                for (int j = 0; j < 1;)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Паціент №" + (s - 1));
                                    PatientInfo(Patients[s - 1]);
                                    Console.WriteLine("Для того аби вийти введіть \"Exit\"");
                                    Console.WriteLine("Оберіть що хочете змінити (введіь найменування англійською): ");
                                    switch (Console.ReadLine())
                                    {
                                        case ("Name"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення Name: ");
                                                        Patients[s - 1].Name = Console.ReadLine();
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }
                                        case ("Surname"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення Name: ");
                                                        Patients[s - 1].Surname = Console.ReadLine();
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }
                                        case ("Patronymic"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення Patronymic: ");
                                                        Patients[s - 1].Patronymic = Console.ReadLine();
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                CheckValue(Patients[s - 1].Patronymic, "Введіть нове значення Patronymic: ");
                                                break;
                                            }
                                        case ("Age"):
                                            {
                                                Console.Clear();
                                                CheckValue(Patients[s - 1].Age, "Введіть нове значення Age: ");
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення Age: ");
                                                        Patients[s - 1].Age = Convert.ToInt32(Console.ReadLine());
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }
                                        case ("DateBirth"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення DateBirth: ");
                                                        Patients[s - 1].DateBirth = Convert.ToDateTime(Console.ReadLine());
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }
                                        case ("BloodType"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення BloodType: ");
                                                        Patients[s - 1].BloodType = Console.ReadLine();
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }
                                        case ("Growth"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення Growth: ");
                                                        Patients[s - 1].Growth = Convert.ToDouble(Console.ReadLine());
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }
                                        case ("Weight"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення Weight: ");
                                                        Patients[s - 1].Weight = Convert.ToDouble(Console.ReadLine());
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }
                                        case ("CodeCard"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення CodeCard: ");
                                                        Patients[s - 1].CodeCard = Console.ReadLine();
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }
                                        case ("DayOfAdmission"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення DayOfAdmission: ");
                                                        Patients[s - 1].DayOfAdmission = Convert.ToInt32(Console.ReadLine());
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }
                                        case ("HourOfAdmission"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення HourOfAdmission: ");
                                                        Patients[s - 1].HourOfAdmission = Convert.ToInt32(Console.ReadLine());
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }
                                        case ("MinuteOfAdmission"):
                                            {
                                                Console.Clear();
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення MinuteOfAdmission: ");
                                                        Patients[s - 1].MinuteOfAdmission = Convert.ToInt32(Console.ReadLine());
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }
                                        case ("DurationOfAdmission"):
                                            {
                                                Console.Clear();
                                                CheckValue(Patients[s - 1].DurationOfAdmission, "Введіть нове значення DurationOfAdmission: ");
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("Введіть нове значення DurationOfAdmission: ");
                                                        Patients[s - 1].DurationOfAdmission = Convert.ToInt32(Console.ReadLine());
                                                        SerializingDataDoctor();
                                                        break;
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                                    }
                                                }
                                                break;
                                            }                                      
                                        case ("Exit"):
                                            {
                                                j++;
                                                break;
                                            }
                                        default:
                                            Console.WriteLine("Неправильно введені дані. Спробуйте ще раз");
                                            Console.ReadKey();
                                            break;
                                    }
                                }

                                SerializingDataPatient();
                            }
                            break;
                        }
                    case ("4"):
                        {
                            Console.WriteLine("Виберіть, якого паціента видалити:");
                            int i = 0;
                            foreach (var pat in Patients)
                            {
                                i++;
                                Console.WriteLine("Паціент №" + i);
                                PatientInfo(pat);
                            }
                            int s;
                            while (true)
                            {
                                try
                                {
                                    s = Convert.ToInt32(Console.ReadLine());
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("Неправильний ввід. Спробуйте ще раз");
                                }
                            }
                            if (s > i || s < 1)
                            {
                                Console.WriteLine("Введено неправильне значення. Спробуйте ще раз");
                            }
                            else
                            {
                                Patients.RemoveAt(s - 1);
                                SerializingDataPatient();
                            }
                            break;
                        }
                    case ("5"):
                        {
                            k++;
                            break;
                        }
                    default:
                        Console.WriteLine("Неправильно введені дані. Введіть цифру від 1 до 5");
                        break;
                }
            }
        }
        private static List<Reception> recept = new List<Reception>();
        private static void ReceptionSchedule()
        {                  
            for (int p = 0; p < 1;)
            {
                Console.Clear();
                Console.WriteLine("\t\t\tМеню управління прийомами");
                Console.WriteLine("Виберіть операцію: \n1. Переглянути вільні часи для прийому у всіх присутніх лікарів; \n2. Переглянути прийоми, що мають " +
                    "статись; \n3. Обрати паціанта, котрому необхідно записатись на прийом; \n4. Повернутись;");
                DeserializeDoctor();
                DeserializePatient();
                switch (Choice())
                {

                    case ("1"):
                        {
                            int val = 0;
                            foreach (var doc in DoctorsDeserialize)
                            {
                                Console.WriteLine("Лікар № " + val);
                                Console.Write(doc.Surname + " ");
                                Console.Write(doc.Name + " ");
                                Console.Write(doc.Patronymic + "\n");
                                Console.WriteLine(doc.Speciality);
                                Console.WriteLine(doc.StrWorkTime());
                                val++;
                            }
                            Console.ReadLine();
                            break;
                        }
                    case ("2"):
                        {
                           
                            Console.WriteLine("Прийоми, що мають статись: ");
                            if (recept.Count == 0)
                            {
                                Console.WriteLine("Поки що немає ніяких прийомів");
                            }
                            else
                            {
                                for (int i = 0; i < recept.Count; i++)
                                {
                                    Console.WriteLine(recept[i].StrSpaceForRecordedPatients());
                                }
                            }
                            Console.ReadLine();
                            break;
                        }
                    case ("3"):
                        {
                           for(int f = 0; f < 1;)
                           {
                                Console.WriteLine("Усі пацієнти:\n");
                                int val = 0;
                                int v = 0;
                                foreach (var pat in PatientDeserialize)
                                {
                                    Console.WriteLine("Пацієнт №" + val);
                                    PatientInfo(pat);
                                    val++;
                                }
                                Console.Write("Виберіть якому пацієнту ви хочете назначити прийом: ");                               
                                while(true)
                                {
                                    while (true)
                                    {
                                        try
                                        {
                                            v = Convert.ToInt32(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Неправильний ввід");
                                        }
                                    }
                                    if((v < Patients.Count) && (v >= 0))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Обраний пацієнт:");
                                        PatientInfo(Patients[v]);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неправильний ввід");
                                    }
                                }
                                Console.WriteLine("Виберіть до якого лікаря ви хочете записати пацієнта: ");
                                int numb = 0;
                                foreach (var doc in DoctorsDeserialize)
                                {

                                    Console.WriteLine("Лікар № " + (numb));
                                    Console.Write(doc.Surname + " ");
                                    Console.Write(doc.Name + " ");
                                    Console.Write(doc.Patronymic + "\n");
                                    Console.WriteLine(doc.Speciality);
                                    Console.WriteLine(doc.StrWorkTime());
                                    numb++;
                                }
                                int q = 0;
                                while (true)
                                {
                                    while (true)
                                    {
                                        try
                                        {
                                            q = Convert.ToInt32(Console.ReadLine());
                                            break;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Неправильний ввід");
                                        }
                                    }
                                    if ((q < Patients.Count) && (q >= 0))
                                    {
                                        Console.WriteLine("Обраний :");
                                        DoctorInfo(Doctors[q]);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неправильний ввід");
                                    }
                                }
                                Reception reception = new Reception(Doctors[q], Patients[v]);
                                recept.Add(reception);
                                Console.WriteLine("Створення прийому пройшло успішно.");
                                Console.ReadLine();
                                return;
                            }
                            break;
                        }
                    case ("4"):
                        {
                            p++;
                            break;
                        }
                    default:
                        Console.WriteLine("Неправильно введені дані. Введіть цифру від 1 до 4");
                        break;
                }
            }
            Console.ReadKey();


        }
        private static void SearchMenu()
        {
            for (int z = 0; z < 1;)
            {
                Console.WriteLine("Виберіть кого ви хочете знайти: лікаря, чи паціента?");
                switch (Choice())
                {
                    case ("лікаря"):
                        {
                            Console.WriteLine("Оберіть за чим ви хочете знайти лікаря (ім'я, прізвище чи спеціальність)");
                            for (int fw = 0; fw < 1;)
                            {
                                switch (Console.ReadLine())
                                {
                                    case ("ім'я"):
                                        {
                                            Console.WriteLine("Введіть ім'я: ");
                                            string n = Console.ReadLine();
                                            int fl = 0;
                                            for (int r = 0; r < DoctorsDeserialize.Count; r++)
                                            {
                                                if (DoctorsDeserialize[r].Name == n)
                                                {
                                                    Console.WriteLine("____________________________________________________");
                                                    Console.WriteLine(DoctorsDeserialize[r].Name);
                                                    Console.WriteLine(DoctorsDeserialize[r].Surname);
                                                    Console.WriteLine(DoctorsDeserialize[r].Speciality);
                                                    Console.WriteLine("Вік " + DoctorsDeserialize[r].Age);
                                                    Console.WriteLine("____________________________________________________");
                                                    fl++;
                                                }
                                                if (DoctorsDeserialize.Count - r == 1 && fl == 0)
                                                {
                                                    Console.WriteLine("Таких лікарів не знайдено");
                                                }
                                            }
                                            Console.ReadLine();
                                            fw++;
                                            z++;
                                            break;
                                        }
                                    case ("прізвище"):
                                        {
                                            Console.WriteLine("Введіть прізвище: ");
                                            string n = Console.ReadLine();
                                            int fl = 0;
                                            for (int r = 0; r < DoctorsDeserialize.Count; r++)
                                            {
                                                if (DoctorsDeserialize[r].Surname == n)
                                                {
                                                    Console.WriteLine("____________________________________________________");
                                                    Console.WriteLine(DoctorsDeserialize[r].Name);
                                                    Console.WriteLine(DoctorsDeserialize[r].Surname);
                                                    Console.WriteLine(DoctorsDeserialize[r].Speciality);
                                                    Console.WriteLine("Вік " + DoctorsDeserialize[r].Age);
                                                    Console.WriteLine("____________________________________________________");
                                                    fl++;
                                                }
                                                if (DoctorsDeserialize.Count - r == 1 && fl == 0)
                                                {
                                                    Console.WriteLine("Таких лікарів не знайдено");
                                                }
                                            }
                                            Console.ReadLine();
                                            fw++;
                                            z++;
                                            break;
                                        }
                                    case ("спеціальність"):
                                        {
                                            Console.WriteLine("Введіть спеціальність: ");
                                            string n = Console.ReadLine();
                                            int fl = 0;
                                            for (int r = 0; r < DoctorsDeserialize.Count; r++)
                                            {
                                                if (DoctorsDeserialize[r].Speciality == n)
                                                {
                                                    Console.WriteLine("____________________________________________________");
                                                    Console.WriteLine(DoctorsDeserialize[r].Name);
                                                    Console.WriteLine(DoctorsDeserialize[r].Surname);
                                                    Console.WriteLine(DoctorsDeserialize[r].Speciality);
                                                    Console.WriteLine("Вік " + DoctorsDeserialize[r].Age);
                                                    Console.WriteLine("____________________________________________________");
                                                    fl++;
                                                }
                                                if (DoctorsDeserialize.Count - r == 1 && fl == 0)
                                                {
                                                    Console.WriteLine("Таких лікарів не знайдено");
                                                }
                                            }
                                            Console.ReadLine();
                                            fw++;
                                            z++;
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("Неправильно введені дані. Спробуйте ще раз");
                                        break;
                                }
                            }
                           
                            break;
                        }
                    case ("пацієнта"):
                        {
                            Console.WriteLine("Оберіть за чим ви хочете знайти лікаря (ім'я, прізвище чи спеціальність)");
                            for (int fw = 0; fw < 1;)
                            {
                                switch (Console.ReadLine())
                                {
                                    case ("ім'я"):
                                        {

                                            Console.WriteLine("Введіть ім'я: ");
                                            string n = Console.ReadLine();
                                            int fl = 0;
                                            for (int r = 0; r < PatientDeserialize.Count; r++)
                                            {
                                                if (PatientDeserialize[r].Name == n)
                                                {
                                                    Console.WriteLine("____________________________________________________");
                                                    Console.WriteLine(PatientDeserialize[r].Name);
                                                    Console.WriteLine(PatientDeserialize[r].Surname);
                                                    Console.WriteLine("Код " + PatientDeserialize[r].CodeCard);
                                                    Console.WriteLine("Вік " + PatientDeserialize[r].Age);
                                                    Console.WriteLine("____________________________________________________");
                                                    fl++;
                                                }
                                                if (PatientDeserialize.Count - r == 1 && fl == 0)
                                                {
                                                    Console.WriteLine("Таких пацієнтів не знайдено");
                                                }
                                            }
                                            Console.ReadLine();
                                            fw++;
                                            z++;
                                            break;
                                        }
                                    case ("прізвище"):
                                        {
                                            Console.WriteLine("Введіть прізвище: ");
                                            string n = Console.ReadLine();
                                            int fl = 0;
                                            for (int r = 0; r < PatientDeserialize.Count; r++)
                                            {
                                                if (DoctorsDeserialize[r].Surname == n)
                                                {
                                                    Console.WriteLine("____________________________________________________");
                                                    Console.WriteLine(PatientDeserialize[r].Name);
                                                    Console.WriteLine(PatientDeserialize[r].Surname);
                                                    Console.WriteLine("Код " + PatientDeserialize[r].CodeCard);
                                                    Console.WriteLine("Вік " + PatientDeserialize[r].Age);
                                                    Console.WriteLine("____________________________________________________");
                                                    fl++;
                                                }
                                                if (DoctorsDeserialize.Count - r == 1 && fl == 0)
                                                {
                                                    Console.WriteLine("Таких пацієнтів не знайдено");
                                                }
                                            }
                                            Console.ReadLine();
                                            fw++;
                                            z++;
                                            break;
                                        }
                                    case ("код"):
                                        {
                                            Console.WriteLine("Введіть код: ");
                                            string n = Console.ReadLine();
                                            int fl = 0;
                                            for (int r = 0; r < PatientDeserialize.Count; r++)
                                            {
                                                if (PatientDeserialize[r].CodeCard == n)
                                                {
                                                    Console.WriteLine("____________________________________________________");
                                                    Console.WriteLine(PatientDeserialize[r].Name);
                                                    Console.WriteLine(PatientDeserialize[r].Surname);
                                                    Console.WriteLine("Код " + PatientDeserialize[r].CodeCard);
                                                    Console.WriteLine("Вік " + PatientDeserialize[r].Age);
                                                    Console.WriteLine("____________________________________________________");
                                                    fl++;
                                                }
                                                if (PatientDeserialize.Count - r == 1 && fl == 0)
                                                {
                                                    Console.WriteLine("Таких пацієнтів не знайдено");
                                                }
                                            }
                                            Console.ReadLine();
                                            fw++;
                                            z++;
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("Неправильно введені дані. Спробуйте ще раз");
                                        break;
                                }
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("Неправильно введені дані. Спробуйте ще раз");
                        break;
                }
            }
        }
        public static void StartProject()
        {
            defValue();
            Reception rec1 = new Reception(Doctors[0], Patients[0]);
            recept.Add(rec1);
            SerializingDataDoctor();
            SerializingDataPatient();
            DeserializeDoctor();
            DeserializePatient();
            for (int i = 0; i < 1;)
            {

                StartMenu();

                switch (Choice())
                {
                    
                    case ("1"):
                        {
                            DoctorMenu();
                            break;
                        }
                    case ("2"):
                        {
                            PatientMenu();
                            break;
                        }
                    case ("3"):
                        {
                            ReceptionSchedule();
                            break;
                        }
                    case ("4"):
                        {
                            SearchMenu();
                            break;
                        }
                    case ("5"):
                        {
                            i++;
                            break;
                        }
                    default:
                        Console.WriteLine("Неправильно введені дані. Введіть цифру від 1 до 4");
                        break;
                }
            }
        }
    }
}