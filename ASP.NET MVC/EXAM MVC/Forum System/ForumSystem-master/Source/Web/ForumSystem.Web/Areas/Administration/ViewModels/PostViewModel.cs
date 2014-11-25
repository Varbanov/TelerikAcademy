namespace ForumSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string Content { get; set; }

        [Display(Name = "Created on")]
        public DateTime CreatedOn { get; set; } 

        [Display(Name = "Modified on")]
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Is deleted")]
        public bool IsDeleted { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ForumSystem.Data.Models.Post, PostViewModel>()
               .ForMember(m => m.Id, opt => opt.MapFrom(t => t.Id))
               .ForMember(m => m.Author, opt => opt.MapFrom(t => t.Author.UserName))
               .ForMember(m => m.Title, opt => opt.MapFrom(t => t.Title))
               .ForMember(m => m.Content, opt => opt.MapFrom(t => t.Content))
               .ForMember(m => m.CreatedOn, opt => opt.MapFrom(t => t.CreatedOn))
               .ForMember(m => m.ModifiedOn, opt => opt.MapFrom(t => t.ModifiedOn))
               .ForMember(m => m.IsDeleted, opt => opt.MapFrom(t => t.IsDeleted))
               .ReverseMap();
        }
    }
}