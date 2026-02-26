using System.ComponentModel;
using System.Collections.Generic;

namespace QuizMaker;

public class CreateQuiz
{
    public string Question { get; set; } = string.Empty;
    public List<string> Answers { get; set; } = new();
    public int CorrectAnswerIndex { get; set; }

    public CreateQuiz() {}
    public CreateQuiz(string question, List<string> answers, int correctAnswerIndex)
    {
        Question = question;
        Answers = answers;
        CorrectAnswerIndex = correctAnswerIndex;
    }
}

public class Quiz
{
    public List<CreateQuiz> Questions { get; set; } = new();
}