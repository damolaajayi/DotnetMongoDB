namespace DotnetMongoDB.Models
{
    public class SchoolDatabaseSettings : ISchoolDatabaseSettings
    {
        public string? StudentsCollectionName { get; set; } = String.Empty;
        public string? CoursesCollectionName { get; set; } = String.Empty;
        public string? ConnectionString { get; set; } = String.Empty;
        public string? DatabaseName { get; set; } = String.Empty;
    }
}
