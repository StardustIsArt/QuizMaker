namespace QuizMaker;

public class ConsoleUI
{
    public static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Quiz Maker");
    }

    public static int UserSelection()
    {
       Console.WriteLine("Please select an number option:"); 
       Console.WriteLine($"{QuizOptions[0]} Create Quiz");
       Console.WriteLine($"{Constants.ChooseQuizToPlay} Choose Quiz to Play");
       Console.WriteLine($"{Constants.Exit} Exit");
       return Convert.ToInt32(Console.ReadLine());
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
