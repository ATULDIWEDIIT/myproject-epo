using Digital.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Service
{
    public interface IUserService: IDisposable
    {
        Users GetUser(int? id);
        List<Users> GetUser(string userName, string Password);

         public Users GetUserEntityByUserName(string username);


        bool IsUserNameExist(string userName, int userId = 0);

        void Save(Users user, int? CreatedBy, bool isNew = true);



        void Delete(int id);
    }
}
