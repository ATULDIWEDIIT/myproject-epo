using System;
using System.Collections.Generic;

namespace Digital.Data.Models
{
    public partial class ShoppingCart
    {
        public int CartId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreadtedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
    }
}
