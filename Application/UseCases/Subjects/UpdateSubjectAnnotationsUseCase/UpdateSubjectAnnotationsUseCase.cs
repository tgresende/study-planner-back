using Domain.Entities;
using Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Application.UseCases.Subjects.UpdateSubjectAnnotationsUseCase
{
    public class UpdateSubjectAnnotationsUseCase : IUpdateSubjectAnnotationsUseCase
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly IUnitWork unitWork;

        public UpdateSubjectAnnotationsUseCase(
            ISubjectRepository subjectRepository,
            IUnitWork unitWork)
        {
            this.subjectRepository = subjectRepository;
            this.unitWork = unitWork;
        }

        public async Task UpdateSubjectAnnotations(UpdateSubjectAnnotationsUseCaseResquestModel requestModel)
        {
            Subject sub = await subjectRepository.GetSubject(requestModel.subjectId);

            if (sub == null)
                return;

            sub.Annotations = requestModel.annotations;

            await unitWork.SaveChanges();
        }
    }
}