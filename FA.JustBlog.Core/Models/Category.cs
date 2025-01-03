using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "The Name must be less than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The UrlSlug field is required.")]
        [StringLength(50, ErrorMessage = "The UrlSlug must be less than 50 characters.")]
        public string UrlSlug { get; set; }

        [StringLength(500, ErrorMessage = "The Description must be less than 500 characters.")]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
