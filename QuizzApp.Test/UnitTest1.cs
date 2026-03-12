using QuizzApp.Models;
using QuizzApp.Services;

namespace QuizzApp.Test
{
    public class QuizzServiceTests
    {
        private QuizService quizService;
        public QuizzServiceTests()
        {
            quizService = new QuizService(new ShuffleService());
        }
        //Function helpers
        private Question CreateMultipleChoiceQuestion()
        {
            return new Question(
                "MULTIPLE_CHOICE",
                "Question Title 1",
                new string[] { "Choice 1", "Choice 2", "Choice 3" },
                new string[] { "Choice 1" },
                null
            );
        }
        private Question CreateCheckBoxChoiceQuestion()
        {
            return new Question(
                "CHECKBOX",
                "Question Title 1",
                new string[] { "Choice 1", "Choice 2", "Choice 3" },
                new string[] { "Choice 1", "Choice 3" },
                null
            );
        }
        [Fact]
        public void CheckAnswers_ShouldReturnTrue_IfOneRightAnswer()
        {
            //Question with one right answer
            Question question = CreateMultipleChoiceQuestion();

            Assert.True(quizService.CheckAnswers([ "Choice 1" ], question));
        }
        [Fact]
        public void CheckAnswers_ShouldReturnFalse_IfOneRightAnswer()
        {
            //Question with one right answer
            Question question = CreateMultipleChoiceQuestion();

            Assert.False(quizService.CheckAnswers([ "Choice 1", "Choice 3" ], question));

        }
        [Fact]
        public void CheckAnswers_ShouldReturnTrue_IfMoreOneRightAnswer()
        {
            Question question = CreateCheckBoxChoiceQuestion();
            Assert.True(quizService.CheckAnswers(["Choice 1", "Choice 3" ], question));
        }
        [Fact]
        public void CheckAnswers_ShouldReturnFalse_IfMoreOneRightAnswer()
        {
            Question question = CreateCheckBoxChoiceQuestion();
            Assert.False(quizService.CheckAnswers([ "Choice 1" ], question));
        }
        [Fact]
        public void CheckAnswers_ShouldReturnTrue_IfMoreOneRightAnswerAndOrderIndependent()
        {
            Question question = CreateCheckBoxChoiceQuestion();
            Assert.True(quizService.CheckAnswers([ "Choice 3", "Choice 1" ], question));
        }
    }
}