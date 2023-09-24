using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Shared
{
    public class Products
    {
        [Key]
        public string Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Qty { get; set; }
        public string Description { get; set; }

        [ForeignKey("CategoryId")]
        public string CategoryId { get; set; }
        public Category categories { get; set; }

    }
}
