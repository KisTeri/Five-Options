namespace Vtitbid.ISP20.Kiseleva.Priсe
{
    public class Program
    {
        static void Main(string[] args)
        {
            var note = new Price();
            var number = note.InputNumber();
            Price[] array = Price.FillAndCheck(number);
            Price.Sort(array);
            Price.Search(array);
        }
    }
}