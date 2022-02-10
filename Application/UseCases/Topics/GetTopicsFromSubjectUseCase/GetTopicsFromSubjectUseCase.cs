using Domain.Entities;
using Domain.ReponseModels.Topic;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Topics.GetTopicsFromSubjectUseCase
{
    public class GetTopicsFromSubjectUseCase : IGetTopicsFromSubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITopicRepository topicRepository;

        public GetTopicsFromSubjectUseCase(ISubjectRepository subjectRepository, ITopicRepository topicRepository)
        {
            _subjectRepository = subjectRepository;
            this.topicRepository = topicRepository;
        }

        public async Task<List<GetTopicsFromSubjectResponseModel>> GetTopicsFromSubject(int subjectId)
        {
            Subject subject = await _subjectRepository.GetSubject(subjectId);
            return await topicRepository.GetTopicsFromSubject(subject);
        }
    }
}