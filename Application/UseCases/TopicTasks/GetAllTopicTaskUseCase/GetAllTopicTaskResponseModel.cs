using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.GetAllTopicTaskUseCase
{
    public class GetAllTopicTaskResponseModel
    {
        public int TopicTaskId { get; set; }
        public long DateTimestamp { get; set; }
        public string Action { get; set; }
        public string ActionDescription { get; set; }
        public string ActionSource { get; set; }
        public string RevisionItem { get; set; }
        public int DoneQuestionQuantity { get; set; }
        public int CorrectQuestionQuantity { get; set; }
        public TaskEnum.TaskStatus Status { get; set; }
    }
}