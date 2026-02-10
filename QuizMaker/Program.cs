using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizMaker;

class Program
{
    public static void Main(string[] args)
    {
        Messages.DisplayWelcomeMessage();
        Quiz userQuiz = new Quiz();
       
        string getQuestion = Messages.GetFirstQuestion(firstQuestion: "");
    }
    
}