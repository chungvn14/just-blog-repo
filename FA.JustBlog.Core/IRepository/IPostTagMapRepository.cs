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
    public interface IPostTagMapRepository : IGenericRepository<PostTagMap>
    {
        void AddRange(IEnumerable<PostTagMap> postTagMaps);
        

    }
}
