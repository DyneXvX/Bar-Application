using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarApplication.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Display(Name = "Table Number")] public int TableNumber { get; set; }
        [Display(Name = "Drink Name")] public int MenuId { get; set; }

        [Display(Name = "Quantity")] public int QuantityOfDrink { get; set; }


        [ForeignKey("MenuId")] public BarMenu BarMenu { get; set; }
    }
}