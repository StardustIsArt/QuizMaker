using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizMaker;
public class Logic
{
    private static readonly XmlSerializer QuizSerializer = new XmlSerializer(typeof(Quiz));
    public static void AddQuestion(Quiz quiz, string question, string correct, string wrong1, string wrong2)
    {
        var answers = new List<string>{ correct, wrong1, wrong2 };
        var rng = new Random();
        string correctAnswer = answers[Constants.CORRECT_ANSWER];
        answers = answers.OrderBy( x => rng.Next()).ToList();
        int newCorrectIndex = answers.IndexOf( correctAnswer );
        Question newQuestion = new Question()
        {
            Text = question,
            Answers = answers,
            CorrectAnswerIndex = newCorrectIndex,
        };
        quiz.Questions.Add(newQuestion);
    }
    public static bool CheckAnswer(Question question, int selectedIndex)
    {
        return selectedIndex == question.CorrectAnswerIndex;
    }
    public static void SaveQuiz(Quiz quiz)
    {
        var xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml");
        using (FileStream fs = File.Create(xmlFilePath))
        {
            QuizSerializer.Serialize(fs, quiz);           
        }
        ConsoleUI.SavedXMLFile();
        
    }
    public static Quiz? LoadQuiz()
    {
        if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml")))
        {
            ConsoleUI.NoQuizFound();
            return null;
        }
        var xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Quiz.xml");
        
        using FileStream fs = File.OpenRead(xmlFilePath);
        return (Quiz?)QuizSerializer.Deserialize(fs)!;
    }
}