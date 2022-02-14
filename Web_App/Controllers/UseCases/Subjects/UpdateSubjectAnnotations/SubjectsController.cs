using Application.UseCases.Subjects.UpdateSubjectAnnotationsUseCase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.Subjects.UpdateSubjectAnnotations
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly IUpdateSubjectAnnotationsUseCase updateSubjectAnnotationsUseCase;

        public SubjectsController(IUpdateSubjectAnnotationsUseCase updateSubjectAnnotationsUseCase)
        {
            this.updateSubjectAnnotationsUseCase = updateSubjectAnnotationsUseCase;
        }

        [HttpPost("UpdateAnnotations")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateSubjectAnnotationsUseCaseResquestModel requestModel
        )
        {
            await updateSubjectAnnotationsUseCase
                .UpdateSubjectAnnotations(requestModel);

            return Ok();
        }
    }
}