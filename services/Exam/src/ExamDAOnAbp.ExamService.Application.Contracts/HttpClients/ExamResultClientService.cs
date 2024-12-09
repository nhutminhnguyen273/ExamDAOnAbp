using ExamDAOnAbp.ExamService.DTOs;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.HttpClients
{
    public class ExamResultClientService 
    {
        private readonly HttpClient _httpClient;

        public ExamResultClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ListResultDto<ExamResultDto>> GetListExamResults()
        {
            var url = "/api/exam-results";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListResultDto<ExamResultDto>>(jsonString);
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
