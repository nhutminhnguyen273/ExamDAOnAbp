using System.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ExamDAOnAbp.QuestionBankService.DTOs;
using Newtonsoft.Json;

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
    }
}
