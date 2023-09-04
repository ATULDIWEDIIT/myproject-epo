using Digital.Core;
using Digital.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Digital.Dto
{
    public class CategoryViewDto
    {
        

        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryDecription { get; set; }


        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreadtedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public List<Categories> categoryList { get; set; }

       
        public List<DataTableRow> GridViewData { get; set; }
        public void BindGridViewData(DataTables dataTable, IEnumerable<Categories> projectDtos)
        {
            GridViewData = new List<DataTableRow>();
            int count = dataTable.iDisplayStart + 1;
            foreach (var item in projectDtos)
            {
                GridViewData.Add(new DataTableRow("rowId" + count.ToString(), "dtrowclass")
                {
                    item.CategoryId.ToString(),
                    count.ToString(),
                    item.CategoryTitle,
                    item.CategoryDecription,
                    item.CreadtedOn?.ToString("dd/MM/yyyy"),
                    item.IsActive.ToString(),

                });
                count++;
            }
        }

    }
}
