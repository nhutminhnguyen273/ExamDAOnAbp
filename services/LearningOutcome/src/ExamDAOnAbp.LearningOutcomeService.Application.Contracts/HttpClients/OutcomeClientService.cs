using ExamDAOnAbp.LearningOutcomeService.DTOs;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.LearningOutcomeService.HttpClients
{
    public class OutcomeClientService
    {
        private readonly HttpClient _httpClient;

        public OutcomeClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ListResultDto<OutcomeDto>> GetListOutcomes()
        {
            var url = "api/outcomes";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListResultDto<OutcomeDto>>(jsonString);
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
