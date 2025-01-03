using FA.JustBlog.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlog.Core.Infrastructures
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly JustBlogContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(JustBlogContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        // Thêm một thực thể mới vào database
        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        // Xóa một thực thể khỏi database
        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        // Xóa một thực thể theo Id
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        // Tìm thực thể theo Id
        public TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        // Lấy danh sách tất cả thực thể
        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        // Cập nhật một thực thể
        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
