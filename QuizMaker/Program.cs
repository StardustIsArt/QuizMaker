

namespace QuizMaker;

static class Program
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
                    Quiz newQuiz = new Quiz();
                    bool addingQuestions = true;
                    while (addingQuestions)
                    {
                        string question = ConsoleUI.Question();
                        string correct = ConsoleUI.GetCorrectAnswer();
                        List<string> wrongAnswers = new List<string>();
                        bool addingWrongAnswers = true;
                        while (addingWrongAnswers)
                        {
                            string wrongAnswer = ConsoleUI.GetIncorrectAnswer();
                            wrongAnswers.Add(wrongAnswer);
                            Constants.WRONG_ANSWER_COUNT++;
                            addingWrongAnswers = ConsoleUI.AskAddAnotherWrongAnswer();
                        }
                        Logic.AddQuestion(newQuiz, question, correct, wrongAnswers);
                        addingQuestions = ConsoleUI.AskAddAnotherQuestion();
                    }
                    Logic.SaveQuiz(newQuiz);
                    break;
                
                case Constants.CHOOSE_TO_PLAY:
                    Quiz? quiz = Logic.LoadQuiz();
                    if (quiz != null)
                    {
                        int score = Constants.SCORE;
                        foreach (var questions in quiz.Questions)
                        {
                            ConsoleUI.DisplayQuestion(questions);
                            int indexSelected = ConsoleUI.GetUserAnswer(questions.Answers.Count);
                            if (Logic.CheckAnswer(questions, indexSelected))
                            {
                                score++;
                            }
                        }
                        ConsoleUI.ShowResult(score, quiz.Questions.Count);
                    }
                    break; 
                
                case Constants.EXIT_APP:
                    Console.Clear();
                    ConsoleUI.ExitMessage();
                    runningQuiz = false;
                    break;
                
                default:
                    ConsoleUI.InvalidSelection();
                    break;
            }
        }
    }
    
}