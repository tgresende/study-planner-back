using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Anotations { get; set; }
        public Subject Subject { get; set; }
        public List<TopicTask> TopicTasks { get; set; }

        public int GetTotalDoneQuestion()
        {
            int totalDoneQuestion = 0;
            foreach (var task in TopicTasks)
            {
                totalDoneQuestion += task.DoneQuestionQuantity;
            }

            return totalDoneQuestion;
        }

        public int GetTotalCorrectQuestion()
        {
            int totalCorrectQuestion = 0;
            foreach (var task in TopicTasks)
            {
                totalCorrectQuestion += task.CorrectQuestionQuantity;
            }

            return totalCorrectQuestion;
        }
    }
}