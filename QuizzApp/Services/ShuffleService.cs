using QuizzApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuizzApp.Services
{
    public class ShuffleService
    {
        private Random rng = new Random();
        public List<Question> ShuffleQuestions(List<Question> questions, bool shuffleQuestions, bool shuffleAnswers)
        {
            if (shuffleQuestions)
            {
                for (int i = questions.Count - 1; i > 0; i--)
                {
                    int j = rng.Next(i + 1);
                    (questions[i], questions[j]) = (questions[j], questions[i]);
                }
            }
            if (shuffleAnswers)
            {
                foreach (Question question in questions)
                {
                    for (int i = question.Choices.Count() - 1; i > 0; i--)
                    {
                        int j = rng.Next(i + 1);
                        (question.Choices[i], question.Choices[j]) = (question.Choices[j], question.Choices[i]);
                    }
                }
            }
            return questions;
        }
    }
}
