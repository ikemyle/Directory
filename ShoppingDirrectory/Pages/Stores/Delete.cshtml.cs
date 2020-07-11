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
    public class DeleteModel : PageModel
    {
        private readonly IShoppingData ShoppingData;

        [BindProperty]
        public Store MyStore { get; set; }
        public DeleteModel(IShoppingData shoppingData)
        {
            this.ShoppingData = shoppingData;
        }

        public IActionResult OnGet(int storeId)
        {
            MyStore = this.ShoppingData.StoreById(storeId);
            return Page();
        }

        public IActionResult OnPost(int storeId)
        {
            if (storeId > 0)
            {
                var store = this.ShoppingData.Delete(storeId);
                if (store==null)
                {
                   return RedirectToPage("./NotFound");
                }
            }
            return RedirectToPage("./List");
        }
    }
}