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
                CorrectQuestionQuantity = 0,
                DoneQuestionQuantity = 0,
                RevisionItem = "abc",
                TopicId = 1
            };
        }
    }
}