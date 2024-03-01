using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuyetTC_ASS2_Repository.DTO
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "ProductID is required")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "ProductName is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "SupplierId is required")]
        public int? SupplierId { get; set; }

        [Required(ErrorMessage = "CategoryId is required")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "QuantityPerUnit is required")]
        public string QuantityPerUnit { get; set; }

        [Required(ErrorMessage = "UnitPrice is required")]
        public decimal? UnitPrice { get; set; }

        [Required(ErrorMessage = "ProductImg is required")]
        public string ProductImg { get; set; }
    }
}
