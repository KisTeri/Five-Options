namespace Vtitbid.ISP20.Kiseleva.Route
{
    public class Program
    {
        static void Main(string[] args)
        {
            Route[] array = Route.Fill(2);
            Route.Output(array);
            Route.Sort(array);
            Route.Search(array);
        }
    }
}