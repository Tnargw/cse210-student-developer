using System;
using System.Collections.Generic;

namespace Jumper.Game
{
    
    public class Words
    {
        public TerminalService _terminalService = new TerminalService();
        public List<string> _words = new List<string>();  
        public string _finalWord = "";
        public int _finalLength;

        private int n;
        public string [] blankArray;

        public Words()
        {
            _words.Add("crosswalk");
            _words.Add("architecture");
            _words.Add("chicken");
            _words.Add("achieve");
            _words.Add("monarch");
            _words.Add("behave");
            _words.Add("difficult");
            _words.Add("daughter");
            _words.Add("routine");
            _words.Add("connection");
            _words.Add("piano");
            _words.Add("captivate");
            _words.Add("maximum");
            _words.Add("broken");
            _words.Add("gallery"); 

            Random random = new Random();
            _finalWord = _words[random.Next(1, 16)];
            Length();
            MakeBlankArray();
        }

        private int Length()
        {
            _finalLength = _finalWord.Length;
            return _finalLength;
        }

        public string [] MakeBlankArray()
        {
            n = _finalLength;
            int index = 0;
            String[] blankArray = new string [n];
            foreach(char ch in _finalWord)
            {
                blankArray[index] = "_";
                index++;
            }
            return blankArray;
        }

        
    }
}



