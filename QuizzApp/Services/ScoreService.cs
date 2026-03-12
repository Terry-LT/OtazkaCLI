using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Services
{
    public class ScoreService
    {
        private int score = 0;
        public int GetScore() => score;
 
        public double CalculateScore(int questionsCount)
        {
            if (questionsCount > 0) {
                return (double)score / questionsCount * 100;
            }
            return 0;
        }

        public void IncrementScore()
        {
            score++;
        }
    }
}
