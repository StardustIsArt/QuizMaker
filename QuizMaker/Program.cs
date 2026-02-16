using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizMaker;

class Program
{
    public static void Main(string[] args)
    {
        Messages.DisplayWelcomeMessage();
        Quiz userQuiz = new Quiz()
        {
            Question = Messages.Question(),
            Answers = new List<string>(),
            CorrectAnswerIndex = 0
        };
        userQuiz.Answers.Add(Messages.GetCorrectAnswer());
        userQuiz.Answers.Add(Messages.IncorrectAnswer());
        userQuiz.Answers.Add(Messages.IncorrectAnswer());
        SaveQuiz(userQuiz);
        LoadQuiz();
    }

    private static void SaveQuiz(Quiz quiz)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Quiz));
        var xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml");
        using (FileStream fs = File.Create(xmlFilePath))
        {
            serializer.Serialize(fs, quiz);
        }
        Messages.SavedXMLFile();
        
    }

    private static Quiz LoadQuiz()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Quiz));
        var xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml");
        
        using FileStream fs = File.OpenRead(xmlFilePath);
        return (Quiz)serializer.Deserialize(fs);
    }
}