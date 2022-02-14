using Application.Services.Notifications;
using Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase;
using Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace Tests.App.UseCases.InserNewTopicTaskTest
{
    [TestClass]
    public class InsertNewTopicTaskUseCaseTest
    {
        private readonly Mock<ITopicTaskRepository> topicTaskRepository;
        private readonly Mock<ITopicRepository> topicRepository;
        private readonly Mock<IUnitWork> unitWork;
        private Notification notification;

        private InsertNewTopicTaskUseCase insertNewTopicTaskUseCase;

        public InsertNewTopicTaskUseCaseTest()
        {
            topicTaskRepository = new Mock<ITopicTaskRepository>();
            topicRepository = new Mock<ITopicRepository>();
            unitWork = new Mock<IUnitWork>();
            notification = new Notification();
        }

        [TestMethod]
        public async Task ShouldReturnErrorMessageTopicNotFound()
        {
            InsertNewTopicTaskRequestModel requestModel = InsertNewTopicTaskUseCaseTestConstants.GetInsertNewTopicTaskRequestModel();

            topicRepository.Setup(repo => repo.GetTopic(It.IsAny<int>())).Returns<Task>(null);

            CreateuseCaseObject();

            var responseModel = await insertNewTopicTaskUseCase.InsertNewTopicTask(requestModel);

            string expectedMessage = "Assunto não encontrado na base de dados";

            Assert.AreEqual(expectedMessage, notification.GetErrorMessages()[0]);
            Assert.AreEqual(1, notification.GetErrorMessages().Count);
            Assert.IsTrue(notification.ErrorsOccured());
        }

        [TestMethod]
        public async Task ShouldReturnErrorMessageRequiredTopicId()
        {
            InsertNewTopicTaskRequestModel requestModel = new InsertNewTopicTaskRequestModel();

            CreateuseCaseObject();

            var responseModel = await insertNewTopicTaskUseCase.InsertNewTopicTask(requestModel);

            string expectedMessage = "Assunto não informado";

            Assert.AreEqual(expectedMessage, notification.GetErrorMessages()[0]);
            Assert.AreEqual(1, notification.GetErrorMessages().Count);
            Assert.IsTrue(notification.ErrorsOccured());
        }

        private void CreateuseCaseObject()
        {
            this.insertNewTopicTaskUseCase
                  = new InsertNewTopicTaskUseCase(
                         topicTaskRepository.Object,
                         topicRepository.Object,
                         unitWork.Object,
                         notification
                         );
        }
    }
}