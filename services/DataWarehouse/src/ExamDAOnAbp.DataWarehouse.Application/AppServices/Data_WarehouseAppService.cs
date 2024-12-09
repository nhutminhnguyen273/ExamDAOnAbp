using ExamDAOnAbp.DataWarehouse.DTOs;
using ExamDAOnAbp.DataWarehouse.Entities;
using ExamDAOnAbp.DataWarehouse.Interfaces;
using ExamDAOnAbp.ExamService.HttpClients;
using ExamDAOnAbp.QuestionBankService.AppServices.QuestionAppServices;
using ExamDAOnAbp.QuestionBankService.HttpClients.Questions;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace ExamDAOnAbp.DataWarehouse.AppServices
{
    public class Data_WarehouseAppService : ApplicationService, IDataWarehouseAppService
    {
        private readonly IHubContext<DataWarehouseHub> _hubContext;
        private readonly IObjectMapper _objectMapper;
        private readonly IRepository<DimAnswer, Guid> _dimAnswerRepository;
        private readonly IRepository<DimQuestion, Guid> _dimQuestionRepository;
        private readonly IRepository<DimStudent, Guid> _dimStudentRepository;
        private readonly IRepository<DimExam, Guid> _dimExamDtoRepository;
        private readonly IRepository<FactExamResult, Guid> _factExamResultRepository;
        private readonly AnswerClientService _answerSerivce;
        private readonly QuestionClientService _questionService;
        private readonly StudentClientService _studentService;
        private readonly ExamClientService _examService;
        private readonly ExamResultClientService _examResultService;

        public Data_WarehouseAppService(IHubContext<DataWarehouseHub> hubContext, IObjectMapper objectMapper,
            IRepository<DimAnswer, Guid> dimAnswerRepository, IRepository<DimQuestion, Guid> dimQuestionRepository,
            IRepository<DimStudent, Guid> dimStudentRepository, IRepository<DimExam, Guid> dimExamDtoRepository,
            IRepository<FactExamResult, Guid> factExamResultRepository, AnswerClientService answerSerivce, QuestionClientService questionService,
            StudentClientService studentService, ExamClientService examService, ExamResultClientService examResultService)
        {
            _hubContext = hubContext;
            _objectMapper = objectMapper;
            _dimAnswerRepository = dimAnswerRepository;
            _dimQuestionRepository = dimQuestionRepository;
            _dimStudentRepository = dimStudentRepository;
            _dimExamDtoRepository = dimExamDtoRepository;
            _factExamResultRepository = factExamResultRepository;
            _answerSerivce = answerSerivce;
            _questionService = questionService;
            _studentService = studentService;
            _examService = examService;
            _examResultService = examResultService;
        }

        //public async Task SyncExamDataAsync()
        //{
        //    try
        //    {
        //        // Lấy dữ liệu từ các microservices
        //        var answerDto = await _answerSerivce.GetListAnswers();
        //        var questionDto = await _questionService.GetListQuestions();
        //        var studentDto = await _studentService.GetListStudents();
        //        var examDto = await _examService.GetListExams();
        //        var examResultsDto = await _examResultService.GetListExamResults();

        //        var answers = answerDto.Items.ToList();
        //        var questions = questionDto.Items.ToList();
        //        var students = studentDto.Items.ToList();
        //        var exams = examDto.Items.ToList();
        //        var examResults = examResultsDto.Items.ToList();

        //        // Chuyển đổi dữ liệu từ DTO sang entity tương ứng (DimAnswer, DimQuestion, DimStudent, DimExam, FactExamResults)

        //        // Thêm DimStudent trước vì FactExamResults tham chiếu đến DimStudent
        //        var dimStudents = students.Select(student => new DimStudent
        //        (
        //            student.Id,
        //            student.Code,
        //            student.FullName,
        //            student.DateOfBirth,
        //            student.Gender,
        //            student.Email,
        //            student.Phone
        //        )).ToList();
        //        await _dimStudentRepository.InsertManyAsync(dimStudents); // Chèn dữ liệu vào kho dữ liệu

        //        // Thêm DimExam trước vì FactExamResults tham chiếu đến DimExam
        //        var dimExams = exams.Select(exam => new DimExam
        //        (
        //            exam.Id,
        //            exam.Session,
        //            exam.Date,
        //            exam.StartTime,
        //            exam.EndTime,
        //            exam.Room,
        //            exam.CourseId,
        //            exam.NumberOfStudents
        //        )).ToList();
        //        await _dimExamDtoRepository.InsertManyAsync(dimExams); // Chèn dữ liệu vào kho dữ liệu

        //        // Thêm DimQuestion trước để đảm bảo DimAnswer có thể tham chiếu đến DimQuestion
        //        var dimQuestions = questions.Select(question => new DimQuestion
        //        (
        //            question.Id,
        //            question.Type,
        //            question.Content,
        //            question.ChapterId,
        //            question.CLO,
        //            question.DifficultyLevel
        //        )).ToList();
        //        await _dimQuestionRepository.InsertManyAsync(dimQuestions); // Chèn dữ liệu vào kho dữ liệu

        //        // Thêm DimAnswer sau DimQuestion
        //        var dimAnswers = answers.Select(answer => new DimAnswer
        //        (
        //            answer.Id,
        //            answer.Content,
        //            answer.IsCorrect,
        //            answer.QuestionId
        //        )).ToList();
        //        await _dimAnswerRepository.InsertManyAsync(dimAnswers); // Chèn dữ liệu vào kho dữ liệu

        //        // Thêm FactExamResults cuối cùng sau khi các bảng Dim đã được thêm
        //        var factExamResults = examResults.Select(examResult => new FactExamResult
        //        (
        //            examResult.Id,
        //            examResult.StudentId,
        //            examResult.ExamId,
        //            examResult.ExamPaperId,
        //            examResult.QuestionId,
        //            examResult.IsCorrect,
        //            examResult.Score
        //        )).ToList();
        //        await _factExamResultRepository.InsertManyAsync(factExamResults); // Chèn dữ liệu vào kho dữ liệu

        //        // Thông báo cho client rằng việc đồng bộ dữ liệu đã hoàn tất
        //        await _hubContext.Clients.All.SendAsync("DataSynced", "Dữ liệu thi đã được đồng bộ thành công.");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log lỗi nếu có sự cố
        //        Logger.LogError(ex, "Đã xảy ra lỗi khi đồng bộ dữ liệu thi.");
        //        throw; // Rethrow lỗi hoặc xử lý tùy theo yêu cầu
        //    }
        //}

        public async Task SyncExamDataAsync()
        {
            try
            {
                // Lấy dữ liệu từ các microservices
                var answerDto = await _answerSerivce.GetListAnswers();
                var questionDto = await _questionService.GetListQuestions();
                var studentDto = await _studentService.GetListStudents();
                var examDto = await _examService.GetListExams();
                var examResultsDto = await _examResultService.GetListExamResults();

                var answers = answerDto.Items.ToList();
                var questions = questionDto.Items.ToList();
                var students = studentDto.Items.ToList();
                var exams = examDto.Items.ToList();
                var examResults = examResultsDto.Items.ToList();

                // Đồng bộ DimStudent
                var existingStudents = await _dimStudentRepository.GetListAsync();
                var newStudents = new List<DimStudent>();
                var updatedStudents = new List<DimStudent>();

                foreach (var student in students)
                {
                    var existing = existingStudents.FirstOrDefault(s => s.Id == student.Id);
                    var dimStudent = new DimStudent(
                        student.Id, // ID không thay đổi
                        student.Code,
                        student.FullName,
                        student.DateOfBirth,
                        student.Gender,
                        student.Email,
                        student.Phone
                    );

                    if (existing == null)
                    {
                        newStudents.Add(dimStudent);
                    }
                    else
                    {
                        // Chỉ cập nhật các thuộc tính khác mà không thay đổi ID
                        if (!existing.Equals(dimStudent)) // Giả sử bạn đã override Equals
                        {
                            existing.Code = dimStudent.Code;
                            existing.FullName = dimStudent.FullName;
                            existing.DateOfBirth = dimStudent.DateOfBirth;
                            existing.Gender = dimStudent.Gender;
                            existing.Email = dimStudent.Email;
                            existing.Phone = dimStudent.Phone;

                            updatedStudents.Add(existing);
                        }
                    }
                }

                if (newStudents.Any())
                    await _dimStudentRepository.InsertManyAsync(newStudents);

                if (updatedStudents.Any())
                    await _dimStudentRepository.UpdateManyAsync(updatedStudents);

                // Đồng bộ DimExam
                var existingExams = await _dimExamDtoRepository.GetListAsync();
                var newExams = new List<DimExam>();
                var updatedExams = new List<DimExam>();

                foreach (var exam in exams)
                {
                    var existing = existingExams.FirstOrDefault(e => e.Id == exam.Id);
                    var dimExam = new DimExam(
                        exam.Id, // ID không thay đổi
                        exam.Session,
                        exam.Date,
                        exam.StartTime,
                        exam.EndTime,
                        exam.Room,
                        exam.CourseId,
                        exam.NumberOfStudents
                    );

                    if (existing == null)
                    {
                        newExams.Add(dimExam);
                    }
                    else
                    {
                        // Chỉ cập nhật các thuộc tính khác mà không thay đổi ID
                        if (!existing.Equals(dimExam)) // Giả sử bạn đã override Equals
                        {
                            existing.Session = dimExam.Session;
                            existing.Date = dimExam.Date;
                            existing.StartTime = dimExam.StartTime;
                            existing.EndTime = dimExam.EndTime;
                            existing.Room = dimExam.Room;
                            existing.CourseId = dimExam.CourseId;
                            existing.NumberOfStudents = dimExam.NumberOfStudents;

                            updatedExams.Add(existing);
                        }
                    }
                }

                if (newExams.Any())
                    await _dimExamDtoRepository.InsertManyAsync(newExams);

                if (updatedExams.Any())
                    await _dimExamDtoRepository.UpdateManyAsync(updatedExams);

                // Đồng bộ DimQuestion
                var existingQuestions = await _dimQuestionRepository.GetListAsync();
                var newQuestions = new List<DimQuestion>();
                var updatedQuestions = new List<DimQuestion>();

                foreach (var question in questions)
                {
                    var existing = existingQuestions.FirstOrDefault(q => q.Id == question.Id);
                    var dimQuestion = new DimQuestion(
                        question.Id, // ID không thay đổi
                        question.Type,
                        question.Content,
                        question.ChapterId,
                        question.CLO,
                        question.DifficultyLevel
                    );

                    if (existing == null)
                    {
                        newQuestions.Add(dimQuestion);
                    }
                    else
                    {
                        // Chỉ cập nhật các thuộc tính khác mà không thay đổi ID
                        if (!existing.Equals(dimQuestion)) // Giả sử bạn đã override Equals
                        {
                            existing.Type = dimQuestion.Type;
                            existing.Content = dimQuestion.Content;
                            existing.ChapterId = dimQuestion.ChapterId;
                            existing.CLO = dimQuestion.CLO;
                            existing.DifficultyLevel = dimQuestion.DifficultyLevel;

                            updatedQuestions.Add(existing);
                        }
                    }
                }

                if (newQuestions.Any())
                    await _dimQuestionRepository.InsertManyAsync(newQuestions);

                if (updatedQuestions.Any())
                    await _dimQuestionRepository.UpdateManyAsync(updatedQuestions);

                // Đồng bộ DimAnswer
                var existingAnswers = await _dimAnswerRepository.GetListAsync();
                var newAnswers = new List<DimAnswer>();
                var updatedAnswers = new List<DimAnswer>();

                foreach (var answer in answers)
                {
                    var existing = existingAnswers.FirstOrDefault(a => a.Id == answer.Id);
                    var dimAnswer = new DimAnswer(
                        answer.Id, // ID không thay đổi
                        answer.Content,
                        answer.IsCorrect,
                        answer.QuestionId
                    );

                    if (existing == null)
                    {
                        newAnswers.Add(dimAnswer);
                    }
                    else
                    {
                        // Chỉ cập nhật các thuộc tính khác mà không thay đổi ID
                        if (!existing.Equals(dimAnswer)) // Giả sử bạn đã override Equals
                        {
                            existing.Content = dimAnswer.Content;
                            existing.IsCorrect = dimAnswer.IsCorrect;
                            existing.QuestionId = dimAnswer.QuestionId;

                            updatedAnswers.Add(existing);
                        }
                    }
                }

                if (newAnswers.Any())
                    await _dimAnswerRepository.InsertManyAsync(newAnswers);

                if (updatedAnswers.Any())
                    await _dimAnswerRepository.UpdateManyAsync(updatedAnswers);

                // Đồng bộ FactExamResults
                var existingExamResults = await _factExamResultRepository.GetListAsync();
                var newExamResults = new List<FactExamResult>();
                var updatedExamResults = new List<FactExamResult>();

                foreach (var examResult in examResults)
                {
                    var existing = existingExamResults.FirstOrDefault(er => er.Id == examResult.Id);
                    var factExamResult = new FactExamResult(
                        examResult.Id, // ID không thay đổi
                        examResult.StudentId,
                        examResult.ExamId,
                        examResult.ExamPaperId,
                        examResult.QuestionId,
                        examResult.IsCorrect,
                        examResult.Score
                    );

                    if (existing == null)
                    {
                        newExamResults.Add(factExamResult);
                    }
                    else
                    {
                        // Chỉ cập nhật các thuộc tính khác mà không thay đổi ID
                        if (!existing.Equals(factExamResult)) // Giả sử bạn đã override Equals
                        {
                            existing.StudentId = factExamResult.StudentId;
                            existing.ExamId = factExamResult.ExamId;
                            existing.ExamPaperId = factExamResult.ExamPaperId;
                            existing.QuestionId = factExamResult.QuestionId;
                            existing.IsCorrect = factExamResult.IsCorrect;
                            existing.Score = factExamResult.Score;

                            updatedExamResults.Add(existing);
                        }
                    }
                }

                if (newExamResults.Any())
                    await _factExamResultRepository.InsertManyAsync(newExamResults);

                if (updatedExamResults.Any())
                    await _factExamResultRepository.UpdateManyAsync(updatedExamResults);

                // Thông báo cho client rằng việc đồng bộ dữ liệu đã hoàn tất
                await _hubContext.Clients.All.SendAsync("DataSynced", "Dữ liệu thi đã được đồng bộ thành công.");
            }
            catch (Exception ex)
            {
                // Log lỗi nếu có sự cố
                Logger.LogError(ex, "Đã xảy ra lỗi khi đồng bộ dữ liệu thi.");
                throw; // Rethrow lỗi hoặc xử lý tùy theo yêu cầu
            }
        }

        public async Task<List<StudentExamStatsDto>> GetStudentAverageScoresAsync()
        {
            // Đợi kết quả trả về từ GetListAsync
            var factExamResults = await _factExamResultRepository.GetListAsync();

            // Thực hiện thao tác LINQ trên danh sách đã được lấy
            var studentStats = factExamResults
                .GroupBy(fact => fact.StudentId)  // Group by StudentId
                .Select(studentGroup => new StudentExamStatsDto
                {
                    StudentId = studentGroup.Key,
                    AverageScore = studentGroup.Average(f => f.Score)
                })
                .ToList();  // Chuyển đổi thành danh sách

            return studentStats;
        }

        public async Task<List<QuestionStatsDto>> GetQuestionStatsAsync()
        {
            // Lấy danh sách kết quả thi
            var factExamResults = await _factExamResultRepository.GetListAsync();

            // Thực hiện nhóm theo QuestionId và tính toán các chỉ số cần thiết
            var questionStats = factExamResults
                .GroupBy(fact => fact.QuestionId)  // Nhóm theo QuestionId
                .Select(questionGroup => new QuestionStatsDto
                {
                    QuestionId = questionGroup.Key,
                    CorrectAnswers = questionGroup.Count(f => f.IsCorrect), // Số câu trả lời đúng
                    TotalAnswers = questionGroup.Count(), // Tổng số câu trả lời
                    CorrectPercentage = (float)questionGroup.Count(f => f.IsCorrect) / questionGroup.Count() * 100 // Tỉ lệ đúng
                })
                .ToList();  // Chuyển đổi thành danh sách

            return questionStats;
        }

        public async Task<ListResultDto<QuestionDifficultyDto>> GetQuestionDifficultyAsync()
        {
            // Fetch the exam results asynchronously from the repository
            var factExamResults = await _factExamResultRepository.GetListAsync(); // Ensure GetListAsync is available

            // Perform LINQ operation to calculate the difficulty level
            var questionDifficulty = factExamResults
                .GroupBy(fact => fact.QuestionId)
                .Select(questionGroup => new
                {
                    QuestionId = questionGroup.Key,
                    DifficultyLevel = CalculateDifficultyLevel(questionGroup) // Your custom method for calculating difficulty level
                })
                .ToList(); // Synchronously convert the result to a list

            // Update the difficulty level in the DimQuestion table
            foreach (var item in questionDifficulty)
            {
                // Fetch the existing DimQuestion from the repository
                var dimQuestion = await _dimQuestionRepository.GetAsync(item.QuestionId);
                if (dimQuestion != null)
                {
                    // Update the difficulty level in DimQuestion
                    dimQuestion.DifficultyLevel = item.DifficultyLevel;
                    await _dimQuestionRepository.UpdateAsync(dimQuestion);
                }

                // Call the UpdateQuestionDifficultyAsync method of QuestionBankService to update the difficulty
            }

            // Return the results in the required format
            return new ListResultDto<QuestionDifficultyDto>(questionDifficulty.Select(q => new QuestionDifficultyDto
            {
                QuestionId = q.QuestionId,
                DifficultyLevel = q.DifficultyLevel
            }).ToList());
        }

        //public async Task<List<QuestionDifficultyDto>> GetQuestionDifficultyAsync()
        //{
        //    // Chờ kết quả từ GetListAsync
        //    var factExamResults = await _factExamResultRepository.GetListAsync();

        //    // Sử dụng LINQ trên danh sách đã tải
        //    var questionDifficulty = factExamResults
        //        .GroupBy(fact => fact.QuestionId)
        //        .Select(group => new QuestionDifficultyDto
        //        {
        //            QuestionId = group.Key,
        //            DifficultyLevel = CalculateDifficultyLevel(group)
        //        })
        //        .ToList();

        //    return questionDifficulty;
        //}

        //public async Task UpdateQuestionDifficultyAsync()
        //{
        //    // Chờ kết quả từ GetListAsync
        //    var factExamResults = await _factExamResultRepository.GetListAsync();

        //    // Sử dụng LINQ để tính toán độ khó
        //    var questionDifficulty = factExamResults
        //        .GroupBy(fact => fact.QuestionId)
        //        .Select(group => new
        //        {
        //            QuestionId = group.Key,
        //            DifficultyLevel = CalculateDifficultyLevel(group)
        //        })
        //        .ToList();

        //    // Cập nhật song song
        //    var updateTasks = questionDifficulty.Select(q =>
        //        _updateQuestionDifficulty.UpdateAsync(q.QuestionId, q.DifficultyLevel));
        //    await Task.WhenAll(updateTasks); // Chạy đồng thời
        //}


        private string CalculateDifficultyLevel(IGrouping<Guid, FactExamResult> questionGroup)
        {
            var correctPercentage = (float)questionGroup.Count(f => f.IsCorrect) / questionGroup.Count() * 100;

            if (correctPercentage >= 80)
                return "Dễ";
            else if (correctPercentage >= 50)
                return "Trung bình";
            else
                return "Khó";
        }
    }
}
