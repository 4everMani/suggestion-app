using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuggestionApp.DataAccess.Dtos
{
    public class StatusDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
    }
}
