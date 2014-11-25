namespace ForumSystem.Web.ViewModels.Feedback
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class AddFeedBackViewModel : IMapFrom<ForumSystem.Data.Models.Feedback>, IHaveCustomMappings
    {
        public int? Id { get; set; }

        public virtual User Author { get; set; }

        [Display(Name = "Feeback Title")]
        public string Title { get; set; }

        [Display(Name = "Feeback Content")]
        [AllowHtml]
        public string Content { get; set; }

        // public bool IsDeleted { get; set; }
           
        // public DateTime? DeletedOn { get; set; }
           
        // public DateTime CreatedOn { get; set; }
           
        // public bool PreserveCreatedOn { get; set; }
           
        //// public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ForumSystem.Data.Models.Feedback, AddFeedBackViewModel>()
               .ForMember(m => m.Title, opt => opt.MapFrom(t => t.Title))
               .ForMember(m => m.Content, opt => opt.MapFrom(t => t.Content))
               .ReverseMap();
        }
    }
}