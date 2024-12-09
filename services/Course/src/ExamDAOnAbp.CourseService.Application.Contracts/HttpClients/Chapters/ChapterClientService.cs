using ExamDAOnAbp.CourseService.DTOs;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.CourseService.HttpClients.Chapters
{
    public class ChapterClientService
    {
        private readonly HttpClient _httpClient;

        public ChapterClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ChapterDto> FindChapterByName(string name)
        {
            var encodeName = Uri.EscapeDataString(name);
            var url = $"/api/chapter/find-name/{name}?name={encodeName}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ChapterDto>(jsonString);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return null;
        }

        public async Task<ListResultDto<ChapterDto>> GetListChapters()
        {
            var url = "/api/chapters";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListResultDto<ChapterDto>>(jsonString);
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
