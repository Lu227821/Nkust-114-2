using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Pages.Records
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        // 1. 透過建構子注入 AppDbContext (這取代了以前落落長的 SqlConnection)
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        // 2. 用來傳遞給前端畫面 (Index.cshtml) 顯示的店家清單
        public List<Record> Items { get; set; } = new List<Record>();

        // 3. 依照你 JSON 的內容，設計新的網頁搜尋綁定欄位
        [BindProperty(SupportsGet = true)]
        public string? 搜尋店家編號 { get; set; } // 對應 JSON 的 storeno

        [BindProperty(SupportsGet = true)]
        public string? 搜尋店家名稱 { get; set; } // 對應 JSON 的 storename

        [BindProperty(SupportsGet = true)]
        public string? 搜尋類別代碼 { get; set; } // 對應 JSON 的 classtype

        public int TotalCount { get; set; }

        public void OnGet()
        {
            // 4. 從資料庫取得資料表 (這行等同於下 SELECT * FROM 你的資料表)
            var query = _context.Records.AsQueryable();

            // 5. 如果使用者在網頁有輸入搜尋條件，就幫查詢加上過濾 (等同於 SQL 的 LIKE '%...%')
            if (!string.IsNullOrEmpty(搜尋店家編號))
            {
                query = query.Where(r => r.StoreNo != null && r.StoreNo.Contains(搜尋店家編號));
            }

            if (!string.IsNullOrEmpty(搜尋店家名稱))
            {
                query = query.Where(r => r.StoreName != null && r.StoreName.Contains(搜尋店家名稱));
            }

            if (!string.IsNullOrEmpty(搜尋類別代碼))
            {
                query = query.Where(r => r.ClassType != null && r.ClassType.Contains(搜尋類別代碼));
            }

            // 6. 執行查詢，轉成 List 後傳遞給前端
            Items = query.ToList();

            // 計算總共有幾筆
            TotalCount = Items.Count;
        }
    }
}