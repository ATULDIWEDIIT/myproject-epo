using System;
using System.Collections.Generic;

namespace Digital.Data.Models
{
    public partial class Subcategories
    {
        public Subcategories()
        {
            Products = new HashSet<Products>();
        }

        public int SubcategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CategoryId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreadetOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
