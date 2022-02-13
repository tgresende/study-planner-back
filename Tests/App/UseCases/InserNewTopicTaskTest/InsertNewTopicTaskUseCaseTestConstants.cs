using Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase;

namespace Tests.App.UseCases.InserNewTopicTaskTest
{
    public static class InsertNewTopicTaskUseCaseTestConstants
    {
        public static InsertNewTopicTaskRequestModel GetInsertNewTopicTaskRequestModel()
        {
            return new InsertNewTopicTaskRequestModel
            {
                Action = "abc",
                ActionDescription = "abc",
                ActionSource = "abc",
                TopicId = 1
            };
        }
    }
}