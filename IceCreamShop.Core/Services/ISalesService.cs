using IceCreamShop.Core.Models;

namespace IceCreamShop.Core.Services
{
    public interface ISalesService
    {
        Task<Sale> CreateSaleAsync(Sale sale);
        Task<Sale?> GetSaleByIdAsync(int id);
        Task<Sale?> GetSaleByInvoiceNumberAsync(string invoiceNumber);
        Task<IEnumerable<Sale>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Sale>> GetSalesByUserAsync(int userId, DateTime? startDate = null, DateTime? endDate = null);
        Task<IEnumerable<Sale>> GetSalesByCustomerAsync(int customerId);
        Task<bool> VoidSaleAsync(int saleId, string reason, int userId);
        Task<string> GenerateInvoiceNumberAsync();
        Task<decimal> GetTotalSalesAsync(DateTime? startDate = null, DateTime? endDate = null);
        Task<int> GetSalesCountAsync(DateTime? startDate = null, DateTime? endDate = null);
        Task<IEnumerable<Sale>> GetTodaysSalesAsync();
        Task<IEnumerable<SaleItem>> GetTopSellingProductsAsync(DateTime? startDate = null, DateTime? endDate = null, int count = 10);
    }
}
