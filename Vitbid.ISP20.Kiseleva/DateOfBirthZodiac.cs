using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
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
                    if (value >= 1 && value <= 31)
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
                    if (value >= 1 && value <= 12)
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
                    if (value >= 1900 && value <= 2022)
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
    }
}