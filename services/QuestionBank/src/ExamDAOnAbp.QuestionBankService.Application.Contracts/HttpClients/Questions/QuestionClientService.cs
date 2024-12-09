using System.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ExamDAOnAbp.QuestionBankService.DTOs;
using Newtonsoft.Json;
using Volo.Abp.Application.Dtos;
using System.Text;
using System.Xml.Linq;
using System.Net.Http.Json;

namespace ExamDAOnAbp.QuestionBankService.HttpClients.Questions
{
    public class QuestionClientService
    {
        private readonly HttpClient _httpClient;

        public QuestionClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<QuestionDto> FindQuestionByName(string name)
        {
            var encodeName = Uri.EscapeDataString(name);
            var url = $"/api/question/find-name/{name}?name={encodeName}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<QuestionDto>(jsonString);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return null;
        }

        public async Task<ListResultDto<QuestionDto>> GetListQuestions()
        {
            var url = "/api/questions";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListResultDto<QuestionDto>>(jsonString);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return null;
        }

        //public async Task<ListResultDto<QuestionDto>> GetListQuestionByCourseId()
        //{

        //}

        public async Task UpdateQuestionDifficultyLevel(Guid id, string difficultyLevel)
        {
            var url = $"api/update-difficulty/{id}"; // Đảm bảo endpoint của bạn hợp lệ

            var updateRequest = new
            {
                Id = id,
                DifficultyLevel = difficultyLevel
            };

            // Gửi yêu cầu PUT hoặc PATCH (tùy thuộc vào API của bạn)
            var response = await _httpClient.PutAsJsonAsync(url, updateRequest);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Độ khó của câu hỏi đã được cập nhật thành công.");
            }
            else
            {
                // Nếu có lỗi, ném ngoại lệ hoặc log lỗi
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Cập nhật độ khó cho câu hỏi thất bại: {errorMessage}");
            }
        }
    }
}
