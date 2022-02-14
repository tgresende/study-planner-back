using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Annotations { get; set; }
        public Project Project { get; set; }
        public List<Topic> Topics { get; set; }
    }
}