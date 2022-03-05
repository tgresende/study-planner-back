using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.SubjectTasks.FinalizeSubjectTaskUseCase
{
    public interface IFinalizeSubjectTaskUseCase
    {
        Task FinalizeSubjectTask(int subjectTaskId);
    }
}