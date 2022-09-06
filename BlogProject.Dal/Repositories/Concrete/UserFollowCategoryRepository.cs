using BlogProject.Dal.Context;
using BlogProject.Dal.Repositories.Interfaces.Concrete;
using BlogProject.Model.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BlogProject.Dal.Repositories.Concrete
{
    public class UserFollowCategoryRepository : IUserFollowCategoryRepository
    {
        private readonly ProjectContext _context;
        private readonly DbSet<UserFollowCategory> _table;

        public UserFollowCategoryRepository(ProjectContext context)
        {
            _context = context;
            _table = context.Set<UserFollowCategory>();

        }
        public void Create(UserFollowCategory entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(UserFollowCategory entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }
        public List<UserFollowCategory> GetDefaults(Expression<Func<UserFollowCategory, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }

    }
}
