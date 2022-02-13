using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Subjects.UpdateSubjectAnnotationsUseCase
{
    public interface IUpdateSubjectAnnotationsUseCase
    {
        Task UpdateSubjectAnnotations(UpdateSubjectAnnotationsUseCaseResquestModel requestModel);
    }
}