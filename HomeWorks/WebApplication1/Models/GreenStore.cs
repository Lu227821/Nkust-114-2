namespace WebApplication1.Models
{
    public class GreenStore
    {
        public int Id { get; set; }
        public string? ReportDate { get; set; }
        public string? StoreCode { get; set; }
        public string? StoreName { get; set; }
        public string? Category { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? DataMonth { get; set; }
        public string? MonthlyRevenue { get; set; }
        public string? RevenueLastMonth { get; set; }
        public string? RevenueLastYear { get; set; }
        public string? AccRevenueCurrent { get; set; }
        public string? AccRevenueLastYear { get; set; }
        public int? MonthlyCustomers { get; set; }
        public string? Notes { get; set; }
    }
}
