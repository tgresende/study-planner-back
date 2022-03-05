using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Annotations { get; set; }
        public Project Project { get; set; }
        public List<Topic> Topics { get; set; }
        public List<SubjectTask> SubjectTasks { get; set; }

        public int GetScore()
        {
            int totalCorrectQuestion = 0;
            int totalDoneQuestion = 0;
            foreach (var topic in Topics)
            {
                totalCorrectQuestion += topic.GetTotalCorrectQuestion();
                totalDoneQuestion += topic.GetTotalDoneQuestion();
            }

            if (totalDoneQuestion == 0)
                return 0;

            return totalCorrectQuestion * 100 / totalDoneQuestion;
        }
    }
}