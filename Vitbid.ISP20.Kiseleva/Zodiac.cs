using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Kiseleva.Zodiac
{
    public class Zodiac
    {
        public string _name = "";
        public string _surname = "";
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
                    Regex expressionAph = new Regex(@"^[a-zA-Z]+|[а-яА-Я]+$");
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
                    Regex expressionAph = new Regex(@"^[a-zA-Z]+|[а-яА-Я]+$");
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
        public DateOfBirthZodiac DateOfBirthZodiac { get; set;}
       
        public string ZodiacSign { get; set; }
        public Zodiac(string firstName, string lastName, DateOfBirthZodiac dateOfBirthZodiac)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirthZodiac = dateOfBirthZodiac;
        }
        public Zodiac(string firstName, string lastName, DateOfBirthZodiac dateOfBirthZodiac, string zodiacSign)
            : this(firstName, lastName, dateOfBirthZodiac)
        {
            ZodiacSign = zodiacSign;

        }
        public Zodiac() { }
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
        public static Zodiac[] Fill(int count)
        {
            Zodiac[] array = new Zodiac[count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Zodiac();
                array[i].DateOfBirthZodiac = new DateOfBirthZodiac();

                Console.Write("Введите имя: ");
                array[i].FirstName = Console.ReadLine();

                Console.Write("Введите фамилию: ");
                array[i].LastName = Console.ReadLine();
                
                Console.Write("Введите день(формат: цифра): ");
                array[i].DateOfBirthZodiac.Day = Convert.ToInt16(Console.ReadLine());
                
                Console.Write("Введите месяц(формат: цифра): ");
                array[i].DateOfBirthZodiac.Month = Convert.ToInt32(Console.ReadLine());
                
                Console.Write("Введите год(формат: цифра): ");
                array[i].DateOfBirthZodiac.Year = Convert.ToInt32(Console.ReadLine());
                
                GetSign(array[i]);
                Console.WriteLine();
            }
            return array;
        }
        public static void Output(Zodiac[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Имя: {array[i].FirstName}; Фамилия: {array[i].LastName}; Дата рождения: {array[i].DateOfBirthZodiac.Day}.{array[i].DateOfBirthZodiac.Month}.{array[i].DateOfBirthZodiac.Year}г; Знак зодиака: {array[i].ZodiacSign}");
            }
        }
        public static void GetSign(Zodiac array)
        {
            switch (array.DateOfBirthZodiac.Month)
            {
                case 1:
                        if (array.DateOfBirthZodiac.Day < 20)
                        {
                            array.ZodiacSign = "Знак зодиака: Козерог";
                        }
                        else
                            array.ZodiacSign = "Знак зодиака: Водолей";
                    break;
                case 2:
                        if (array.DateOfBirthZodiac.Day < 19)
                        {
                            array.ZodiacSign = "Знак зодиака: Водолей";
                        }
                        else
                            Console.WriteLine("Знак зодиака: Рыбы");
                    break;
                case 3:
                        if (array.DateOfBirthZodiac.Day < 20)
                        {
                            array.ZodiacSign = "Знак зодиака: Рыбы";
                        }
                        else
                            array.ZodiacSign = "Знак зодиака: Овен";
                    break;
                case 4:
                        if (array.DateOfBirthZodiac.Day < 20)
                        {
                            array.ZodiacSign = "Знак зодиака: Овен";
                        }
                        else
                            array.ZodiacSign = "Знак зодиака: Телец";
                    break;
                case 5:
                        if (array.DateOfBirthZodiac.Day < 21)
                        {
                            array.ZodiacSign = "Знак зодиака: Телец";
                        }
                        else
                            array.ZodiacSign = "Знак зодиака: Близнецы";
                    break;
                case 6:
                        if (array.DateOfBirthZodiac.Day < 21)
                        {
                            array.ZodiacSign = "Знак зодиака: Близнецы";
                        }
                        else
                            array.ZodiacSign = "Знак зодиака: Рак";
                    break;
                case 7:
                        if (array.DateOfBirthZodiac.Day < 22)
                        {
                            array.ZodiacSign = "Знак зодиака: Рак";
                        }
                        else
                            array.ZodiacSign = "Знак зодиака: Лев";
                    break;
                case 8:
                        if (array.DateOfBirthZodiac.Day < 23)
                        {
                            array.ZodiacSign = "Знак зодиака: Лев";
                        }
                        else
                            array.ZodiacSign = "Знак зодиака: Дева";
                    break;
                case 9:
                        if (array.DateOfBirthZodiac.Day < 23)
                        {
                            array.ZodiacSign = "Знак зодиака: Дева";
                        }
                        else
                            array.ZodiacSign = "Знак зодиака: Весы";
                    break;
                case 10:
                    if (array.DateOfBirthZodiac.Day < 23)
                    {
                        array.ZodiacSign = "Знак зодиака: Весы";
                    }
                    else
                        array.ZodiacSign = "Знак зодиака: Скорпион";
                    break;
                case 11:
                    if (array.DateOfBirthZodiac.Day < 22)
                    {
                        array.ZodiacSign = "Знак зодиака: Скорпион";
                    }
                    else
                        array.ZodiacSign = "Знак зодиака: Стрелец";
                    break;
                case 12:
                    if (array.DateOfBirthZodiac.Day < 22)
                    {
                        array.ZodiacSign = "Знак зодиака: Стрелец";
                    }
                    else
                        array.ZodiacSign = "Знак зодиака: Козерог";
                    break;
            }
        }
        public static void Sort(Zodiac[] array)
        {
            Console.WriteLine();
            Console.WriteLine("Отсортированные записи:");
            var sortedZodiac = from p in array
                               orderby p.LastName
                               select p;
            foreach (var p in sortedZodiac)
                Console.WriteLine($"\nИмя: {p.FirstName}; Фамилия: {p.LastName}; Дата рождения: {p.DateOfBirthZodiac.Day}.{p.DateOfBirthZodiac.Month}.{p.DateOfBirthZodiac.Year}г. Знак зодиака: {p.ZodiacSign}");
        }
        public static void Search(Zodiac[] array)
        {
            Console.Write("\nВведите фамилию искомого человека: ");
            string strLastName = Console.ReadLine();
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (strLastName == array[i].LastName)
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine($"\nТакого человека не нашлось \n");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (strLastName == array[i].LastName)
                {
                    Console.WriteLine($"Имя: {array[i].FirstName}; Фамилия: {array[i].LastName}; Дата рождения: {array[i].DateOfBirthZodiac.Day}.{array[i].DateOfBirthZodiac.Month}.{array[i].DateOfBirthZodiac.Year}г. Знак зодиака: {array[i].ZodiacSign}");
                }
            }
        }
    }
}
