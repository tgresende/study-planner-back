using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Topics.AddTopicUseCase
{
    public class AddNewTopicRequestModel
    {
        public string Name { get; set; }
        public string Anotations { get; set; }
        public int SubjectId { get; set; }
    }
}