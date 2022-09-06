using BlogProject.Dal.Context;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BlogProject.Dal.Repositories.Concrete
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ProjectContext _context;
        private readonly DbSet<Like> _table;

        public LikeRepository(ProjectContext context)
        {
            _context = context;
            _table = context.Set<Like>();

        }
        public void Create(Like entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Like entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public bool IsLiked(Expression<Func<Like, bool>> expression)
        {
            return _table.Where(expression).Any();
        }
    }
}
