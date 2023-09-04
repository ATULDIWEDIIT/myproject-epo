using Digital.Core;
using Digital.Data.Models;
using Digital.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Service
{
    public class UserService : IUserService
    {

        private IRepository<Users> repoUser;

        public UserService(IRepository<Users> _repoUser)
        {
            repoUser = _repoUser;
        }

        public Users GetUser(int? id)
        {
            return repoUser.Query().Filter(x => x.UserId == id).Get().FirstOrDefault();
        }

        public Users GetUserEntityByUserName(string username)
        {
            return repoUser.Query().Filter(u => u.UserName == username).Get().FirstOrDefault();
        }

        public List<Users> GetUser(string userName, string Password)
        {
            return repoUser.Query()
                //.Include(u=>u.UserRoles)               
                .Filter(u => u.UserName == userName)
                .Get()
                //.Where(x => x.Password == EncryptionUtils.HashPassword(Password, x.PasswordSalt, x.LastLoginDate))
                .Where(x => x.Password == Password)
                .ToList();
        }

       
        public void Save(Users user, int? CreatedBy, bool isNew = true)
        {
            if (isNew)
            {
                repoUser.Insert(user);
            }
            else
            {
                repoUser.Update(user);
            }
        }

        public void Delete(int id)
        {
            repoUser.Delete(id);
        }


        public bool IsUserNameExist(string userName, int userId = 0)
        {
            return repoUser.Query().Filter(u => u.UserName == userName && u.UserId != userId).Get().Count() > 0 ? true : false;
        }

        #region Dispose
        public void Dispose()
        {
            if (repoUser != null)
            {
                repoUser.Dispose();
                repoUser = null;
            }
        }

        #endregion

    }
}
