using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarApplication.Models
{
    public class BarMenu
    {
        public int Id { get; set; }

        [Display(Name = "Drink Name")]
        [Required]
        public string DrinkName { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required] public int Quantity { get; set; }

        public Order Order { get; set; }
    }
}