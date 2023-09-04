using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Dto
{
    public class PersonViewDto
    {

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public string Disctrict { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string Password { get; set; }


    }
}
