namespace QuizMaker;

public class Messages
{
    public static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Quiz Maker");
    }

    public static string Question()
    {
        Console.WriteLine("Please add your question below:");
        return Console.ReadLine();
    }

    public static string GetCorrectAnswer()
    {
        Console.WriteLine("Please enter the correct answer:");
        return Console.ReadLine();
    }

    public static string IncorrectAnswer()
    {
        Console.WriteLine("Please add your incorrect answers:");
        return Console.ReadLine();
    }
}