using Application.UseCases.Topics.GetTopicsFromSubjectUseCase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.Topics.GetTopicsFromProject
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly IGetTopicsFromSubjectUseCase getTopicsFromSubject;

        public TopicsController(IGetTopicsFromSubjectUseCase getTopicsFromSubject)
        {
            this.getTopicsFromSubject = getTopicsFromSubject;
        }

        [HttpGet("GetTopicsFromSubject/{subjectId}")]
        public async Task<IActionResult> Get(int subjectId)
        {
            var data = await getTopicsFromSubject.GetTopicsFromSubject(subjectId);
            return Ok(data);
        }
    }
}