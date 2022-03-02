using DotnetMongoDB.Interfaces;
using DotnetMongoDB.Models;
using MongoDB.Driver;

namespace DotnetMongoDB.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMongoCollection<Course> _courses;

        public CourseService(ISchoolDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _courses = database.GetCollection<Course>(settings.StudentsCollectionName);
        }
        public async Task<Course> Create(Course course)
        {
            await _courses.InsertOneAsync(course);
            return course;
        }

        public async Task<Course> Get(string id)
        {
            return await _courses.Find<Course>(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Course>> GetAll()
        {
            return await _courses.Find(s => true).ToListAsync();
        }

        public async Task Remove(string id)
        {
            await _courses.DeleteOneAsync(s => s.Id == id);
        }

        public async Task Update(string id, Course course)
        {
            await _courses.ReplaceOneAsync(s => s.Id == id, course);
        }
    }
}
