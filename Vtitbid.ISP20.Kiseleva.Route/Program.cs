namespace Vtitbid.ISP20.Kiseleva.Route
{
    public class Program
    {
        static void Main(string[] args)
        {
            var note = new Route();
            var number = note.InputNumber();
            Route[] array = Route.FillAndCheck(number);
            Console.Clear();
            Route.Output(array);
            Route.Sort(array);
            Route.Search(array);
        }
    }
}