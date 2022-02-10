using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Notifications
{
    public class Notification : INotification
    {
        private List<string> errors;

        public void AddErrorMessage(string errorMessage)
        {
            errors.Add(errorMessage);
        }

        public bool ErrorsOccured()
        {
            return errors.Any();
        }

        public List<string> GetErrorMessages()
        {
            return errors;
        }
    }
}