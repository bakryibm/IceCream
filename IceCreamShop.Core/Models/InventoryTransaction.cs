using System.ComponentModel.DataAnnotations;

namespace IceCreamShop.Core.Models
{
    public class InventoryTransaction
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        
        [Required]
        [StringLength(20)]
        public string TransactionType { get; set; } = string.Empty; // إضافة، بيع، تلف، تعديل
        
        public int Quantity { get; set; }
        
        public int PreviousStock { get; set; }
        
        public int NewStock { get; set; }
        
        public decimal? UnitCost { get; set; }
        
        public decimal? TotalCost { get; set; }
        
        [StringLength(20)]
        public string ReferenceType { get; set; } = string.Empty; // فاتورة_بيع، فاتورة_شراء، تعديل_يدوي
        
        public int? ReferenceId { get; set; }
        
        [StringLength(50)]
        public string ReferenceNumber { get; set; } = string.Empty;
        
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        
        public int UserId { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
