using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProject.Models
{
    public class Link
    {
        public int Id { get; set; }
        public int? UpProduct { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int Count { get; set; }

        [NotMapped]
        public Product LinkProductName
        {
            get
            {
                return DataOperations.GetNameByID(ProductId);
            }
        }
    }
}
