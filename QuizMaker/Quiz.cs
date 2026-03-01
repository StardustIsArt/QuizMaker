namespace QuizMaker;

public class Question
{
    public string Text { get; set; } = string.Empty;
    public List<string> Answers { get; set; } = new();
    public int CorrectAnswerIndex { get; set; }

    public Question() {}
    public Question(string question, List<string> answers, int correctAnswerIndex)
    {
        Text = question;
        Answers = answers;
        CorrectAnswerIndex = correctAnswerIndex;
    }
}

public class Quiz
{
    public List<Question> Questions { get; set; } = new();
}