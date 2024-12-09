using ExamDAOnAbp.DataWarehouse.DTOs;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.DataWarehouse.HttpClients
{
    public class DataWarehouseClientService
    {
        private readonly HttpClient _httpClient;

        public DataWarehouseClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ListResultDto<QuestionDifficultyDto>> GetListQuestions()
        {
            var url = "api/data-warehouse/question-difficulty";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListResultDto<QuestionDifficultyDto>>(jsonString);
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
