using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Record
    {
        // 建議保留一個 Id 做為資料庫的自動遞增主鍵 (Primary Key)
        [Key]
        public int Id { get; set; }

        // 以下依照 gp_p_01 (1).json 的欄位進行對應設定：

        /// <summary>
        /// 對應 JSON 的 "classtype" (類別代碼)
        /// </summary>
        public string? ClassType { get; set; }

        /// <summary>
        /// 對應 JSON 的 "flagno" (標誌編號)
        /// </summary>
        public string? FlagNo { get; set; }

        /// <summary>
        /// 對應 JSON 的 "storeno" (店家編號)
        /// </summary>
        public string? StoreNo { get; set; }

        /// <summary>
        /// 對應 JSON 的 "storename" (店家名稱)
        /// </summary>
        public string? StoreName { get; set; }

        /// <summary>
        /// 對應 JSON 的 "undertaker" (負責人/承辦人)
        /// </summary>
        public string? Undertaker { get; set; }

        /// <summary>
        /// 對應 JSON 的 "storeaddr" (店家地址)
        /// </summary>
        public string? StoreAddr { get; set; }

        /// <summary>
        /// 對應 JSON 的 "contacttel" (聯絡電話)
        /// </summary>
        public string? ContactTel { get; set; }

        /// <summary>
        /// 對應 JSON 的 "taxno" (統一編號)
        /// </summary>
        public string? TaxNo { get; set; }
    }
}