using DotnetMongoDB.Dtos;
using DotnetMongoDB.Models;

namespace DotnetMongoDB.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Task<Student> Get(string id);
        Task<Student> Create(Student student);
        Task Update(string id, Student student);
        Task Remove(string id);
    }
}
