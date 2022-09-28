using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuggestionApp.DataAccess.Dtos
{
    public class CategoryDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

    }
}
