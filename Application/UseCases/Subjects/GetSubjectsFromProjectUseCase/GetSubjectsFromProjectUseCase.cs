using Domain.ReponseModels.Subject;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases.Subjects.GetSubjectsFromProjectUseCase
{
    public class GetSubjectsFromProjectUseCase : IGetSubjectsFromProjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IProjectRepository _projectRepository;

        public GetSubjectsFromProjectUseCase(ISubjectRepository subjectRepository, IProjectRepository projectRepository)
        {
            _subjectRepository = subjectRepository;
            _projectRepository = projectRepository;
        }

        public async Task<List<GetSubjectsFromProjectResponseModel>> GetSubjectsFromProject(int projectId)
        {
            var project = await _projectRepository.GetProject(projectId);

            return await _subjectRepository.GetSubjectsFromProject(project);
        }
    }
}