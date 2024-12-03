using ExamDAOnAbp.LearningOutcomeService.DTOs;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExamDAOnAbp.LearningOutcomeService.HttpClients.Departments
{
    public class DepartmentClientService
    {
        private readonly HttpClient _httpClient;

        public DepartmentClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DepartmentDto> FindDepartmentByName(string name)
        {
            var encodeName = Uri.EscapeDataString(name);
            var url = $"/api/department/find-name/{name}?name={encodeName}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DepartmentDto>(jsonString);
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
