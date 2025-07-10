using System.ComponentModel.DataAnnotations;

namespace IceCreamShop.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        
        [StringLength(15)]
        public string Phone { get; set; } = string.Empty;
        
        [Required]
        [StringLength(20)]
        public string Role { get; set; } = "بائع"; // مدير، بائع، محاسب
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? LastLoginDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
    }
}
