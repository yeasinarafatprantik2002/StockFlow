using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockFlow.Models
{
    public class SaleItem
    {
        [Key]
        public int Id { get; set; }

        public int SaleId { get; set; }
        [ForeignKey("SaleId")]
        public virtual Sale Sale { get; set; } = null!;

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
    }
}
