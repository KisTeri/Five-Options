namespace Vtitbid.ISP20.Kiseleva.Priсe
{
    public class Program
    {
        static void Main(string[] args)
        {
            Price[] array = Price.Fill(2);
            Price.Sort(array);
            Price.Search(array);
        }
    }
}