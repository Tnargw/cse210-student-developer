using System.Collections.Generic;
using System.Linq;
namespace Jumper.Game
{    public class Director
    {
        public TerminalService _terminalService = new TerminalService();
        Jumper _jumper = new Jumper();
        public Words _wordToGuess = new Words();
        List<string> userGuesses = new List<string>();
        private bool stillPlaying = true;
        public string userGuess = "";
        private int counter = 0;
        private string [] blankArray;
        public Director()
        {

        }
        public void RunGame()
        {  
            _terminalService.WriteText(_wordToGuess._finalWord);
            while(stillPlaying)
            {
                GetInput();
                ApplyUserInput();
                DetermineWin();
            }
        }

        public void GetInput()
        {
            if(counter == 0)
            {
                blankArray = _wordToGuess.MakeBlankArray();
            }
            _terminalService.WriteArray(blankArray);
            _terminalService.WriteText("");
            _jumper.PrintJumper();
            _terminalService.WriteText("");
            userGuess = _terminalService.ReadText("guess any letter [a-z] ");
            CheckInput();
            counter = counter + 1;

        }

        public void CheckInput()
        {
            char ch;
            int i;
            bool isLetter;
            bool isNotNum;
            isLetter = char.TryParse(userGuess, out ch);
            isNotNum = int.TryParse(userGuess, out i);
            if (isNotNum || !isLetter || userGuesses.Contains(userGuess))
            {
                _terminalService.WriteText("That Guess doesn't work.");
                _terminalService.WriteText("Please enter a valid Guess.");
                GetInput();
            }
        }

        private void ApplyUserInput()
        {
            string GoalWord = _wordToGuess._finalWord;
            int start = 0;
            int index;
            bool index1 = GoalWord.Contains(userGuess);
            if(index1)
                while ((index = GoalWord.IndexOf(userGuess, start)) >= 0)
                {
                    blankArray[index] = userGuess;
                    start = index + 1;
                }
            else
            {
                _jumper.jumpermanboi.RemoveAt(0);
            }
            int lostgame = 4;
            if(lostgame == _jumper.jumpermanboi.Count())
            {
                _terminalService.WriteText("  X ");
                _terminalService.WriteText(" /|\\");
                _terminalService.WriteText(" / \\");
                _terminalService.WriteText(" ");
                _terminalService.WriteText("______");
                _terminalService.WriteText("You lose.");
                stillPlaying = false;
            }
        }

        private void DetermineWin()
        {
            if(!blankArray.Contains("_"))
            {
                _terminalService.WriteArray(blankArray);
                _terminalService.WriteText("You win!");
                stillPlaying = false;
            }
        }

    }
}