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
        }
    }
}