using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DataValidation;
using System.Text.RegularExpressions;

namespace BLL
{
    [Serializable]
    public class Doctor : BasicCharacteristics
    {
        protected string speciality, recordedPatients;
        protected DateTime startReceiptTime, endReceipTime;
        protected List<DateTime> workTime = new List<DateTime>();
        protected List<string> nonWorkingDays = new List<string>(7);

        public string Speciality
        {
            get { return speciality; }
            set
            {
                if (DataValid.Speciality(value) == true)
                {
                    speciality = value;
                }
                else
                {
                    throw new CatchExceptions("Спеціальність введено неправильно!");
                }
            }
        }
        public void TimeOfReceipt(int startHour, int minutesStert, int endHour, int minuteEnd)
        {
            startReceiptTime = new DateTime(2021, 12, 20, startHour, minutesStert, 0);
            endReceipTime = new DateTime(2021, 12, 20, endHour, minuteEnd, 0);
            if(startReceiptTime > endReceipTime)
            {
                endReceipTime = endReceipTime.AddDays(1);
            }           
        }
        public DateTime StartReceiptTime
        {
            get { return startReceiptTime; }
            set { startReceiptTime = value; }
        }
        public DateTime EndReceipTime
        {
            get { return endReceipTime; }
            set { endReceipTime = value; }
        }
        private List<DateTime> WorkTimeFirstDay(int num)
        {           
            List<DateTime> workTimeD = new List<DateTime>();
            workTimeD.Add(startReceiptTime);
            int i = 0;
            while(workTimeD.Last() <= endReceipTime)
            {
                workTimeD.Add(startReceiptTime.AddMinutes(i + 1));
                i++;
            }
            for(int j = 0; j < workTimeD.Count;j++)
            {
                workTimeD[j] = workTimeD[j].AddDays(num);
            }
            return workTimeD;
        }

        public List<DateTime> WorkTimeFilling()
        {
            
            workTime.AddRange(WorkTimeFirstDay(0));
            workTime.AddRange(WorkTimeFirstDay(1));
            workTime.AddRange(WorkTimeFirstDay(2));
            workTime.AddRange(WorkTimeFirstDay(3));
            workTime.AddRange(WorkTimeFirstDay(4));
            workTime.AddRange(WorkTimeFirstDay(5));
            workTime.AddRange(WorkTimeFirstDay(6));
            return workTime;
        }
        public List<DateTime> WorkTime
        {
            get { return workTime; }
        }
        public string StrWorkTime()
        {
            List<string> stWorkTime = new List<string>();
            List<DateTime> dateTimeList = new List<DateTime>();
            int size = WorkTime.Count;
            int val = 1;
            for (int i = 0; i < size; i++)
            {
                if (WorkTime.Count > (i + 1))
                {
                    if (WorkTime[i + val] == WorkTime[i].AddMinutes(val))
                    {
                        if (dateTimeList.Count == 0)
                        {
                            int f = 1;
                            dateTimeList.Add(WorkTime[i]);
                            stWorkTime.Add("Вільний для прийомів час лікаря: \n з " + dateTimeList.Last() + " по");
                            while (true)
                            {
                                if (WorkTime.Count > (i + f))
                                {
                                    if (WorkTime[i + f] == WorkTime[i].AddMinutes(f))
                                    {
                                        dateTimeList.Add(WorkTime[i + f]);
                                        if (WorkTime.Count > (i + f + 1))
                                        {
                                            if (WorkTime[i + f + 1] != WorkTime[i].AddMinutes(f + 1))
                                            {
                                                stWorkTime.Add(dateTimeList.Last() + "\n");
                                                break;
                                            }
                                        }
                                        i++;

                                    }                                    
                                }
                            }
                            i++;
                        }
                        else
                        {
                            int f = 1;
                            dateTimeList.Add(WorkTime[i]);
                            stWorkTime.Add("з " + dateTimeList.Last());
                            while (true)
                            {
                                if (WorkTime.Count > (i + f))
                                {
                                    if (WorkTime[i + f] == WorkTime[i].AddMinutes(f))
                                    {

                                        dateTimeList.Add(WorkTime[i + f]);
                                        if (WorkTime.Count > (i + f + 1))
                                        {
                                            if (WorkTime[i + f + 1] != WorkTime[i].AddMinutes(f + 1))
                                            {
                                                stWorkTime.Add("по " + Convert.ToString(dateTimeList.Last() + "\n"));
                                                break;
                                            }
                                        }
                                        else if (WorkTime.Last() == WorkTime[i + f])
                                        {
                                            stWorkTime.Add("по " + Convert.ToString(dateTimeList.Last() + "\n"));
                                            break;
                                        }
                                        i++;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                                i++;
                            }
                            
                        }

                    }
                    else
                    {
                        i++;
                    }
                }

            }
            string stValue = string.Join(" ", stWorkTime);
            return stValue;
        }
        public string RecordedPatients(List<DateTime> receptions, ElectronicCardPatient patient)
        {
            recordedPatients = "Пацієнт: " + patient.Surname + " " + patient.Name + " " + patient.Patronymic +
                "\nНомер картки: " + patient.CodeCard +
                ";\n Час прийому: " + Convert.ToString(receptions[0]) + " - " +
                Convert.ToString(receptions.Last());
            return recordedPatients;
        }
    }
}