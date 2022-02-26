using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotnetMongoDB.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        public string FirstName { get; set; }  = String.Empty;
        public string LastName { get; set; }
        public string Major { get; set; } = String.Empty;

    }
}
