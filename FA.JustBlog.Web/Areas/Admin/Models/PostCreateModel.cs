using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Web.Areas.Admin.Models
{
    public class PostCreateModel
    {
        // Tiêu đề bài viết
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        // Mô tả ngắn về bài viết
        [Required(ErrorMessage = "Short Description is required.")]
        [StringLength(500, ErrorMessage = "Short Description cannot exceed 500 characters.")]
        public string ShortDescription { get; set; }

        // Nội dung chính của bài viết
        [Required(ErrorMessage = "Post content is required.")]
        public string PostContent { get; set; }

        // Ngày đăng bài viết
        [Required(ErrorMessage = "Posted On date is required.")]
        public DateTime PostedOn { get; set; }

        // ID danh mục của bài viết
        [Required(ErrorMessage = "Category is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Category must be selected.")]
        public int CategoryId { get; set; }

        // Trạng thái đã xuất bản chưa
        [Required(ErrorMessage = "Post published status is required.")]
        public bool Published { get; set; }

        public List<int> Tags { get; set; }
    }
}
