using ExamDAOnAbp.LearningOutcomeService.DTOs;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.LearningOutcomeService.HttpClients
{
    public class DepartmentClientService
    {
        private readonly HttpClient _httpClient;

        public DepartmentClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ListResultDto<DepartmentDto>> GetListDepartments()
        {
            var url = "api/departments";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListResultDto<DepartmentDto>>(jsonString);
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
