using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.IRepository
{
    // Interface cho các phương thức truy cập và thao tác dữ liệu của Post
    public interface IPostRepository : IGenericRepository<Post>
    {
        // Tìm kiếm bài viết theo năm, tháng và slug URL
        // year: năm xuất bản bài viết
        // month: tháng xuất bản bài viết
        // urlSlug: slug URL của bài viết
        Post FindPost(int year, int month, string urlSlug);

        // Lấy danh sách tất cả các bài viết đã được xuất bản
        IEnumerable<Post> GetPublisedPosts();

        // Lấy danh sách tất cả các bài viết chưa được xuất bản
        IEnumerable<Post> GetUnpublisedPosts();

        // Lấy danh sách các bài viết mới nhất với số lượng xác định
        // size: số lượng bài viết cần lấy
    

        IList<Post> GetLatestPost(int pageNumber, int pageSize);

        // Lấy danh sách các bài viết theo tháng
        // monthYear: tháng và năm để lọc bài viết
        IList<Post> GetPostsByMonth(DateTime monthYear);

        // Đếm số lượng bài viết trong một danh mục cụ thể
        // category: tên của danh mục
        int CountPostsForCategory(string category);

        // Lấy danh sách các bài viết thuộc một danh mục cụ thể
        // category: tên của danh mục
        IList<Post> GetPostsByCategory(string category);

        // Đếm số lượng bài viết có gắn một tag cụ thể
        // tag: tên của tag
        int CountPostsForTag(string tag);

        // Lấy danh sách các bài viết có gắn một tag cụ thể
        // tag: tên của tag
        IList<Post> GetPostsByTag(string tag);

        IList<Post> GetMostViewedPost(int size);
        IList<Post> GetHighestPosts(int size);
        Post GetPostWithCategory(int id);
        IEnumerable<Post> GetPostsWithCategory();
        IList<Post> GetLatestPost(int size);
       
        IEnumerable<Post> GetLatestPosts();
        IEnumerable<Post> GetMostViewedPosts();
        IEnumerable<Post> GetMostInterestingPosts();
      
    }
}
