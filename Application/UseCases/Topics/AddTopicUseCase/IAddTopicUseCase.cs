using System.Threading.Tasks;

namespace Application.UseCases.Topics.AddTopicUseCase
{
    public interface IAddTopicUseCase
    {
        Task<AddTopicResponseModel> InsertTopic(AddNewTopicRequestModel requestModel);
    }
}