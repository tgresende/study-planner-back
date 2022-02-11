using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.TopicTask
{
    public class ActionTypes
    {
        public const string Reading = "Leitura";
        public const string RevisionQuestions = "Questões de Revisão";
        public const string Exercises = "Questões";

        public List<string> GetActionsList()
        {
            return new List<string> { Reading, RevisionQuestions, Exercises };
        }
    }
}