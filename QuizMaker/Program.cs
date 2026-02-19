using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizMaker;

class Program
{
    public static void Main(string[] args)
    {
        UIMethods.DisplayWelcomeMessage();
        QuizQuestion userQuiz = new QuizQuestion()
        {
            Question = UIMethods.Question(),
            Answers = new List<string>(),
            CorrectAnswerIndex = 0
        };
        userQuiz.Answers.Add(UIMethods.GetCorrectAnswer());
        userQuiz.Answers.Add(UIMethods.IncorrectAnswer());
        userQuiz.Answers.Add(UIMethods.IncorrectAnswer());
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
        UIMethods.SavedXMLFile();
        
    }

    private static QuizQuestion LoadQuiz()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(QuizQuestion));
        var xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml");
        
        using FileStream fs = File.OpenRead(xmlFilePath);
        return (QuizQuestion)serializer.Deserialize(fs);
    }
}