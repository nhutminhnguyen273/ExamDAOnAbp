using ExamDAOnAbp.CourseService.DTOs;
using System.Threading.Tasks;

namespace ExamDAOnAbp.CourseService.Interfaces.HttpClients
{
    public interface ICourseClientService
    {
        Task<CourseDto> FindCourseByName(string name);
    }
}
