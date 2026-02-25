

using System.ComponentModel.Design;

namespace QuizMaker;

class Program
{
    public static void Main(string[] args)
    {
        ConsoleUI.DisplayWelcomeMessage();
        bool runningQuiz = true;
        while (runningQuiz)
        {
            ConsoleUI.DisplayMenu();
            int selection = ConsoleUI.GetUserSelection();

            switch (selection)
            {
                case 1:
                    Logic.QuizMaker();
                    break;
                case 2:
                    Logic.PlayQuiz();
                    break;
                case 3:
                    Logic.Exit();
                    break;
                default:
                    ConsoleUI.InvalidSelection();
                    break;
            }
        }
    }
    
}