using QuizzApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuizzApp.Services
{
    public class QuizService
    {
        private ShuffleService shuffleService;
        
        public QuizService(ShuffleService shuffleService)
        {
            this.shuffleService = shuffleService;
        }
        public int QuestionsCount()
        {
            return QuestionStore.Questions.Count;
        }
        public List<Question> GetQuestions(bool shuffleQuestions,bool shuffleAnswers)
        {
            return shuffleService.ShuffleQuestions(QuestionStore.Questions, shuffleQuestions, shuffleAnswers);
        }
        public bool CheckAnswers(string[] userAnswers,Question question)
        {
            //If only one right answer
            if (question.QuestionType ==  "MULTIPLE_CHOICE")
            {
                if (question.CorrectAnswers.Length == 1 && userAnswers.Length == 1)
                {
                    return question.CorrectAnswers[0] == userAnswers[0];
                }
            }
            else if (question.QuestionType == "CHECKBOX")
            {
                bool sameCount = userAnswers.Length == question.CorrectAnswers.Length;
                bool containsAll = question.CorrectAnswers.All(item => userAnswers.Contains(item));

                return containsAll && sameCount;
            }
            return false;
        }
    }
}
