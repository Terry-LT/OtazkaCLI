using QuizzApp.Models;
using QuizzApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Controller
{
    public class QuizController
    {
        private QuizService quizService;
        private ScoreService scoreService;
        private CsvQuestionsLoaderService csvService;
        public QuizController(QuizService quizService, ScoreService scoreService, CsvQuestionsLoaderService csvService) {
            this.quizService = quizService;
            this.scoreService = scoreService;
            this.csvService = csvService;
        }
        public void StartQuiz()
        {
            //Load a csv file
            csvService.Load();
            //Ask to shuffle or stay original order
            //Shuffle questions
            Console.WriteLine("Shuffle questions (y/n):");
            bool shuffleQuestions = (Console.ReadLine() ?? "").ToLower() == "y";
            //Shuffle answers
            Console.WriteLine("Shuffle answers (y/n):");
            bool shuffleAnswers = (Console.ReadLine() ?? "").ToLower() == "y";
            //Amount of questions
            int questionsCount = quizService.QuestionsCount();

            foreach (Question question in quizService.GetQuestions(shuffleQuestions, shuffleAnswers))
            {

                Console.WriteLine(question.QuestionTitle);
                Console.WriteLine("-----------------------------------");
                for (int i = 0; i < question.Choices.Length; i++) {
                    Console.WriteLine($"N{i+1}: {question.Choices[i]}");
                }
                //Ask user to answer
                Console.WriteLine("Enter number(s) (comma-separated for multiple):");
                string[] userAnswers;
                //Check if user do not provide null
                while (true)
                {
                    string userInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(userInput)) {
                        userAnswers = userInput.Split(',')
                            .Select(x => question.Choices[int.Parse(x) - 1])
                            .ToArray();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You must choose number/number!");
                    }
                }
                
                //Check if user answered correctly
                if (quizService.CheckAnswers(userAnswers, question))
                {
                    scoreService.IncrementScore();
                    Console.WriteLine("You answered right!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You answered wrong!");
                    Console.WriteLine("Right answers will be:");
                    foreach (string answer in question.CorrectAnswers)
                    {
                        Console.WriteLine(answer);
                    }
                }
                //Show current score
                Console.WriteLine($"Your current score: {scoreService.GetScore()}/{questionsCount}");
                Console.WriteLine("Please press to continue.");
                //if q or quit, stop quizz
                if (Console.ReadLine() == "q")
                {
                    break;
                }
                Console.Clear();
            }
            Console.WriteLine($"Your score: {scoreService.GetScore()}/{questionsCount}");

        }

    }
}
