using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QuizMaker;
public class Logic
{
    private static readonly XmlSerializer QuizSerializer = new XmlSerializer(typeof(Quiz));
    public static void AddQuestion(Quiz quiz, string question, string correctAnswer, List<string> wrongAnswers)
    {
        var answers = new List<string>{ correctAnswer };
        answers.AddRange(wrongAnswers);
        var rng = new Random();
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
        var xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Constants.NAME_OF_SAVED_QUIZ);
        using (FileStream fs = File.Create(xmlFilePath))
        {
            QuizSerializer.Serialize(fs, quiz);           
        }
        ConsoleUI.SavedXMLFile();
        
    }
    public static Quiz? LoadQuiz()
    {
        if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Constants.NAME_OF_SAVED_QUIZ)))
        {
            ConsoleUI.NoQuizFound();
            return null;
        }
        var xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Constants.NAME_OF_SAVED_QUIZ);
        
        using FileStream fs = File.OpenRead(xmlFilePath);
        return (Quiz?)QuizSerializer.Deserialize(fs)!;
    }
}