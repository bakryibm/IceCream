using IceCreamShop.Core.Models;

namespace IceCreamShop.Core.Services
{
    public interface IReportService
    {
        Task<byte[]> GenerateInvoicePdfAsync(Sale sale);
        Task<byte[]> GenerateDailySalesReportAsync(DateTime date);
        Task<byte[]> GenerateMonthlySalesReportAsync(int year, int month);
        Task<byte[]> GenerateInventoryReportAsync();
        Task<byte[]> GenerateTopProductsReportAsync(DateTime? startDate = null, DateTime? endDate = null);
        Task<string> ExportSalesToExcelAsync(DateTime startDate, DateTime endDate);
        Task<string> ExportInventoryToExcelAsync();
        Task<DashboardData> GetDashboardDataAsync();
    }

    public class DashboardData
    {
        public decimal TodaysSales { get; set; }
        public decimal MonthlySales { get; set; }
        public int TodaysTransactions { get; set; }
        public int MonthlyTransactions { get; set; }
        public int LowStockProducts { get; set; }
        public int TotalProducts { get; set; }
        public int TotalCustomers { get; set; }
        public List<TopProduct> TopProducts { get; set; } = new();
        public List<MonthlySalesData> MonthlySalesChart { get; set; } = new();
    }

    public class TopProduct
    {
        public string ProductName { get; set; } = string.Empty;
        public int QuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class MonthlySalesData
    {
        public string Month { get; set; } = string.Empty;
        public decimal Sales { get; set; }
    }
}
