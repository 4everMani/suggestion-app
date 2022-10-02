using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuggestionApp.WebApi.Dtos
{
    public class BasicSuggestionDTO
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Suggestion { get; set; }

        public BasicSuggestionDTO()
        {

        }

        public BasicSuggestionDTO(SuggestionDTO suggestion)
        {
            Id = suggestion.Id;
            Suggestion = suggestion.Suggestion;
        }

    }

   


}
