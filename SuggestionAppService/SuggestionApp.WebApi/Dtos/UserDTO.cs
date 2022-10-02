using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SuggestionApp.WebApi.Dtos
{
    public class UserDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ObjectIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public List<BasicSuggestionDTO> AuthoredSuggestions { get; set; } = new();
        public List<BasicSuggestionDTO> VotedSuggestions { get; set; } = new();
    }
}
