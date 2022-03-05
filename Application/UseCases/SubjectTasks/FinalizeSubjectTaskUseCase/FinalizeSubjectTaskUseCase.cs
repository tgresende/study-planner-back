using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.SubjectTasks.FinalizeSubjectTaskUseCase
{
    public class FinalizeSubjectTaskUseCase : IFinalizeSubjectTaskUseCase
    {
        private readonly ISubjectTaskRepository _subjectTaskRepository;
        private readonly IUnitWork _unitWork;

        public FinalizeSubjectTaskUseCase(ISubjectTaskRepository subjectTaskRepository,
            IUnitWork unitWork)
        {
            _subjectTaskRepository = subjectTaskRepository;
            _unitWork = unitWork;
        }

        public async Task FinalizeSubjectTask(int subjectTaskId)
        {
            SubjectTask subjectTask = await _subjectTaskRepository.GetSubjectTask(subjectTaskId);

            if (subjectTask == null)
                return;

            subjectTask.Status = Domain.Enums.TaskEnum.TaskStatus.Finished;
            await _unitWork.SaveChanges();
        }
    }
}