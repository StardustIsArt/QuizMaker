namespace QuizMaker;

public class ConsoleUI
{
    public static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Quiz Maker");
    }

    public static void DisplayMenu()
    {
       Console.WriteLine("Please select an number option:"); 
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

    public static string SavedXMLFile()
    {
        Console.WriteLine($"File saved to: {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}");
        return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    }
}
