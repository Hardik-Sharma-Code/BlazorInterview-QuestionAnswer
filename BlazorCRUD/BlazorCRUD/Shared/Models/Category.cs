using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Shared
{
    public class Category
    {
        [Key]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryPicture { get; set; }
    }
}
