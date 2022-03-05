using Domain.Entities;
using Domain.Enums;
using Domain.ReponseModels.Subject;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases.Subjects.GenerateSubjectCycleUseCase
{
    public class GenerateSubjectCycleUseCase : IGenerateSubjectCycleUseCase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ISubjectTaskRepository _subjectTaskRepository;
        private readonly IUnitWork _unitWork;

        private const int totalHourCycle = 14;

        public GenerateSubjectCycleUseCase(ISubjectRepository subjectRepository,
            IProjectRepository projectRepository,
            ISubjectTaskRepository subjectTaskRepository,
            IUnitWork unitWork)
        {
            _unitWork = unitWork;
            _projectRepository = projectRepository;
            _subjectTaskRepository = subjectTaskRepository;
        }

        public async Task GenerateSubjectCycle(int projectId)
        {
            var project = await _projectRepository.GetSubjectsProject(projectId);
            var subjects = project.Subjects;
            var totalPonderatedWeightScore = CalculateTotalPonderatedWeightScore(subjects);

            var cycleItems = GetCycleItems(subjects, totalPonderatedWeightScore);

            var organizedItems = OrganizeCycleItems(cycleItems);

            var subjectTasks = MapToSubjectTasks(organizedItems);

            await PersistCycleItems(subjectTasks);
        }

        private int CalculateTotalPonderatedWeightScore(List<Subject> subjects)
        {
            var totalPonderatedWeightScore = 0;
            foreach (Subject subject in subjects)
            {
                totalPonderatedWeightScore += GetPonderatedScore(subject);
            }
            return totalPonderatedWeightScore;
        }

        private List<GenerateSubjectCycleResponseModel> GetCycleItems(List<Subject> subjects, int totalPonderatedWeightScore)
        {
            var cycleItems = new List<GenerateSubjectCycleResponseModel>();

            foreach (Subject subject in subjects)
            {
                var ponderatedWeightScore = GetPonderatedScore(subject);

                int minutesStudy = ponderatedWeightScore * totalHourCycle * 60 / totalPonderatedWeightScore;

                var i = 1;
                while (minutesStudy / i > 60)
                    i++;

                var newMinutes = minutesStudy / i;

                for (int idx = 0; idx < i; idx++)
                {
                    cycleItems.Add(new GenerateSubjectCycleResponseModel
                    {
                        Subject = subject,
                        PonderatedWeightScore = ponderatedWeightScore,
                        MinutesStudy = newMinutes,
                        TotalItems = i
                    });
                }
            }

            cycleItems.Sort((e1, e2) =>
            {
                var result = e2.TotalItems.CompareTo(e1.TotalItems);
                return result == 0 ? e2.Subject.SubjectId.CompareTo(e2.Subject.SubjectId) : result;
            });

            return cycleItems;
        }

        private int GetPonderatedScore(Subject subject)
        {
            var score = subject.GetScore();
            if (score != 0)
                return subject.Weight * 100 / score;

            return subject.Weight;
        }

        private List<GenerateSubjectCycleResponseModel> OrganizeCycleItems(List<GenerateSubjectCycleResponseModel> subjects)
        {
            var listOfSubLists = new List<List<GenerateSubjectCycleResponseModel>>();
            var organizedItems = new List<GenerateSubjectCycleResponseModel>();

            var maxItemsOneSubject = subjects[0].TotalItems;

            for (int i = 0; i < maxItemsOneSubject; i++)
            {
                listOfSubLists.Add(new List<GenerateSubjectCycleResponseModel>());
            }

            int idx = 0;
            foreach (GenerateSubjectCycleResponseModel subject in subjects)
            {
                listOfSubLists[idx].Add(subject);
                idx = getNextIndex(maxItemsOneSubject - 1, idx);
            }

            foreach (List<GenerateSubjectCycleResponseModel> subList in listOfSubLists)
            {
                organizedItems = organizedItems.Concat(subList).ToList();
            }

            int internalOrder = 1;
            foreach (GenerateSubjectCycleResponseModel item in organizedItems)
            {
                item.InternalOrder = internalOrder;
                internalOrder++;
            }

            return organizedItems;
        }

        private static int getNextIndex(int total, int actual)
        {
            if (actual + 1 > total)
                return 0;

            return actual + 1;
        }

        private List<SubjectTask> MapToSubjectTasks(List<GenerateSubjectCycleResponseModel> cycleItems)
        {
            var tasks = new List<SubjectTask>();

            foreach (GenerateSubjectCycleResponseModel item in cycleItems)
            {
                tasks.Add(new SubjectTask
                {
                    Subject = item.Subject,
                    InternalOrder = item.InternalOrder,
                    MinutesStudy = item.MinutesStudy,
                    PonderatedWeightScore = item.PonderatedWeightScore,
                    Status = TaskEnum.TaskStatus.Ready,
                });
            }

            return tasks;
        }

        private async Task PersistCycleItems(List<SubjectTask> tasks)
        {
            await _subjectTaskRepository.InsertSubjectTasks(tasks);

            await _unitWork.SaveChanges();
        }
    }
}