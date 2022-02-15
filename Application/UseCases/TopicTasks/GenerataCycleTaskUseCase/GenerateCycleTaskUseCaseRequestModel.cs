using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.GenerataCycleTaskUseCase
{
    public class GenerateCycleTaskUseCaseRequestModel
    {
        public int TopicId { get; set; }
        public string Score { get; set; }
    }
}