using BlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Dal.Repositories.Interfaces.Concrete
{
   public interface IUserFollowCategoryRepository
    {

        void Create(UserFollowCategory entity);

        void Delete(UserFollowCategory entity);
    }
}
