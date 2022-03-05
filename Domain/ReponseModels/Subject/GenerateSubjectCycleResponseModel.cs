using Domain.Entities;

namespace Domain.ReponseModels.Subject
{
    public class GenerateSubjectCycleResponseModel
    {
        public Entities.Subject Subject { get; set; }
        public int PonderatedWeightScore { get; set; }
        public int MinutesStudy { get; set; }
        public int TotalItems { get; set; }
        public int InternalOrder { get; set; }
    }
}