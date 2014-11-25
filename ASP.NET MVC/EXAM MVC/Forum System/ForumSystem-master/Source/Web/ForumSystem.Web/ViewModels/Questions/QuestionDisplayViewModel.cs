namespace ForumSystem.Web.ViewModels.Questions
{
    using System.Collections.Generic;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;
    using ForumSystem.Web.ViewModels.Tags;

    public class QuestionDisplayViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }
    }
}