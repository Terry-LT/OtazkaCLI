using QuizzApp.Controller;
using QuizzApp.Services;
using System.Text;
class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        ShuffleService shuffleService = new ShuffleService();
        QuizService quizService = new QuizService(shuffleService);
        ScoreService scoreService = new ScoreService();
        CsvQuestionsLoaderService csvService = new CsvQuestionsLoaderService();

        QuizController controller = new QuizController(quizService, scoreService, csvService);
        controller.StartQuiz();


    }
}
