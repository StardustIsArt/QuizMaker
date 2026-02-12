namespace QuizMaker;

public class Quiz
{
    
    public string getQuestion {  get; set; } 
    public string getCorrectAnswer { get; set; }
    public string getIncorrectAnswer1 { get; set; }

    public Quiz(string question, string correctAnswer, string incorrectAnswer)
    {
        getQuestion = question;
        getCorrectAnswer = correctAnswer;
        getIncorrectAnswer1 = incorrectAnswer;
    }
    
}