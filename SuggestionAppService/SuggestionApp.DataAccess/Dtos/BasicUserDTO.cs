using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuggestionApp.DataAccess.Dtos
{
    public class BasicUserDTO
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public BasicUserDTO()
        {

        }

        public BasicUserDTO(UserDTO user)
        {
            Id = user.Id;
            DisplayName = user.DisplayName;
        }

    }
}
