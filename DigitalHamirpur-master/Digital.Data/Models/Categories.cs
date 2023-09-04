using System;
using System.Collections.Generic;

namespace Digital.Data.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Subcategories = new HashSet<Subcategories>();
        }

        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryDecription { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreadtedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<Subcategories> Subcategories { get; set; }
    }
}
