using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DotnetMongoDB.Dtos
{
    public class StudentDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = String.Empty;
        public string Major { get; set; } = String.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Courses { get; set; }
    }
}
