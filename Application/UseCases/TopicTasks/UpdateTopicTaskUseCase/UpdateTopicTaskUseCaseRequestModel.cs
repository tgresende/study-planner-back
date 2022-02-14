using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.UpdateTopicTaskUseCase
{
    public class UpdateTopicTaskUseCaseRequestModel
    {
        public int TopicTaskId { get; set; }
        public string ActionSource { get; set; }
        public string ActionDescription { get; set; }
    }
}