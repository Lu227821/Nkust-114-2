namespace WebApplication1.Models
{
    public class RecordDto
    {
        public int Id { get; set; }

        public string? ClassType { get; set; } // 類別代碼

        public string? FlagNo { get; set; } // 標誌編號

        public string? StoreNo { get; set; } // 店家編號

        public string? StoreName { get; set; } // 店家名稱

        public string? Undertaker { get; set; } // 負責人/承辦人

        public string? StoreAddr { get; set; } // 店家地址

        public string? ContactTel { get; set; } // 聯絡電話

        public string? TaxNo { get; set; } // 統一編號
    }
}