namespace QuizMaker;

public class Messages
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

    public static string GetCorrectAnswer(string correctAnswer)
    {
        Console.WriteLine("Please add your correct answer:");
        Console.ReadLine();
        return correctAnswer;
    }

    public static string IncorrectAnswer(string incorrectAnswer)
    {
        Console.WriteLine("Please add your incorrect answer:");
        Console.ReadLine();
        return incorrectAnswer;
    }
}