using Domain.Entities;
using Domain.ReponseModels.Subject;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases.Subjects.GetActiveSubjectTasksUseCase
{
    public class GetActiveSubjectTasksUseCase : IGetActiveSubjectTasksUseCase
    {
        private readonly ISubjectTaskRepository _subjectTaskRepository;

        public GetActiveSubjectTasksUseCase(ISubjectTaskRepository subjectTaskRepository)
        {
            _subjectTaskRepository = subjectTaskRepository;
        }

        public async Task<List<GetActiveSubjectTasksResponseModel>> GetActiveSubjectTasks(int projectId)
        {
            var activeSubjectTasks = await _subjectTaskRepository.GetActiveSubjectTasks(projectId);

            var responseModelList = new List<GetActiveSubjectTasksResponseModel>();

            foreach (var activeSubjectTask in activeSubjectTasks)
            {
                responseModelList.Add(MapToResponseModel(activeSubjectTask));
            }

            return responseModelList;
        }

        private GetActiveSubjectTasksResponseModel MapToResponseModel(SubjectTask task)
        {
            return new GetActiveSubjectTasksResponseModel
            {
                InternalOrder = task.InternalOrder,
                MinutesStudy = task.MinutesStudy,
                PonderatedWeightScore = task.PonderatedWeightScore,
                SubjectId = task.Subject.SubjectId,
                SubjectName = task.Subject.Name,
                SubjectTaskId = task.SubjectTaskId,
                Weight = task.Subject.Weight
            };
        }
    }
}