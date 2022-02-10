using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Notifications
{
    public interface INotification
    {
        void AddErrorMessage(string errorMessage);

        bool ErrorsOccured();

        List<string> GetErrorMessages();
    }
}