using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Kiseleva.Price2_0
{
    public class Price2_0
    {
        public string _name = "";
        public string _shop = "";
        public decimal _price = 0;
        public string GoodName
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
                        throw new Exception("Ошибка ввода наименования товара");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }
            }
        }
        public string ShopName
        {
            get
            {
                return _shop;
            }

            set
            {
                try
                {
                    Regex expressionAph = new Regex(@"^[a-zA-Z]+|[а-яА-Я]+$");
                    if (expressionAph.IsMatch(value))
                    {
                        _shop = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода названия магазина");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }
            }
        }
        public decimal GoodPrice
        {
            get
            {
                return _price;
            }
            set
            {
                try
                {
                    Regex expressionNum = new Regex(@"^\d+$");
                    if (expressionNum.IsMatch(Convert.ToString(value)))
                    {
                        _price = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода названия магазина");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }
            }

        }
        public Price2_0() { }
        public Price2_0(string goodName, string shopName, decimal goodPrice)
        {
            GoodName = goodName;
            ShopName = shopName;
            GoodPrice = goodPrice;
        }
        public static Price2_0[] Fill(int count)
        {
            Price2_0[] array = new Price2_0[count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Price2_0();

                Console.Write("Наименование товара: ");
                array[i].GoodName = Console.ReadLine();

                Console.Write("Название магазина: ");
                array[i].ShopName = Console.ReadLine();

                Console.Write("Цена товара: ");
                array[i].GoodPrice = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine();
            }
            return array;
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
        public static void Sort(Price2_0[] array)
        {
            Console.WriteLine();
            Console.WriteLine("Отсортированные записи:");
            var sortedShop = from p in array
                             orderby p.ShopName
                             select p;
            foreach (var p in sortedShop)
                Console.WriteLine($"Наименование товара: {p.GoodName}\nНазвание магазина: {p.ShopName}\nЦена товара: {p.GoodPrice}\n");
        }
        public static void Search(Price2_0[] array)
        {
            Console.Write("Введите наименование магазина для поиска: ");
            string name = Console.ReadLine();
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (name == array[i].ShopName)
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"\nТакого магазина нет \n");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (name == array[i].ShopName)
                {
                    Console.WriteLine($"\nНаименование товара: {array[i].GoodName}\nНазвание магазина: {array[i].ShopName}\nЦена товара: {array[i].GoodPrice}");
                }
            }
        }
    }
}
