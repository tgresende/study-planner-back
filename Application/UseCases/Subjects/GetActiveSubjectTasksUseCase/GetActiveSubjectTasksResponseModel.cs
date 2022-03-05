using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Subjects.GetActiveSubjectTasksUseCase
{
    public class GetActiveSubjectTasksResponseModel
    {
        public string SubjectName { get; set; }
        public int SubjectId { get; set; }
        public int Weight { get; set; }
        public int SubjectTaskId { get; set; }
        public int PonderatedWeightScore { get; set; }
        public int MinutesStudy { get; set; }
        public int InternalOrder { get; set; }
    }
}