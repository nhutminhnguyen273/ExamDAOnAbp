using System.Collections.Generic;
using System;
using System.Linq;
using ExamDAOnAbp.ExamService.Entities;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using ExamDAOnAbp.QuestionBankService.Entities;
using MathNet.Numerics.Statistics;
using Volo.Abp.Application.Services;
using ExamDAOnAbp.ExamService.Interfaces.PSO;
using ExamDAOnAbp.QuestionBankService.HttpClients.Questions;

namespace ExamDAOnAbp.ExamService.PSO;

public class PSOAlgorithm : ApplicationService, IPSOAlgorithm
{
    private readonly IRepository<ExamPaper, Guid> _examPaperRepository;
    private readonly QuestionClientService _questionClientService;

    public PSOAlgorithm(IRepository<ExamPaper, Guid> examPaperRepository, QuestionClientService questionClientService)
    {
        _examPaperRepository = examPaperRepository;
        _questionClientService = questionClientService;
    }

    public async Task GenerateExamPaperAsync(Guid courseId, string examCode, TimeSpan examDuration, int numQuestions)
    {
        var listQuestionsResult = await _questionClientService.GetListQuestions();

        if (listQuestionsResult == null || listQuestionsResult.Items == null || !listQuestionsResult.Items.Any())
        {
            throw new UserFriendlyException("Not enough questions available from the service.");
        }

        var availableQuestions = listQuestionsResult.Items
            .Select(q => new Question
            (
                q.Id,
                q.DifficultyLevel,
                q.CLO
            ))
            .ToList();

        var particles = InitializeParticles(availableQuestions, numQuestions);
        var optimalSolution = RunPSO(particles, numQuestions);

        foreach (var question in optimalSolution)
        {
            var examPaper = new ExamPaper
            {
                Code = examCode,
                CourseId = courseId,
                Time = examDuration,
                QuestionId = question.Id
            };

            await _examPaperRepository.InsertAsync(examPaper);
        }
    }

    private List<Particle> InitializeParticles(List<Question> questions, int numQuestions)
    {
        var particles = new List<Particle>();

        for (int i = 0; i < 10; i++)
        {
            var randomQuestions = questions.OrderBy(q => Guid.NewGuid()).Take(numQuestions).ToList();
            particles.Add(new Particle
            {
                Position = randomQuestions,
                BestPosition = randomQuestions,
                BestScore = Evaluate(randomQuestions)
            });
        }

        return particles;
    }

    private List<Question> RunPSO(List<Particle> particles, int numQuestions)
    {
        var globalBestPosition = particles.OrderBy(p => p.BestScore).First().BestPosition;
        var globalBestScore = Evaluate(globalBestPosition);

        for (int iteration = 0; iteration < 100; iteration++)
        {
            foreach (var particle in particles)
            {
                var newPosition = particle.Position.OrderBy(q => Guid.NewGuid()).Take(numQuestions).ToList();
                var newScore = Evaluate(newPosition);

                if (newScore < particle.BestScore)
                {
                    particle.BestPosition = newPosition;
                    particle.BestScore = newScore;
                }

                if (newScore < globalBestScore)
                {
                    globalBestPosition = newPosition;
                    globalBestScore = newScore;
                }

                particle.Position = newPosition;
            }
        }

        return globalBestPosition;
    }

    private double Evaluate(List<Question> questions)
    {
        var difficultyCounts = questions
            .GroupBy(q => q.DifficultyLevel)
            .Select(g => (double)g.Count())
            .ToList();

        var cloCoverage = questions.Select(q => q.CLO).Distinct().Count();

        var difficultyVariance = Statistics.Variance(difficultyCounts);
        return difficultyVariance - cloCoverage;
    }
}

public class Particle
{
    public List<Question> Position { get; set; }
    public List<Question> BestPosition { get; set; }
    public double BestScore { get; set; }
}
