using static Vtitbid.ISP20.Kiseleva.Bill.Bill;

namespace Vtitbid.ISP20.Kiseleva.Bill
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bill = new Bill();
            var number = bill.InputNumber();
            Bill[] billArr = Bill.Fill(number);
            Console.Clear();
            Bill.Output(billArr);
            Bill.Sort(billArr);
            Bill.Search(billArr);
            static void EndMessage()
            {
                Console.WriteLine("\nПрограмма завершилась успешно"); ;
            }
            //MessageService messageService = new MessageService();
            //messageService.MessageHandler += EndMessage;
            Message mes = new Message(EndMessage);
            mes?.Invoke();
        }
    }
}