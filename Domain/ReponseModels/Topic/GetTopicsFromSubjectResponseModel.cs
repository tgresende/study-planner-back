using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ReponseModels.Topic
{
    public class GetTopicsFromSubjectResponseModel
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicAnotations { get; set; }
        public int TotalCorrectQuestion { get; set; }
        public int TotalDoneQuestion { get; set; }
    }
}