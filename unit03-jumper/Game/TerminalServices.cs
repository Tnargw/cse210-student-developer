using System;
namespace Jumper.Game
{
    public class TerminalService
    {
        public TerminalService()
        {
        }

        public int ReadNumber(string prompt)
        {
            string rawValue = ReadText(prompt);
            return int.Parse(rawValue, System.Globalization.CultureInfo.InvariantCulture);
        }

        public string ReadText(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public void WriteText(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteNumber(int number)
        {
            Console.WriteLine(number);
        }

        public void WriteArray(string [] array)
        {
            Console.WriteLine("{0}", string.Join(" ", array));
        }

        public void WriteListInline(string list)
        {
            Console.WriteLine("Previous Guesses: " + list);
        }

    }
}