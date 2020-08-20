using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarApplication.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Display(Name = "Table Number")] public int TableNumber { get; set; }
        [Display(Name = "Menu Item Number")] public int MenuId { get; set; }

        [Display(Name = "Quantity")] public int QuantityOfDrink { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; } //had to look up standards. 18 digits with 2 to the right.

        [ForeignKey("MenuId")] public BarMenu BarMenu { get; set; }
    }
}