

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
                    string question = ConsoleUI.Question();
                    string correct = ConsoleUI.GetCorrectAnswer();
                    string wrong1 = ConsoleUI.IncorrectAnswer1();
                    string wrong2 = ConsoleUI.IncorrectAnswer2();
                    Logic.CreateQuiz(question, correct, wrong1, wrong2);
                    break;
                case Constants.CHOOSE_QUIZ_TO_PLAY:
                    Logic.PlayQuiz();
                    break;
                case Constants.EXIT:
                    Logic.ExitApp();
                    runningQuiz = false;
                    break;
                default:
                    ConsoleUI.InvalidSelection();
                    break;
            }
        }
    }
    
}