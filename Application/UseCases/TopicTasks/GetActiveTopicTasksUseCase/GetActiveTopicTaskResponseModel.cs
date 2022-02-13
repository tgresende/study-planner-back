using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.GetActiveTopicTasksUseCase
{
    public class GetActiveTopicTaskResponseModel
    {
        public int TopicTaskId { get; set; }
        public int TopicId { get; set; }
        public string Action { get; set; }
        public string ActionDescription { get; set; }
        public string ActionSource { get; set; }
        public int Status { get; set; }
    }
}