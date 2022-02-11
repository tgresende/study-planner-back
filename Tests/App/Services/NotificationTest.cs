using Application.Services.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.App.Services
{
    [TestClass]
    public class NotificationTest
    {
        private Notification notification;

        public NotificationTest()
        {
            notification = new Notification();
        }

        [TestMethod]
        public void ShouldAddErrorMessage()
        {
            string message = "teste de mensagem";

            notification.AddErrorMessage(message);
            string expectedMessage = message;

            Assert.AreEqual(expectedMessage, notification.GetErrorMessages()[0]);
        }

        [TestMethod]
        public void ShouldNotAddErrorMessage()
        {
            string message = " ";

            notification.AddErrorMessage(message);

            Assert.IsNull(notification.GetErrorMessages());
        }

        [TestMethod]
        public void ShouldReturnTrueForErrorsVerificationOnAddErrorMessage()
        {
            string message = "teste de mensagem";

            notification.AddErrorMessage(message);

            Assert.IsTrue(notification.ErrorsOccured());
        }
    }
}