using BlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Dal.Repositories.Interfaces.Concrete
{
  public  interface ILikeRepository
    {
        // DİKKAT => like sınıfı baseden kalıtım almıyor bu yüzden baseRepodan kalıtım alamayacak ama zaten like için tüm CRUDLAR söz konusu değil.  

        // like nesnesini oluşturabilirsiniz/ silebilirsiniz yani bir makaleyi beğenebilirsiniz yada beğeninizi geri alabilirsiniz hepsi bu.
        void Create(Like entity);

        void Delete(Like entity);

    }
}
