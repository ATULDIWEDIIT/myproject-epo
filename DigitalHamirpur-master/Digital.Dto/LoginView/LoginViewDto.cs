using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Dto
{
    public class LoginViewDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastPasswordChange { get; set; }
        public string Ip { get; set; }

    }
}
