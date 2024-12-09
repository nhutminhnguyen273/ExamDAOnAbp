using ExamDAOnAbp.ExamService.DTOs;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.HttpClients
{
    public class ExamPaperClientService
    {
        private readonly HttpClient _httpClient;

        public ExamPaperClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ListResultDto<ExamPaperDto>> GetListExamPaper()
        {
            var url = "/api/exam-papers";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListResultDto<ExamPaperDto>>(jsonString);
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
