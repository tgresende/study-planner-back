using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubjectTask
    {
        public int SubjectTaskId { get; set; }
        public Subject Subject { get; set; }
        public TaskEnum.TaskStatus Status { get; set; }
        public int PonderatedWeightScore { get; set; }
        public int MinutesStudy { get; set; }
        public int InternalOrder { get; set; }
    }
}