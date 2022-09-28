using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuggestionApp.DataAccess.Dtos
{
    public class SuggestionDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Suggestion { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public CategoryDTO Category { get; set; }
        public BasicUserDTO Author { get; set; }
        public HashSet<string> UserVotes { get; set; } = new();
        public StatusDTO SuggestionStatus { get; set; }
        public string OwnerNotes { get; set; }
        public bool ApprovedForRelease { get; set; } = false;
        public bool Archived { get; set; } = false;
        public bool Rejected { get; set; } = false;
    }
}
