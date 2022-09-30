using SuggestionApp.DataAccess.Dtos;

namespace SuggestionApp.BusinessLogic.Models
{
    public class BasicUserModel
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }

        public BasicUserModel()
        {

        }

        public BasicUserModel(UserModel user)
        {
            Id = user.Id;
            DisplayName = user.DisplayName;
        }
    }
}

