using CsvHelper;
using QuizzApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static System.Net.Mime.MediaTypeNames;
namespace QuizzApp.Services
{
    //P.S CSV must not contain "," in answer itself
    public class CsvQuestionsLoaderService
    {
        private string AskForFile()
        {
            string filePath = "";
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Select a file";
                dialog.Filter = "CSV files (*.csv)|*.csv";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }
            }
            return filePath;
        }

        public void Load() {
            //https://joshclose.github.io/CsvHelper/examples/reading/reading-by-hand/
            using (var reader = new StreamReader(AskForFile(),Encoding.UTF8))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    Question question = new Question(
                        csv.GetField("Question Type"),
                        csv.GetField("Question Title"),
                        csv.GetField("Choices").Split(',').Select(x => x.Trim()).ToArray(),
                        csv.GetField("Correct Answer(s)").Split(',').Select(x => x.Trim()).ToArray(),
                        csv.GetField("Image Full Path")
                    );
                    QuestionStore.Questions.Add(question);
                }
            }
        }
    }
}
