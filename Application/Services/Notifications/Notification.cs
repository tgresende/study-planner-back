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

        public Notification()
        {
            errors = new List<string>();
        }

        public void AddErrorMessage(string errorMessage)
        {
            if (errorMessage.Trim().Length > 0)
                errors.Add(errorMessage);
        }

        public bool ErrorsOccured()
        {
            return errors.Any();
        }

        public List<string> GetErrorMessages()
        {
            if (errors.Any())
                return errors;
            return null;
        }
    }
}