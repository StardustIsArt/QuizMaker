using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizMaker;
public class Logic
{
    public static void QuizMaker()
    {
        CreateQuiz userQuiz = new CreateQuiz()
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
        Quiz quiz = LoadQuiz();
        int score = Constants.SCORE;
        foreach (var question in quiz.Questions)
        {
            ConsoleUI.DisplayQuestion(question); 
            int indexSelected = ConsoleUI.GetUserAnswer();
            if (CheckAnswer(question, indexSelected))
            {
                score++;
            }
        }
        ConsoleUI.ShowResult(score, quiz.Questions.Count);
    }

    public static void Exit()
    {
        Console.Clear();
        ConsoleUI.ExitMessage();
    }

    public static bool CheckAnswer(Quiz question, int selectedIndex)
    {
        return selectedIndex == question.CorrectAnswerIndex;
    }
    private static void SaveQuiz(Quiz quiz)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Quiz));
        var xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml");
        using (FileStream fs = File.Create(xmlFilePath))
        {
            serializer.Serialize(fs, quiz);
        }
        ConsoleUI.SavedXMLFile();
        
    }
    private static Quiz LoadQuiz()
    {
        if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml")))
        {
            ConsoleUI.NoQuizFound();
            return null!;
        }
        XmlSerializer serializer = new XmlSerializer(typeof(Quiz));
        var xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml");
        
        using FileStream fs = File.OpenRead(xmlFilePath);
        return (Quiz)serializer.Deserialize(fs)!;
    }
}