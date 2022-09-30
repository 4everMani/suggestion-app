using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.BusinessLogic.Models
{
    public class BasicSuggestionModel
    {
        public string Id { get; set; }
        public string Suggestion { get; set; }

        public BasicSuggestionModel()
        {

        }

        public BasicSuggestionModel(SuggestionModel suggestion)
        {
            Id = suggestion.Id;
            Suggestion = suggestion.Suggestion;
        }
    }
}
