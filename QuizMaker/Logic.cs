using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizMaker;
public class Logic
{
    public static void QuizMaker()
    {
        QuizQuestion userQuiz = new QuizQuestion()
        {
            Question = ConsoleUI.Question(),
            Answers = new List<string>(),
            CorrectAnswerIndex = 0
        };
        userQuiz.Answers.Add(ConsoleUI.GetCorrectAnswer());
        userQuiz.Answers.Add(ConsoleUI.IncorrectAnswer1());
        userQuiz.Answers.Add(ConsoleUI.IncorrectAnswer2());
        SaveQuiz(userQuiz);
    }

    public static void PlayQuiz()
    {
        QuizQuestion quiz = LoadQuiz();
        ConsoleUI.DisplayQuestion(quiz);
        int indexSelected = ConsoleUI.GetUserAnswer();
        bool isCorrect = quiz.CorrectAnswerIndex == indexSelected;
        ConsoleUI.ShowResult(isCorrect, quiz);
    }

    public static void Exit()
    {
        Console.Clear();
        ConsoleUI.ExitMessage();
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
        return (QuizQuestion)serializer.Deserialize(fs)!;
    }
}