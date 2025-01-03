using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace FA.JustBlog.Core.Infrastructures
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly JustBlogContext _context;

        // Repository quản lý
        private ITagRepository _tagRepository;
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;
        private IPostTagMapRepository _postTagMapRepository;
       

        public UnitOfWork(JustBlogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Quản lý TagRepository
        /// </summary>
        public ITagRepository TagRepository
        {
            get => _tagRepository ??= new TagRepository(_context);
        }

        /// <summary>
        /// Quản lý CategoryRepository
        /// </summary>
        public ICategoryRepository CategoryRepository
        {
            get => _categoryRepository ??= new CategoryRepository(_context);
        }

        /// <summary>
        /// Quản lý PostRepository
        /// </summary>
        public IPostRepository PostRepository
        {
            get => _postRepository ??= new PostRepository(_context);
        }
        public IPostTagMapRepository PostTagMapsRepository { get => _postTagMapRepository ??= new PostTagMapRepository(_context); }
      
        /// <summary>
        /// Shortcut cho TagRepository
        /// </summary>
        public ITagRepository Tags => TagRepository;

        /// <summary>
        /// Shortcut cho PostRepository
        /// </summary>
        public IPostRepository Posts => PostRepository;

        /// <summary>
        /// Shortcut cho CategoryRepository
        /// </summary>
        public ICategoryRepository Categories => CategoryRepository;
        public IPostTagMapRepository PostTagMaps => PostTagMapsRepository;
        /// <summary>
        /// Lưu thay đổi vào Database
        /// </summary>
        /// <returns>Số lượng bản ghi bị ảnh hưởng</returns>
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Giải phóng tài nguyên
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
