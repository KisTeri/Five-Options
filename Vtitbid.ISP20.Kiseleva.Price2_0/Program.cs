namespace Vtitbid.ISP20.Kiseleva.Price2_0
{
    public class Program
    {
        static void Main(string[] args)
        {
            var note = new Price2_0();
            var number = note.InputNumber();
            Price2_0[] array = Price2_0.FillAndCheck(number);
            Console.Clear();
            Price2_0.Sort(array);
            Price2_0.Search(array);
        }
    }
}
