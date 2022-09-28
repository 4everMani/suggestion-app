namespace SuggestionApp.BusinessLogic.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string ObjectIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public int MyProperty { get; set; }
        public List<BasicSuggestionModel> AuthoredSuggestions { get; set; }
        public List<BasicSuggestionModel> VotedSuggestions { get; set; }
    }
}
