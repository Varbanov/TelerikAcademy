namespace ForumSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;
    using ForumSystem.Web.ViewModels.Tags;

    public class IndexBlogPostViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public int Id { get; set; }

        public virtual ICollection<TagViewModel> Tags { get; set; }
    }
}