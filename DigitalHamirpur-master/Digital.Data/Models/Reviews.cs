using System;
using System.Collections.Generic;

namespace Digital.Data.Models
{
    public partial class Reviews
    {
        public int ReviewId { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public int? Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime? ReviewDate { get; set; }

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
    }
}
