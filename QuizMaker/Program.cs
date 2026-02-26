

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
                case Constants.CREATE_QUIZ:
                    Logic.QuizMaker();
                    break;
                case Constants.CHOOSE_QUIZ_TO_PLAY:
                    Logic.PlayQuiz();
                    break;
                case Constants.EXIT:
                    Logic.Exit();
                    runningQuiz = false;
                    break;
                default:
                    ConsoleUI.InvalidSelection();
                    break;
            }
        }
    }
    
}