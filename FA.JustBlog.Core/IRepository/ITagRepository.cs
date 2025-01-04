using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.IRepository
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        //Lay tag bang URL
        Tag GetTagByUrlSlug(string urlSlug);
        IList<Tag> GetTopTags(int topCount);
        IList<Tag> GetAllTagsByPost(int postId);
    }
}
