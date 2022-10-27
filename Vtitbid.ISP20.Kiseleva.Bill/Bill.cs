using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Kiseleva.Bill
{
    public delegate void Message();
    public class Bill
    {
        private string _payerAccount = "";
        private string _payeeAccount = "";
        private decimal _sum = 0;

        public string PayerAccount  //плательщик
        {
            get
            {
                return _payerAccount;
            }
            set
            {
                try
                {
                    Regex expressionNum = new Regex(@"^\d+$");
                    if (value.Length == 10 && expressionNum.IsMatch(value))
                    {
                        _payerAccount = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода счета плательщика");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }
            }
        }
        public string PayeeAccount  //получатель
        {
            get
            {
                return _payeeAccount;
            }
            set
            {
                try
                {
                    Regex expressionNum = new Regex(@"^\d+$");
                    if (value.Length == 10 && expressionNum.IsMatch(value))
                    {
                        _payeeAccount = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода счета получателя");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }
            }
        }
        public decimal Sum
        {
            get
            {
                return _sum;
            }

            set
            {
                try
                {
                    Regex expressionNum = new Regex(@"^\d+$");
                    if (value != 0 && expressionNum.IsMatch(Convert.ToString(value)))
                    {
                        _sum = value;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода суммы для перевода");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }
            }
        }

        public Bill(string payerAccount, string payeeAccount, decimal sum)
        {
            PayerAccount = payerAccount;
            PayeeAccount = payeeAccount;
            Sum = sum;
        }

        public Bill() { }

        public int InputNumber()
        {
            Message mes = new Message(InputNumberForChoice);
            mes?.Invoke();
            //MessageService messageService = new MessageService();
            //messageService.MessageHandler += InputNumberForChoice;
            
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
        public void InputNumberForChoice()
        {
            Console.Write("Введите необходимое количество записей(формат: цифра): ");
        }
        public static Bill[] Fill(int count)
        {
            Bill[] array = new Bill[count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Bill();

                Console.Write("Введите расчетный счет плательщика(10 цифр): ");
                array[i].PayerAccount = Console.ReadLine();

                Console.Write("Введите расчетный счет получателя(10 цифр): ");
                array[i].PayeeAccount = Console.ReadLine();

                Console.Write("Введите сумму для перевода(формат: цифра): ");
                var sumInput = Console.ReadLine();
                bool sumNumber = int.TryParse(sumInput, out var sum);

                try
                {
                    if (sumNumber)
                    {
                        array[i].Sum = sum;
                    }
                    else
                    {
                        throw new Exception("Ошибка ввода суммы");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Environment.Exit(0);
                }

                Console.WriteLine();
            }
            return array;
        }
        public static void Output(Bill[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Расчетный счет плательщика: {array[i].PayerAccount}; Расчетный счет получателя: {array[i].PayeeAccount}; Перечисляемая сумма {array[i].Sum}");
            }
        }
        public static void Sort(Bill[] array)
        {
            Console.WriteLine();
            Console.WriteLine("Отсортированные записи:");
            var sortedBill = from p in array
                             orderby p.PayerAccount
                             select p;
            foreach (var p in sortedBill)
                Console.WriteLine($"Расчетный счет плательщика: {p.PayerAccount}; Расчетный счет получателя: {p.PayeeAccount}; Перечисляемая сумма: {p.Sum}");
            Console.WriteLine();
        }
        public static void Search(Bill[] array)
        {
            Console.Write("Введите расчетный счет плательщика для поиска: ");
            string payerAcc = Console.ReadLine();
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (payerAcc == array[i].PayerAccount)
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"\nТакого счета не найдено \n");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (payerAcc == array[i].PayerAccount)
                {
                    Console.WriteLine($"\nРасчетный счет плательщика: {array[i].PayerAccount}; Перечисляемая сумма: {array[i].Sum}");
                }
            }
        }
    }
}
