using ExamDAOnAbp.ExamService.DTOs;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.HttpClients
{
    public class ExamClientService
    {
        private readonly HttpClient _httpClient;

        public ExamClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ListResultDto<ExamDto>> GetListExams()
        {
            var url = "/api/exams";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListResultDto<ExamDto>>(jsonString);
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
