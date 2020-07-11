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
    public class ListModel : PageModel
    {
        public IEnumerable<Store> Stores { get; set; }
        public IShoppingData storeData;
        public ICategoryData categoryData;
        public IEnumerable<Category> Categories { get; set; }

        [BindProperty]
        public string ListTitle { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedCategory { get; set; }
        public ListModel(IShoppingData shoppingData, ICategoryData categoryList)
        {
            storeData = shoppingData;
            categoryData = categoryList;
            Categories = categoryData.CategoryList();
        }
        public IActionResult OnGet(int? categoryId)
        {
            if (categoryId.HasValue && categoryId>0)
            {
                Stores = storeData.StoreListByCategory((int)categoryId);
                ListTitle = "Store Directory - " + categoryData.CategoryNameById((int)categoryId);
            }
            else
            {
                Stores = storeData.StoreList();
                ListTitle = "Store Directory";
            }
            return Page();
        }
        //public void OnGet()
        //{
        //    if (SelectedCategory == 0)
        //    {
        //        Stores = storeData.StoreList();
        //    }
        //    else
        //    {
        //        Stores = storeData.StoreListByCategory(SelectedCategory);
        //    }
        //}
    }
}