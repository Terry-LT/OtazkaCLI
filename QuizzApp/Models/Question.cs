using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string QuestionType { get; set; }
        public string QuestionTitle { get; set; }
        public string[] Choices { get; set; }
        public string[] CorrectAnswers { get; set; }
        public string ImgPath { get; set; }

        public Question(string questionType, string questionTitle, 
                        string[] choices, string[] correctAnswers, string imgPath)
        {
            this.QuestionType = questionType;
            this.QuestionTitle = questionTitle;
            this.Choices = choices;
            this.CorrectAnswers = correctAnswers;
            this.ImgPath = imgPath;
            this.Id = Guid.NewGuid().ToString();

        }
        public override string ToString()
        {
            return
                $"Id: {Id}\n" +
                $"Type: {QuestionType}\n" +
                $"Title: {QuestionTitle}\n" +
                $"Choices: {string.Join(", ", Choices)}\n" +
                $"Correct answers: {string.Join(", ", CorrectAnswers)}\n" +
                $"Image path: {ImgPath}\n";
        }
    }
}
