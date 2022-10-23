using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Vtitbid.ISP20.Kiseleva.Note
{
    public class Note
    {
        private string _name = "";

        private string _surname = "";

        private string _tempPhone = "";
        public string FirstName
        {
            get
            {
                return _name;
            }
            set
            {
                try
                {
                    Regex expressionAph = new Regex(@"^[pNumber-zA-Z]+|[а-яА-Я]+$");
                    if (expressionAph.IsMatch(value))
                    {
                        _name = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода имени");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }
            }
        }
        public string LastName
        {
            get
            {
                return _surname;
            }
            set
            {
                try
                {
                    Regex expressionAph = new Regex(@"^[pNumber-zA-Z]+|[а-яА-Я]+$");
                    if (expressionAph.IsMatch(value))
                    {
                        _surname = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода имени");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return _tempPhone;
            }

            set
            {
                try
                {
                    Regex expressionNum = new Regex(@"^\d+$");
                    if ((value.Length == 11) && (expressionNum.IsMatch(value)))
                    {
                        _tempPhone = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода номера телефона");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }
            }
        }
        public DateOfBirth DateOfBirth { get; set; }
        public Note() { }
        public Note(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
        public int InputNumber()
        {
            Console.Write("Введите необходимое количество записей(формат: цифра): ");
            string? information = Console.ReadLine();
            Console.Clear();
            bool result = int.TryParse(information, out var numberFirst);
            try
            {
                if (result == true)
                {
                    Console.WriteLine($"Количество записей: {numberFirst}");
                }
                else
                {
                    throw new Exception("Ошибка ввода количества записей");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Environment.Exit(0);
            }
            return numberFirst;
        }
        public static Note[] Fill(int count)
        {
            Note[] array = new Note[count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Note();
                array[i].DateOfBirth = new DateOfBirth();

                Console.Write("Введите имя: ");
                array[i].FirstName = Console.ReadLine();

                Console.Write("Введите фамилию: ");
                array[i].LastName = Console.ReadLine();

                Console.Write("Введите номер телефона(формат: цифра): ");
                array[i].PhoneNumber = Console.ReadLine();

                Console.Write("Введите день(формат: цифра): ");
                array[i].DateOfBirth.Day = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите месяц(формат: цифра): ");
                array[i].DateOfBirth.Month = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите год(формат: цифра): ");
                array[i].DateOfBirth.Year = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
            }
            return array;
        }
        public static void Output(Note[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Имя: {array[i].FirstName}; Фамилия: {array[i].LastName}; Номер телефона: {array[i].PhoneNumber}; Дата рождения: {array[i].DateOfBirth.Day}.{array[i].DateOfBirth.Month}.{array[i].DateOfBirth.Year}г.");
            }
        }
        public static void Sort(Note[] array)
        {
            Console.WriteLine();
            Console.WriteLine("Отсортированные записи:");
            var sortedNote = from p in array
                             orderby p.LastName
                             select p;
            foreach (var p in sortedNote)
                Console.WriteLine($"Имя: {p.FirstName}; Фамилия: {p.LastName}; Номер телефона: {string.Format("{0:+# (###) ###-##-##}", Convert.ToInt64(p.PhoneNumber))}; {p.DateOfBirth}");
            Console.WriteLine();
        }
        public static void Search(Note[] array)
        {
            Console.Write("Введите номер телефона искомого человека: ");
            string pNumber = Console.ReadLine();
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (pNumber == array[i].PhoneNumber)
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"\nТакого человека не найдено \n");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (pNumber == array[i].PhoneNumber)
                {
                    Console.WriteLine($"Имя: {array[i].FirstName}; Фамилия: {array[i].LastName}; Номер телефона: {string.Format("{0:+# (###) ###-##-##}", Convert.ToInt64(array[i].PhoneNumber))};{array[i].DateOfBirth}");
                }
            }
        }
    }
}
