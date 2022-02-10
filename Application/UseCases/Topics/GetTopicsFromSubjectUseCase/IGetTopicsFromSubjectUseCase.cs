using Domain.ReponseModels.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Topics.GetTopicsFromSubjectUseCase
{
    public interface IGetTopicsFromSubjectUseCase
    {
        public Task<List<GetTopicsFromSubjectResponseModel>> GetTopicsFromSubject(int subjectId);
    }
}