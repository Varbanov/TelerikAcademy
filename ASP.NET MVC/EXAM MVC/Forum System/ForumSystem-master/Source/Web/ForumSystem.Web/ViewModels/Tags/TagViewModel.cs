namespace ForumSystem.Web.ViewModels.Tags
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class TagViewModel : IMapFrom<Tag>
    {
        public virtual ICollection<Post> Posts { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}