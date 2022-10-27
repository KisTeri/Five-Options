using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Kiseleva.Priсe
{
    public class Price
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
        public Price() { }
        public Price(string goodName, string shopName, decimal goodPrice)
        {
            GoodName = goodName;
            ShopName = shopName;
            GoodPrice = goodPrice;
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
        public static Price[] FillAndCheck(int count)
        {
            Price[] priceArr = new Price[count];
            for (int i = 0; i < priceArr.Length; i++)
            {
                priceArr[i] = new Price();

                Console.Write("Наименование товара: ");
                priceArr[i].GoodName = Console.ReadLine();

                Console.Write("Название магазина: ");
                priceArr[i].ShopName = Console.ReadLine();

                Console.Write("Цена товара: ");
                var priceInput = Console.ReadLine();
                bool priceNumber = int.TryParse(priceInput, out var price);
                try
                {
                    if (priceNumber)
                    {
                        priceArr[i].GoodPrice = price;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода цены");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }

                Console.WriteLine();
            }
            return priceArr;
        }
        public static void Sort(Price[] priceArr)
        {
            Console.WriteLine();
            Console.WriteLine("Отсортированные записи:");
            var sortedGood = from p in priceArr
                             orderby p.GoodName
                             select p;

            foreach (var p in sortedGood)
                Console.WriteLine($"Наименование товара: {p.GoodName}\nНазвание магазина: {p.ShopName}\nЦена товара: {p.GoodPrice}\n");
        }
        public static void Search(Price[] priceArr)
        {
            Console.Write("Введите наименование товара для поиска: ");
            string name = Console.ReadLine();
            int counter = 0;

            for (int i = 0; i < priceArr.Length; i++)
            {
                if (name == priceArr[i].GoodName)
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"\nТакого товара нет \n");
            }

            for (int i = 0; i < priceArr.Length; i++)
            {
                if (name == priceArr[i].GoodName)
                {
                    Console.WriteLine($"\nНаименование товара: {priceArr[i].GoodName}\nНазвание магазина: {priceArr[i].ShopName}\nЦена товара: {priceArr[i].GoodPrice}");
                }
            }
        }
    }
}
