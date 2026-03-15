using QuizzApp.Models;
using QuizzApp.Services;
using System.Collections.Generic;
namespace QuizzApp.Test
{
    public class ShuffleServiceTests
    {
        private ShuffleService shuffleService;

        public ShuffleServiceTests()
        {
            shuffleService = new ShuffleService();
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
        private List<Question> CreateQuestionList()
        {
            return new List<Question>
            {
                CreateMultipleChoiceQuestion(),
                CreateCheckBoxChoiceQuestion()
            };
        }
        [Fact]
        public void ShuffleQuestions_ShouldReturnSameQuestions_IfShuffleQuestionsIsFalse()
        {
            List<Question> questions = CreateQuestionList();
            List<Question> shuffledQuestions = shuffleService.ShuffleQuestions(questions, false, false);
            Assert.Equal(questions, shuffledQuestions);
        }
        [Fact]
        public void ShuffleQuestions_ShouldReturnSameChoices_IfShuffleAnswersIsFalse() {
            List<Question> questions = CreateQuestionList();

            List<Question> shuffledQuestions = shuffleService.ShuffleQuestions(questions, false, false);
            for (int i = 0; i < questions.Count; i++)
            {
                Assert.Equal(questions[i].Choices, shuffledQuestions[i].Choices);
            }
        }
        [Fact]
        public void ShuffleQuestions_ShouldReturnSameNumberOfQuestions_IfShuffleQuestionsIsTrue()
        {
            List<Question> questions = CreateQuestionList();
            List<Question> shuffledQuestions = shuffleService.ShuffleQuestions(questions, true, false);
            Assert.Equal(questions.Count, shuffledQuestions.Count);
        }

    }
}
