using System;
namespace Jumper.Game
{
    // Reads and Writes to the terminal.
    public class TerminalService
    {
        public TerminalService()
        {
        }

        // Reads int input.
        public int ReadNumber(string prompt)
        {
            string rawValue = ReadText(prompt);
            return int.Parse(rawValue, System.Globalization.CultureInfo.InvariantCulture);
        }

        // Reads text/string input.
        public string ReadText(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        // Writes any string or text to the console.
        public void WriteText(string text)
        {
            Console.WriteLine(text);
        }

        // Writes any numebers to console.
        public void WriteNumber(int number)
        {
            Console.WriteLine(number);
        }

        // Writes an array to console.
        public void WriteArray(string [] array)
        {
            Console.WriteLine("{0}", string.Join(" ", array));
        }

        // Outputs the users guesses.
        public void WriteListInline(string list)
        {
            Console.WriteLine("Previous Guesses: " + list);
        }

    }
}