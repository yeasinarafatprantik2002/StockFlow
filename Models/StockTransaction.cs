using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockFlow.Models
{
    public class StockTransaction
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;

        public int Quantity { get; set; } // Positive for In, Negative for Out

        [Required]
        [MaxLength(20)]
        public string TransactionType { get; set; } = string.Empty; // "StockIn", "StockOut", "Sale"

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
    }
}
