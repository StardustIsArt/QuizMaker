using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizMaker;

class Program
{
    public static void Main(string[] args)
    {
        Messages.DisplayWelcomeMessage();
        Quiz userQuiz = new Quiz();
        userQuiz.Question = Messages.Question();
        userQuiz.Answers = new List<string>();
        userQuiz.CorrectAnswerIndex = 0;
        
        userQuiz.Answers.Add(Messages.GetCorrectAnswer());
        userQuiz.Answers.Add(Messages.IncorrectAnswer());
        userQuiz.Answers.Add(Messages.IncorrectAnswer());
    }
    
}