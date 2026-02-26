using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizMaker;
public class Logic
{
    public static void CreateQuiz(string question, string correct, string wrong1, string wrong2)
    {
        var answers = new List<string> { correct, wrong1, wrong2 };
        var rng = new Random();
        string correctAnswer = answers[0];
        answers = answers.OrderBy(x => rng.Next()).ToList();
        int newCorrectIndex = answers.IndexOf(correctAnswer);
        
        CreateQuiz userQuiz = new CreateQuiz()
        {
            Question = question,
            Answers = answers,
            CorrectAnswerIndex = newCorrectIndex
        };
        Quiz quiz = new Quiz();
        quiz.Questions.Add(userQuiz);
        SaveQuiz(quiz);
    }
    public static void PlayQuiz()
    {
        Quiz? quiz = LoadQuiz();
        if (quiz == null) return;
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
    public static void ExitApp()
    {
        Console.Clear();
        ConsoleUI.ExitMessage();
    }

    public static bool CheckAnswer(CreateQuiz question, int selectedIndex)
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
    private static Quiz? LoadQuiz()
    {
        if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml")))
        {
            ConsoleUI.NoQuizFound();
            return null;
        }
        XmlSerializer serializer = new XmlSerializer(typeof(Quiz));
        var xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml");
        
        using FileStream fs = File.OpenRead(xmlFilePath);
        return (Quiz?)serializer.Deserialize(fs)!;
    }
}