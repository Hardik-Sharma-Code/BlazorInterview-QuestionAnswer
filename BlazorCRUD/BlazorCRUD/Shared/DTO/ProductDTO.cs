using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Shared
{
    public class ProductDTO
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public int? Qty { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
