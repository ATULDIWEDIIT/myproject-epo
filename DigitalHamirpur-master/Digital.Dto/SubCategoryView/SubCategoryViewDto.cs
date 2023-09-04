using Digital.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Digital.Dto
{
    public class SubCategoryViewDto
    {
        public int SubcategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CategoryId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreadetOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        
    }
}
