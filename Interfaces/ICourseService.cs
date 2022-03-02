using DotnetMongoDB.Models;

namespace DotnetMongoDB.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetAll();
        Task<Course> Get(string id);
        Task<Course> Create(Course course);
        Task Update(string id, Course course);
        Task Remove(string id);
    }
}
