namespace ForumSystem.Web.ViewModels.PageableFeedbackListView
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class PageableFeedbackListViewModel : IMapFrom<ForumSystem.Data.Models.Feedback>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Author { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ForumSystem.Data.Models.Feedback, PageableFeedbackListViewModel>()
               .ForMember(m => m.Title, opt => opt.MapFrom(t => t.Title))
               .ForMember(m => m.Author, opt => opt.MapFrom(t => t.Author.UserName))
               .ForMember(m => m.Id, opt => opt.MapFrom(t => t.Id))
               .ForMember(m => m.CreatedOn, opt => opt.MapFrom(t => t.CreatedOn))
               .ForMember(m => m.Content, opt => opt.MapFrom(t => t.Content))
               .ReverseMap();
        }
    }
}