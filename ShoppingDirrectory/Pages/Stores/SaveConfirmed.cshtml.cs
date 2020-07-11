using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingDirrectory.Models;
using ShoppingDirrectory.Models.Interfaces;

namespace ShoppingDirrectory.Pages.Stores
{
    public class SaveConfirmedModel : PageModel
    {
        private readonly IShoppingData ShoppingData;

        public Store MyStore { get; set; }
        public SaveConfirmedModel(IShoppingData shoppingData)
        {
            this.ShoppingData = shoppingData;
        }
        public IActionResult OnGet(int? storeId)
        {
            if (!storeId.HasValue)
            {
                RedirectToPage("./NotFound");
            }
            MyStore = this.ShoppingData.StoreById((int)storeId);
            return Page();
        }
    }
}