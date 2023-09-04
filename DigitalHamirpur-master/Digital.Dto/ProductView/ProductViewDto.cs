using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Dto
{
    public class ProductViewDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public int? SubcategoryId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public decimal? Price { get; set; }
        public decimal? ComparePrice { get; set; }
        public decimal? CostPrice { get; set; }
        public string ImagePath { get; set; }
        public IFormFile file { get; set; }
        public string UploadPath { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreadtedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
