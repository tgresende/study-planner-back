namespace Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase
{
    public class AddTopicTaskResponseModel
    {
        public int TopicTaskId { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string Action { get; set; }
        public string ActionDescription { get; set; }
        public string ActionSource { get; set; }
        public int Status { get; set; }
    }
}