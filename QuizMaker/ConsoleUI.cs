namespace QuizMaker;

public class ConsoleUI
{
    public static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Quiz Maker");
    }
    public static void DisplayMenu()
    {
       Console.WriteLine($"{Constants.CREATE_QUIZ}. Create Quiz");
       Console.WriteLine($"{Constants.CHOOSE_TO_PLAY}. Choose Quiz to Play");
       Console.WriteLine($"{Constants.EXIT_APP}. Exit");
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
    public static string GetIncorrectAnswer()
    {
        Console.WriteLine($"Enter the incorrect answer:");
        return Console.ReadLine() ?? "";
    }
    public static void DisplayQuestion(Question question)
    {
        Console.WriteLine($"{question.Text}");
        for (int i = 0; i < question.Answers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {question.Answers[i]}");
        }
    }
    public static bool AskAddAnotherQuestion()
    {
        Console.WriteLine("Would you like to add another question? (y/n)");
        string response = Console.ReadLine()?.Trim().ToLower() ?? "n";
        return response == "y" || response == "yes";
    }

    public static bool AskAddAnotherWrongAnswer()
    {
        Console.WriteLine("Would you like to add another wrong answer? (y/n)");
        return Console.ReadLine()?.Trim().ToLower() == "y";
    }
    public static int GetUserAnswer(int maxAnswers)
    {
        while (true)
        {
            Console.WriteLine($"Enter your answer #{maxAnswers}):\n");
            if (int.TryParse(Console.ReadLine(), out int answer)&& answer >= 1 && answer <= maxAnswers)
            {
                return answer - 1;
            }
            Console.WriteLine($"Invalid input. Please enter a number between 1 & {maxAnswers}:");
        }
    }
    public static void ShowResult(int score, int total)
    {
        Console.WriteLine($"\nYou scored {score} out of {total} points\n");
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

    public static int GetUserAnswer()
    {
        throw new NotImplementedException();
    }
}
