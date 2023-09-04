using Digital.Core;
using Digital.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Service
{
    public interface IRoleService : IDisposable
    {
        Roles GetRoleByName(string name);       
    }
}
