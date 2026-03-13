using QuizzApp.Services;

namespace QuizzApp.Test
{
    public class ScoreServiceTests
    {
        private ScoreService scoreService;
        public ScoreServiceTests()
        {
            scoreService = new ScoreService();
        }
        [Fact]
        public void CalculateScore_ShouldReturnZero_IfQuestionsCountEqualZero()
        {
            Assert.Equal(0, scoreService.CalculateScore(0));
        }
        [Fact]
        public void CalculateScore_ShouldReturnZero_IfQuestionsCountLessZero()
        {
            Assert.Equal(0, scoreService.CalculateScore(-1));
        }
        [Fact]
        public void CalculateScore_ShouldReturnRightPercent()
        {
            scoreService.IncrementScore();
            scoreService.IncrementScore();
            scoreService.IncrementScore();
            Assert.Equal(60, scoreService.CalculateScore(5));
        }
        [Fact]
        public void IncrementScore_ShouldIncreaseScoreByOne()
        {
            int originalScore = scoreService.GetScore();
            scoreService.IncrementScore();
            Assert.Equal(originalScore+1, scoreService.GetScore());
        }
        [Fact]
        public void IncrementScore_ShouldIncreaseScoreByTwo()
        {
            int originalScore = scoreService.GetScore();
            scoreService.IncrementScore();
            scoreService.IncrementScore();
            Assert.Equal(originalScore + 2, scoreService.GetScore());
        }
    }
}
