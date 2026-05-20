using System;
using System.ComponentModel.DataAnnotations;

namespace StockFlow.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = "Staff";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
