using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Subjects.UpdateSubjectAnnotationsUseCase
{
    public class UpdateSubjectAnnotationsUseCaseResquestModel
    {
        public int subjectId { get; set; }
        public string annotations { get; set; }
    }
}