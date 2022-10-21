namespace Vtitbid.ISP20.Kiseleva.Zodiac
{
    public class Program
    {
        static void Main(string[] args)
        {
            Zodiac[] array = Zodiac.Fill(2);
            Zodiac.Output(array);
            Zodiac.Sort(array);
            Zodiac.Search(array);
        }
    }
}

