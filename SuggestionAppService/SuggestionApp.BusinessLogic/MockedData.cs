using SuggestionApp.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.BusinessLogic
{
    public static class MockedData
    {
        public static UserModel UserSampleData()
        {
            return new UserModel
            {
                FirstName = "Manish",
                LastName = "Jaiswal",
                EmailAddress = "mani@test.com",
                DisplayName = "4ever_mani",
                ObjectIdentifier = "abc-123"
            };
        }

        public static List<SuggestionModel> SuggestionSampleData()
        {
            List<SuggestionModel> suggestions = new List<SuggestionModel>
            {
                new SuggestionModel
                {
                    Author = new BasicUserModel(UserSampleData()),
                    Category = null,
                    Suggestion = "This is my First Suggestion",
                    Description = "This is sample data genereated description",
                    SuggestionStatus = null,
                    OwnerNotes = "This is the note for the status"
                    
                },
                new SuggestionModel
                {
                    Author = new BasicUserModel(UserSampleData()),
                    Category = null,
                    Suggestion = "This is my second Suggestion",
                    Description = "This is sample data genereated description",
                    SuggestionStatus = null,
                    OwnerNotes = "This is the note for the status"

                },
                new SuggestionModel
                {
                    Author = new BasicUserModel(UserSampleData()),
                    Category = null,
                    Suggestion = "This is my third Suggestion",
                    Description = "This is sample data genereated description",
                    SuggestionStatus = null,
                    OwnerNotes = "This is the note for the status"

                },
                new SuggestionModel
                {
                    Author = new BasicUserModel(UserSampleData()),
                    Category = null,
                    Suggestion = "This is my fourth Suggestion",
                    Description = "This is sample data genereated description",
                    SuggestionStatus = null,
                    OwnerNotes = "This is the note for the status"

                },
                new SuggestionModel
                {
                    Author = new BasicUserModel(UserSampleData()),
                    Category = null,
                    Suggestion = "This is my fifth Suggestion",
                    Description = "This is sample data genereated description",
                    SuggestionStatus = null,
                    OwnerNotes = "This is the note for the status"

                },
            };

            return suggestions;
        }

        public static List<CategoryModel> CategorySampleData()
        {
            return new List<CategoryModel>
            {
                new CategoryModel
                {
                    CategoryName = "Courses",
                    CategoryDescription = "Full paid courses."
                },
                new CategoryModel
                {
                    CategoryName = "Dev Questions",
                    CategoryDescription = "Advice on being a developer."
                },
                new CategoryModel
                {
                    CategoryName = "In-Depth Tutorial",
                    CategoryDescription = "A deep-dive video on how to use a topic."
                },
                new CategoryModel
                {
                    CategoryName = "10-Minutes Training",
                    CategoryDescription = "A quick \"How do I use this?\" video."
                },
                new CategoryModel
                {
                    CategoryName = "Others",
                    CategoryDescription = "Not sure in wgich category it's fit in."
                }
            };
        }

        public static List<StatusModel> StatusSampleData()
        {
            return new List<StatusModel>
            {
                new StatusModel
                {
                    StatusName = "Completed",
                    StatusDescription = "The suggestion was accepted and the corresponding item was created."
                },
                new StatusModel
                {
                    StatusName = "Watching",
                    StatusDescription = "The suggestion is interesting. We are watching to see hoe much interest there is in it."
                },
                new StatusModel
                {
                    StatusName = "Upcoming",
                    StatusDescription = "The suggestion was accepted and it will be released soon."
                },
                new StatusModel
                {
                    StatusName = "Dismissed",
                    StatusDescription = "The suggestion was not something that we are going to undertake."
                },
            };
        }
    }
}
