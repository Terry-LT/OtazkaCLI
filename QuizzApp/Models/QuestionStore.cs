using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Models
{
    public static class QuestionStore
    {
        public static List<Question> Questions { get; } = new();
    }
}
