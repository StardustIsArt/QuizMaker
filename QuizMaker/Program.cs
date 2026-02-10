using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizMaker;

class Program
{
    static void Main(string[] args)
    {
        Messages.DisplayWelcomeMessage();
        string getQuestion = Messages.GetFirstQuestion(firstQuestion: "");
    }
    
}