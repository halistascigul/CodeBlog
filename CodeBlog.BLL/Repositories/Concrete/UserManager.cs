using CodeBlog.BLL.Repositories.Abstract;
using CodeBlog.CORE.Constants;
using CodeBlog.CORE.Extensions;
using CodeBlog.CORE.ResultTypes;
using CodeBlog.DAL.Abstract;
using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.BLL.Repositories.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal userDal;

        public UserManager(IUserDal _userDal)
        {
            userDal = _userDal;
        }

        public ApplicationUser Login(string email,string password)
        {
            var user = userDal.Get(x => x.Email == email && x.Password == password && x.IsActive);
            user.LastLogin = DateTime.Now;
            userDal.Update(user);
            return user;
        }

        public EntityResult<ApplicationUser> Get(Expression<Func<ApplicationUser, bool>> filter, params string[] includeList)
        {
            try
            {
                var module = userDal.Get(filter, includeList);
                if (module != null)
                    return new EntityResult<ApplicationUser>(module, "Başarılı", ResultState.Success);
                return new EntityResult<ApplicationUser>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<ApplicationUser>(null, "Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }
        public EntityResult Delete(ApplicationUser model)
        {
            try
            {
                if (userDal.Delete(model))
                    return new EntityResult("Silme işlemi başarılı", ResultState.Success);
                return new EntityResult("Silme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<List<ApplicationUser>> GetList(Expression<Func<ApplicationUser, bool>> filter = null, params string[] includeList)
        {
            try
            {
                var categorys = userDal.GetList(filter, includeList);
                if (categorys != null)
                    return new EntityResult<List<ApplicationUser>>(categorys, "Başarılı", ResultState.Success);
                return new EntityResult<List<ApplicationUser>>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<ApplicationUser>>(null, "Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Insert(ApplicationUser model)
        {
            try
            {
                if (userDal.Insert(model))
                    return new EntityResult("Ekleme işlemi başarılı", ResultState.Success);
                return new EntityResult("Ekleme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Update(ApplicationUser model)
        {
            try
            {
                if (userDal.Update(model))
                    return new EntityResult("Ekleme işlemi başarılı", ResultState.Success);
                return new EntityResult("Ekleme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }
    }
}
