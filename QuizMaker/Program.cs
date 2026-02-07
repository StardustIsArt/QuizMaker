namespace QuizMaker;

class Program
{
    static void Main(string[] args)
    {
        UIMethods.DisplayWelcomeMessage();
        string getQuestion = UIMethods.GetFirstQuestion(firstQuestion: "");
    }
    
}