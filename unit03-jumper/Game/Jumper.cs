using System;
using System.Collections.Generic;

namespace Jumper.Game
{
    public class Jumper
    {
        TerminalService _terminalService = new TerminalService();
        public int bad_guess = 0;
        public List<string> jumpermanboi = new List<string>(); 
        public Jumper()
        {
            Jumperman();
    
        }

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

        public void PrintJumper()
        {
            for(int i=0;i<jumpermanboi.Count;i++)
            {
            Console.WriteLine(jumpermanboi[i]);
            }
        }

    }
}