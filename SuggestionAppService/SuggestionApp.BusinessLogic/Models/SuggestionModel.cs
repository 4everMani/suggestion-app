namespace SuggestionApp.BusinessLogic.Models
{
    public class SuggestionModel
    {
        public string Id { get; set; }
        public string Suggestion { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public CategoryModel Category { get; set; }
        public BasicUserModel Author { get; set; }
        public HashSet<string> UserVotes { get; set; }
        public StatusModel SuggestionStatus { get; set; }
        public string OwnerNotes { get; set; }
        public bool ApprovedForRelease { get; set; }
        public bool Archived { get; set; }
        public bool Rejected { get; set; }
    }
}
