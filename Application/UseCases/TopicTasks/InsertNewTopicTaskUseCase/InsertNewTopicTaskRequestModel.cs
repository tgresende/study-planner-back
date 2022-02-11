namespace Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase
{
    public class InsertNewTopicTaskRequestModel
    {
        public int TopicId { get; set; }
        public string Action { get; set; }
        public string ActionDescription { get; set; }
        public string ActionSource { get; set; }
        public string RevisionItem { get; set; }
        public int DoneQuestionQuantity { get; set; }
        public int CorrectQuestionQuantity { get; set; }
    }
}