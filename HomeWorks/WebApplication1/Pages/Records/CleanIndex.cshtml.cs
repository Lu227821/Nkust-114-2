using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Pages.Records
{
    public class CleanIndexModel : PageModel
    {
        private readonly AppDbContext _context;

        // 1. 透過建構子注入 EF Core 的 AppDbContext
        public CleanIndexModel(AppDbContext context)
        {
            _context = context;
        }

        // 2. 畫面要綁定的資料清單，統一改用更新後的 Record 模型
        public List<Record> Items { get; set; } = new List<Record>();

        [BindProperty(SupportsGet = true)]
        public string? StoreCode { get; set; } // 前端傳入的店家編號搜尋條件 (對應 StoreNo)

        [BindProperty(SupportsGet = true)]
        public string? StoreName { get; set; } // 店家名稱搜尋條件

        [BindProperty(SupportsGet = true)]
        public string? Category { get; set; }  // 類別搜尋條件 (對應 ClassType)

        [BindProperty(SupportsGet = true)]
        public bool OnlyDistinct { get; set; } // 是否啟用「只顯示不重複店家」的勾選狀態

        public int TotalCount { get; set; }
        public int DistinctStoresCount { get; set; }

        public void OnGet()
        {
            // 3. 建立 EF Core 查詢流 (對應 Records 資料表)
            var query = _context.Records.AsQueryable();

            // 4. 根據前端輸入條件進行動態篩選 (LIKE 查詢)
            if (!string.IsNullOrEmpty(StoreCode))
            {
                query = query.Where(r => r.StoreNo != null && r.StoreNo.Contains(StoreCode));
            }

            if (!string.IsNullOrEmpty(StoreName))
            {
                query = query.Where(r => r.StoreName != null && r.StoreName.Contains(StoreName));
            }

            if (!string.IsNullOrEmpty(Category))
            {
                query = query.Where(r => r.ClassType != null && r.ClassType.Contains(Category));
            }

            // 將符合關鍵字篩選後的資料從資料庫撈出
            var allMatchingItems = query.ToList();

            // 5. 計算統計數據 (完全用 LINQ 取代以前傳統的迴圈計算)
            TotalCount = allMatchingItems.Count;

            // 計算有多少個不重複的 StoreNo
            DistinctStoresCount = allMatchingItems
                .Select(r => r.StoreNo?.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .Distinct()
                .Count();

            // 6. 處理 OnlyDistinct 邏輯：如果勾選，就依 StoreNo 進行分組並只取每組第一筆
            if (OnlyDistinct)
            {
                Items = allMatchingItems
                    .GroupBy(r => r.StoreNo?.Trim() ?? string.Empty)
                    .Select(g => g.First())
                    .ToList();
            }
            else
            {
                Items = allMatchingItems;
            }
        }
    }
}