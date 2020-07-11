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
    public class EditModel : PageModel
    {
        private readonly IShoppingData shopingData;
        [BindProperty]
        public string TitleMessage { get; set; }
        [BindProperty]
        public Store MyStore { get; set; }
        [BindProperty]
        public List<Category> Categories { get; set; }
        public EditModel(IShoppingData shoppingData, ICategoryData categoryData)
        {
            this.shopingData = shoppingData;
            this.Categories = categoryData.CategoryList();
        }
        public IActionResult OnGet(int? storeId)
        {
            if (storeId.HasValue)
            {
                this.MyStore = this.shopingData.StoreList().SingleOrDefault(s => s.Id == storeId);
                if (this.MyStore != null)
                {
                    this.TitleMessage = "Edit - " + this.MyStore.Name;
                }
                else
                {
                    return RedirectToPage("./SaveConfirmed", new { storeId = this.MyStore.Id });
                }
            }
            else
            {
                this.TitleMessage = "New Store";
                this.MyStore = new Store();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (this.MyStore.Id > 0)
            {
                this.shopingData.Update(MyStore);
            }
            else
            {
                this.MyStore = this.shopingData.Add(MyStore);
            }
            return RedirectToPage("./SaveConfirmed", new { storeId = this.MyStore.Id });
        }
    }
}