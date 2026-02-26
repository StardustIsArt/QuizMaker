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
    public static string IncorrectAnswer1()
    {
        Console.WriteLine("Please add your first incorrect answer:");
        return Console.ReadLine();
    }
    public static string IncorrectAnswer2()
    {
        Console.WriteLine("Please add your second incorrect answer:");
        return Console.ReadLine();
    }
    public static void DisplayQuestion(CreateQuiz question)
    {
        Console.WriteLine($"{question.Question}");
        for (int i = 0; i < question.Answers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {question.Answers[i]}");
        }
    }
    public static int GetUserAnswer()
    {
        while (true)
        {
            Console.WriteLine("Your answer (1, 2 or 3):\n");
            if (int.TryParse(Console.ReadLine(), out int userChoice)&& userChoice >= 1 && userChoice <= 3)
            {
                return userChoice - 1;
            }
            Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
        }
    }

    public static void ShowResult(int score, int total)
    {
        Console.WriteLine($"You scored {score} out of {total} points");
    }

    public static void NoQuizFound()
    {
        Console.WriteLine("No Quiz found. Please creat one first.");
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
