using System.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ExamDAOnAbp.CourseService.DTOs;
using Newtonsoft.Json;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.CourseService.HttpClients.Courses
{
    public class CourseClientService
    {
        private readonly HttpClient _httpClient;

        public CourseClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CourseDto> FindCourseByName(string name)
        {
            var encodeName = Uri.EscapeDataString(name);
            var url = $"/api/course/find-name/{name}?name={encodeName}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CourseDto>(jsonString);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return null;
        }

        public async Task<ListResultDto<CourseDto>> GetListCourses()
        {
            var url = "/api/courses";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListResultDto<CourseDto>>(jsonString);
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
