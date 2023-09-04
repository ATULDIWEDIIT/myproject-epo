using System;
using System.Collections.Generic;

namespace Digital.Data.Models
{
    public partial class Users
    {
        public Users()
        {
            Cart = new HashSet<Cart>();
            Orders = new HashSet<Orders>();
            Payments = new HashSet<Payments>();
            Reviews = new HashSet<Reviews>();
            UserRole = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int? RoleId { get; set; }
        public int? PersonId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastPasswordChange { get; set; }
        public string Ip { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
