using System.ComponentModel.DataAnnotations;

namespace IceCreamShop.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(15)]
        public string Phone { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? LastVisitDate { get; set; }
        
        public decimal TotalPurchases { get; set; } = 0;
        
        public int VisitCount { get; set; } = 0;
        
        [StringLength(20)]
        public string CustomerType { get; set; } = "عادي"; // عادي، مميز، VIP
        
        public bool IsActive { get; set; } = true;
        
        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
