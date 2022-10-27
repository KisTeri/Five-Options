using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Kiseleva.Zodiac
{
    public class DateOfBirthZodiac
    {
        private int _day = 0;
        public int Day
        {
            get
            {
                return _day;
            }

            set
            {

                try
                {
                    Regex expressionNum = new Regex(@"^\d+$");
                    if (value >= 1 && value <= 31 && expressionNum.IsMatch(Convert.ToString(value)))
                    {
                        _day = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода даты");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }

            }
        }

        private int _month = 0;
        public int Month
        {
            get
            {
                return _month;
            }

            set
            {
                try
                {
                    Regex expressionNum = new Regex(@"^\d+$");
                    if (value >= 1 && value <= 12 && expressionNum.IsMatch(Convert.ToString(value)))
                    {
                        _month = value;

                    }
                    else
                    {
                        throw new Exception("Ошибка ввода даты");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }
            }


        }

        private int _year = 0;
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {

                try
                {
                    Regex expressionNum = new Regex(@"^\d+$");
                    if (value >= 1900 && value <= 2022 && expressionNum.IsMatch(Convert.ToString(value)))
                    {
                        _year = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода даты");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }

            }
        }

        public DateOfBirthZodiac() { }
        public DateOfBirthZodiac(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;

        }
        public static bool DateCheck(int Day, int Month, int Year)
        {
            bool result = false;
            switch (Month)
            {
                case 1:
                    if (Day <= 31 && Day != 0)
                    {
                        result = true;
                    }
                    break;
                case 2:
                    if ((Day != 0 && Day <= 28 && Year % 4 == 1))
                    {
                        result = true;
                    }
                    if (Day != 0 && Day <= 29 && ((Year % 4 == 0 && Year % 100 != 0) || Year % 400 == 0))
                    {
                        result = true;
                    }
                    break;
                case 3:
                    if (Day <= 31 && Day != 0)
                    {
                        result = true;
                    }
                    break;
                case 4:
                    if (Day <= 30 && Day != 0)
                    {
                        result = true;
                    }
                    break;
                case 5:
                    if (Day <= 31 && Day != 0)
                    {
                        result = true;
                    }
                    break;
                case 6:
                    if (Day <= 30 && Day != 0)
                    {
                        result = true;
                    }
                    break;
                case 7:
                    if (Day <= 31 && Day != 0)
                    {
                        result = true;
                    }
                    break;
                case 8:
                    if (Day <= 31 && Day != 0)
                    {
                        result = true;
                    }
                    break;
                case 9:
                    if (Day <= 30 && Day != 0)
                    {
                        result = true;
                    }
                    break;
                case 10:
                    if (Day <= 31 && Day != 0)
                    {
                        result = true;
                    }
                    break;
                case 11:
                    if (Day <= 30 && Day != 0)
                    {
                        result = true;
                    }
                    break;
                case 12:
                    if (Day <= 31 && Day != 0)
                    {
                        result = true;
                    }
                    break;
            }
            return result;
        }
    }
}