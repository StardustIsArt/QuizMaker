namespace QuizMaker;

public class ConsoleUI
{
    public static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Quiz Maker");
    }

    public static void DisplayMenu()
    {
       Console.WriteLine("1. Create Quiz");
       Console.WriteLine("2. Choose Quiz to Play");
       Console.WriteLine("3. Exit");
    }

    public static int GetUserSelection()
    {
        Console.WriteLine("Please select an option:");
        if (int.TryParse(Console.ReadLine(), out int userChoice))
        {
            return userChoice;
        }
        return 0;
    }
    public static void InvalidSelection()
    {
        Console.WriteLine("Invalid selection. Please try again.");
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
    public static void DisplayQuestion(QuizQuestion quiz)
    {
        Console.WriteLine($"{quiz.Question}");
        for (int i = 0; i < quiz.Question.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {quiz.Question[i]}");
        }
    }
    public static int GetUserAnswer()
    {
        Console.WriteLine("Your answer is: (please enter numerical 1, 2 or 3)\n");
        if (int.TryParse(Console.ReadLine(), out int userChoice))
        {
            return userChoice - 1;
        }
        return -1;
    }

    public static void ShowResult(bool isCorrect, QuizQuestion quiz)
    {
        if (isCorrect)
        {
            Console.WriteLine("Hooray, that is correct!");
        }
        else
        {
            Console.WriteLine($"Wrongo. The correct answer is: {quiz.Answers[quiz.CorrectAnswerIndex]}");
        }
    }
    
    public static void ExitMessage()
    {
        Console.WriteLine("Goodbye!");
    }

    public static string SavedXMLFile()
    {
        Console.WriteLine($"File saved to: {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}");
        return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    }
}
