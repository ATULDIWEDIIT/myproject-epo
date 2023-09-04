using System;
using System.Collections.Generic;

namespace Digital.Data.Models
{
    public partial class Roles
    {
        public Roles()
        {
            UserRole = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
