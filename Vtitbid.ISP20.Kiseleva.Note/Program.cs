using System;

namespace Vtitbid.ISP20.Kiseleva.Note
{
    public class Program
    {
        static void Main(string[] args)
        {
            Note[] noteArr = Note.Fill(2);
            Console.Clear();

            for (int i = 0; i < noteArr.Length; i++)
            {
                Console.WriteLine(noteArr[i]);
            }
            Note.Sort(noteArr);
            Note.Search(noteArr);
        }
    }
}