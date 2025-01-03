using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Short Description is required.")]
        [StringLength(500, ErrorMessage = "Short Description cannot exceed 500 characters.")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Post content is required.")]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "URL Slug is required.")]
        [StringLength(100, ErrorMessage = "URL Slug cannot exceed 100 characters.")]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "Post published status is required.")]
        public bool Published { get; set; }

        [Required(ErrorMessage = "Posted On date is required.")]
       
        public DateTime PostedOn { get; set; }

        
        public DateTime Modified { get; set; }

        public int CategoryId { get; set; }

        // Navigation property for Category


        // Additional properties for views, rates
        [Range(0, int.MaxValue, ErrorMessage = "View Count must be a positive number.")]
        public int ViewCount { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Rate Count must be a positive number.")]
        public int RateCount { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Total Rate must be a positive number.")]
        public int TotalRate { get; set; }

        // Computed Rate based on RateCount and TotalRate
        public decimal Rate
        {
            get
            {
                if (RateCount == 0) return 0;
                return (decimal)TotalRate / RateCount;
            }
        }

        // Navigation property for Comments
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Category Category { get; set; }

        // Navigation property for Post-Tag relationship
        public virtual ICollection<PostTagMap> PostTagMaps { get; set; }
    }
}
