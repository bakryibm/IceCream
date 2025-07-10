using System.ComponentModel.DataAnnotations;

namespace IceCreamShop.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int MinimumStock { get; set; } = 10;

        [StringLength(50)]
        public string Category { get; set; } = string.Empty; // آيس كريم، إضافات، مشروبات

        [StringLength(50)]
        public string Flavor { get; set; } = string.Empty; // النكهة

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        // Navigation properties
        public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
    }
}
