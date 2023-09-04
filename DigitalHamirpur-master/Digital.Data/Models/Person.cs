using System;
using System.Collections.Generic;

namespace Digital.Data.Models
{
    public partial class Person
    {
        public Person()
        {
            Users = new HashSet<Users>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public string Disctrict { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
