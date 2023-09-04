using System;
using System.Collections.Generic;

namespace Digital.Data.Models
{
    public partial class Payments
    {
        public int PaymentId { get; set; }
        public int? UserId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? CreadtedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Users User { get; set; }
    }
}
