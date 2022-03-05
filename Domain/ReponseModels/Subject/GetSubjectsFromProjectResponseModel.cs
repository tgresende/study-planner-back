namespace Domain.ReponseModels.Subject
{
    public class GetSubjectsFromProjectResponseModel
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Annotations { get; set; }
        public int Score { get; set; }
    }
}