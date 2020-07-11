using ShoppingDirrectory.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingDirrectory.Models
{
    public class InMemoryCategoryData : ICategoryData
    {
        readonly List<Category> categoryList;

        public InMemoryCategoryData()
        {
            categoryList = new List<Category>
            {
                new Category(1, "Food Store"),
                new Category (2, "Pharmacy"),
                new Category (3,"Office Supply"),
                new Category (4,"Apparel")
            };
        }
        public Category Add(Category newCategory)
        {
            throw new NotImplementedException();
        }

        public List<Category> CategoryList()
        {
            return categoryList.OrderBy(x => x.Name).ToList();
        }

        public string CategoryNameById(int Id)
        {
            return categoryList.SingleOrDefault(x => x.Id == Id)?.Name;
        }

        public Category Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category UpdateCategory)
        {
            throw new NotImplementedException();
        }
    }
}
