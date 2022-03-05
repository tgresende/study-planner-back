using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases.Subjects.GenerateSubjectCycleUseCase
{
    public interface IGenerateSubjectCycleUseCase
    {
        public Task GenerateSubjectCycle(int projectId);
    }
}