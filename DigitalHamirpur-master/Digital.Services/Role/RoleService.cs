using Digital.Core;
using Digital.Data.Models;
using Digital.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Service
{
    public class RoleService : IRoleService
    {
        private IRepository<Roles> repoRole;
        private IRepository<UserRole> repoUserRole;      

        public RoleService(IRepository<Roles> _repoRole, IRepository<UserRole> _repoUserRole)
        {
            this.repoRole = _repoRole;
            this.repoUserRole = _repoUserRole;          
        }

        public Roles GetRoleByName(string name)
        {
            return repoRole.Query().Filter(r => r.RoleName == name).Get().FirstOrDefault();
        }
      
        public void Dispose()
        {
            if (repoRole != null)
            {
                repoRole.Dispose();
                repoRole = null;
            }
            if (repoUserRole != null)
            {
                repoUserRole.Dispose();
                repoUserRole = null;
            }
        }


    }
}
