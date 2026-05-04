using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockFlow.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}
