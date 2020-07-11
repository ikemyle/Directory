using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingDirrectory.Models
{
    public class Category
    {
        public Category(int newId, string newName)
        {
            Id = newId;
            Name = newName;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
