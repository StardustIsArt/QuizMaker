using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizMaker;

class Program
{
    public static void Main(string[] args)
    {
        Messages.DisplayWelcomeMessage();
        Quiz userQuiz = new Quiz();
        userQuiz.getQuestion = Messages.GetFirstQuestion(firstQuestion: "");
        userQuiz.getCorrectAnswer = Messages.GetCorrectAnswer(correctAnswer: "");
        userQuiz.getIncorrectAnswer1 = Messages.IncorrectAnswer(incorrectAnswer: "");
    }
    
}