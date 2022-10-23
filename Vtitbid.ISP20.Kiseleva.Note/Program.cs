using System;

namespace Vtitbid.ISP20.Kiseleva.Note
{
    public class Program
    {
        static void Main(string[] args)
        {
            var note = new Note();
            var number = note.InputNumber();
            Note[] noteArr = Note.Fill(number);
            Console.Clear();
            Note.Output(noteArr);
            Note.Sort(noteArr);
            Note.Search(noteArr);
        }
    }
}