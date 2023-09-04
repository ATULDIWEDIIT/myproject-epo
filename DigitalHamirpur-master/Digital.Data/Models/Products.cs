using System;
using System.Collections.Generic;

namespace Digital.Data.Models
{
    public partial class Products
    {
        public Products()
        {
            Cart = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetails>();
            Reviews = new HashSet<Reviews>();
        }

        public int ProductId { get; set; }
        public string Title { get; set; }
        public int? SubcategoryId { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public decimal? Price { get; set; }
        public decimal? ComparePrice { get; set; }
        public decimal? CostPrice { get; set; }
        public string ImagePath { get; set; }
        public string UploadPath { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreadtedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Subcategories Subcategory { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
