using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizMaker;

class Program
{
    public static void Main(string[] args)
    {
        ConsoleUI.DisplayWelcomeMessage();
        QuizQuestion userQuiz = new QuizQuestion()
        {
            Question = ConsoleUI.Question(),
            Answers = new List<string>(),
            CorrectAnswerIndex = 0
        };
        userQuiz.Answers.Add(ConsoleUI.GetCorrectAnswer());
        userQuiz.Answers.Add(ConsoleUI.IncorrectAnswer());
        userQuiz.Answers.Add(ConsoleUI.IncorrectAnswer());
        SaveQuiz(userQuiz);
        LoadQuiz();
    }

    private static void SaveQuiz(QuizQuestion quiz)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(QuizQuestion));
        var xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml");
        using (FileStream fs = File.Create(xmlFilePath))
        {
            serializer.Serialize(fs, quiz);
        }
        ConsoleUI.SavedXMLFile();
        
    }

    private static QuizQuestion LoadQuiz()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(QuizQuestion));
        var xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml");
        
        using FileStream fs = File.OpenRead(xmlFilePath);
        return (QuizQuestion)serializer.Deserialize(fs);
    }
}