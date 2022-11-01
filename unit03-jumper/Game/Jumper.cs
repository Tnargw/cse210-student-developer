using System;
using System.Collections.Generic;

namespace Jumper.Game
{

    // Creates and controls the jumper guy.
    public class Jumper
    {
        TerminalService _terminalService = new TerminalService();
        public int bad_guess = 0;
        public List<string> jumpermanboi = new List<string>(); 
        public Jumper()
        {
            Jumperman();
    
        }

        // Creates a List to be output as the JumperMan.
        public List<string> Jumperman()
        {
            jumpermanboi.Add(" ___ ");
            jumpermanboi.Add("/___\\ ");
            jumpermanboi.Add("\\   / ");
            jumpermanboi.Add(" \\ / ");
            jumpermanboi.Add("  0 ");
            jumpermanboi.Add(" /|\\");
            jumpermanboi.Add(" / \\");
            jumpermanboi.Add(" ");
            jumpermanboi.Add("______");

            return jumpermanboi;

        }

        // Prints the JumperMan.
        public void PrintJumper()
        {
            for(int i=0;i<jumpermanboi.Count;i++)
            {
            Console.WriteLine(jumpermanboi[i]);
            }
        }

    }
}