using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.FinalizeTopicTaskUseCase
{
    public class FinalizeTopicTaskUseCaseRequestModel
    {
        public int TopicTaskId { get; set; }
        public string ActionSource { get; set; }
        public string ActionDescription { get; set; }
        public string RevisionItem { get; set; }
        public int DoneQuestionQuantity { get; set; }
        public int CorrectQuestionQuantity { get; set; }
    }
}