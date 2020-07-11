using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingDirrectory.Models
{
    public class Store
    {
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string Address { get; set; }
        [Required, StringLength(30)]
        public string City { get; set; }

        public string CategoryName
        {
            get
            {
                var categoryData = new InMemoryCategoryData();
                return categoryData.CategoryNameById(CategoryId);
            }
        }
    }
}
