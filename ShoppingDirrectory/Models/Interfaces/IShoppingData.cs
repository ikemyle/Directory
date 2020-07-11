using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingDirrectory.Models.Interfaces
{
    public interface IShoppingData
    {
        IEnumerable<Store> StoreListByCategory(int categoryId);
        Store StoreById(int storeId);
        IEnumerable<Store> StoreList();
        Store Update(Store updateStore);
        Store Add(Store newStore);
        Store Delete(int Id);
    }
}
