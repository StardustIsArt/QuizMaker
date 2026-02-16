using System.ComponentModel;
using System.Collections.Generic;

namespace QuizMaker;

public class QuizQuestion
{
    public string Question {  get; set; } 
    public List<string> Answers { get; set; } = new();
    public int CorrectAnswerIndex { get; set; }

    public QuizQuestion() {}
    public QuizQuestion(string question, List<string> answers, int correctAnswerIndex)
    {
        Question = question;
        Answers = answers;
        CorrectAnswerIndex = correctAnswerIndex;
    }
}