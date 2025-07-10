using System.ComponentModel.DataAnnotations;

namespace IceCreamShop.Core.Models
{
    public class Sale
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string InvoiceNumber { get; set; } = string.Empty;
        
        public DateTime SaleDate { get; set; } = DateTime.Now;
        
        public decimal TotalAmount { get; set; }
        
        public decimal DiscountAmount { get; set; } = 0;
        
        public decimal TaxAmount { get; set; } = 0;
        
        public decimal FinalAmount { get; set; }
        
        [StringLength(20)]
        public string PaymentMethod { get; set; } = "نقداً"; // نقداً، بطاقة، تحويل
        
        public int? CustomerId { get; set; }
        
        public int UserId { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;
        
        public bool IsVoided { get; set; } = false;
        
        public DateTime? VoidedDate { get; set; }
        
        [StringLength(200)]
        public string VoidReason { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual Customer? Customer { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
    
    public class SaleItem
    {
        public int Id { get; set; }
        
        public int SaleId { get; set; }
        
        public int ProductId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;
        
        public decimal UnitPrice { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal TotalPrice { get; set; }
        
        public decimal DiscountAmount { get; set; } = 0;
        
        [StringLength(200)]
        public string Notes { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual Sale Sale { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
