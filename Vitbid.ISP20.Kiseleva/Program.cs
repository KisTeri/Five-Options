namespace Vtitbid.ISP20.Kiseleva.Zodiac
{
    public class Program
    {
        static void Main(string[] args)
        {
            var zodiac = new Zodiac();
            var number = zodiac.InputNumber();
            Zodiac[] array = Zodiac.Fill(number);
            Console.Clear();
            Zodiac.Output(array);
            Zodiac.Sort(array);
            Zodiac.Search(array);
        }
    }
}

