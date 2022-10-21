using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Vtitbid.ISP20.Kiseleva.Route
{
    public class Route
    {
        public string _beginingRoute = "";
        public string _endingRoute = "";
        public int _routeNumber = 0;
        public string BeginingRoute
        {
            get
            {
                return _beginingRoute;
            }

            set
            {
                try
                {
                    Regex expressionAph = new Regex(@"^[a-zA-Z]+|[а-яА-Я]+$");
                    if (expressionAph.IsMatch(value))
                    {
                        _beginingRoute = value;
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
        public string EndingRoute
        {
            get
            {
                return _endingRoute;
            }

            set
            {
                try
                {
                    Regex expressionAph = new Regex(@"^[a-zA-Z]+|[а-яА-Я]+$");
                    if (expressionAph.IsMatch(value))
                    {
                        _endingRoute = value;
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
        public int RouteNumber
        {
            get
            {
                return _routeNumber;
            }
            set
            {
                try
                {
                    Regex expressionNum = new Regex(@"^\d+$");
                    if (expressionNum.IsMatch(Convert.ToString(value)))
                    {
                        _routeNumber = value;
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
        public Route() { }
        public Route(string beginingRoute, string endingRoute, int routeNumber)
        {
            BeginingRoute = beginingRoute;
            EndingRoute = endingRoute;
            RouteNumber = routeNumber;
        }
        public static Route[] Fill(int count)
        {
            Route[] array = new Route[count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Route();
                Console.Write("Начальный пункт маршрута: ");
                array[i].BeginingRoute = Console.ReadLine();

                Console.Write("Конечный пункт маршрута: ");
                array[i].EndingRoute = Console.ReadLine();

                Console.Write("Номер маршрута: ");
                array[i].RouteNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
            }
            return array;
        }
        public static void Output(Route[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"\nНачальный пункт: {array[i].BeginingRoute}\nКонечный пункт: {array[i].EndingRoute}\nНомер маршрута {array[i].RouteNumber}");
            }
        }
        public static void Sort(Route[] array)
        {
            var sortedRoute = from p in array
                              orderby p.RouteNumber
                              select p;

            foreach (var p in sortedRoute)
                Console.WriteLine($"\nНачальный пункт: {p.BeginingRoute}\nКонечный пункт: {p.EndingRoute}\nНомер маршрута {p.RouteNumber}");
        }
        public static void Search(Route[] array)
        {
            Console.Write("Введите начальный либо конечный пункт для поиска маршрута: ");
            string a = Console.ReadLine();
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (a == array[i].BeginingRoute || a == array[i].EndingRoute)
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"\nТакого маршрута не существует \n");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (a == array[i].BeginingRoute || a == array[i].EndingRoute)
                {
                    Console.WriteLine($"\nНачальный пункт: {array[i].BeginingRoute}\nКонечный пункт: {array[i].EndingRoute}\nНомер маршрута {array[i].RouteNumber}");
                }
            }
        }
    }
}