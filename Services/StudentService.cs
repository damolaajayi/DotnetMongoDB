using DotnetMongoDB.Dtos;
using DotnetMongoDB.Models;
using MongoDB.Driver;

namespace DotnetMongoDB.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(ISchoolDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentsCollectionName);
        }

        public async Task<Student> Create(Student student)
        {
            await _students.InsertOneAsync(student);
            return student;
        }

        public async Task<Student> Get(string id)
        {
            return await _students.Find<Student>(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Student>> GetAll()
        {
            return await _students.Find(s => true).ToListAsync();
        }

        public async Task Remove(string id)
        {
            await _students.DeleteOneAsync(s => s.Id == id);
        }

        public async Task Update(string id, Student student)
        {
            await _students.ReplaceOneAsync(s => s.Id == id, student);
        }
    }
}
