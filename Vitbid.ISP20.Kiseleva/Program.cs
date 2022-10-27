namespace Vtitbid.ISP20.Kiseleva.Zodiac
{
    public class Program
    {
        static void Main(string[] args)
        {
            var zodiac = new Zodiac();
            var number = zodiac.InputNumber();
            Zodiac[] array = Zodiac.FillAndCheck(number);
            Console.Clear();
            Zodiac.Output(array);
            Zodiac.Sort(array);
            Zodiac.Search(array);
        }
    }
}

