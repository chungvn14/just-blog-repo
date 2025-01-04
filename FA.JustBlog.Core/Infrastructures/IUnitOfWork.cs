using FA.JustBlog.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Infrastructures
{
    public interface IUnitOfWork: IDisposable
    {
        ITagRepository Tags { get; }
        IPostTagMapRepository PostTagMaps { get; }
        IPostRepository Posts { get; }
        ICommentRepository Comments { get; }
        ICategoryRepository Categories { get; }
        int SaveChanges();
    }
}
