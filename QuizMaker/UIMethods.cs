namespace QuizMaker;

public class UIMethods
{
    public static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Quiz Maker");
    }

    public static string GetFirstQuestion(string firstQuestion)
    {
        Console.WriteLine("Please add your question below:");
        Console.ReadLine();
        return firstQuestion;
    }
}