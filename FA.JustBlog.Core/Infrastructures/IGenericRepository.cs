using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Infrastructures
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Find(int id); // Tìm kiếm theo id
        void Add(TEntity entity); // Thêm một thực thể mới
        void Update(TEntity entity); // Cập nhật thực thể
        void Delete(TEntity entity); // Xóa thực thể
        void Delete(int id); // Xóa theo id
        List<TEntity> GetAll(); // Lấy tất cả các thực thể
    }
}
