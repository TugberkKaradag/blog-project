using BlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BlogProject.Dal.Repositories.Interfaces.Concrete
{
    public interface IUserFollowCategoryRepository
    {

        void Create(UserFollowCategory entity);

        void Delete(UserFollowCategory entity);
        List<UserFollowCategory> GetDefaults(Expression<Func<UserFollowCategory, bool>> expression);


    }
}
