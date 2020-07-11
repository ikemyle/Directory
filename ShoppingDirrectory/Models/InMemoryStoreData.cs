using ShoppingDirrectory.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingDirrectory.Models
{
    public class InMemoryStoreData : IShoppingData
    {
        readonly List<Store> storeList;

        public InMemoryStoreData()
        {
            storeList = new List<Store>
            {
                new Store {Id =1,Name="Papa's Store",Address ="123 Ave Americanos", City="New York",CategoryId=1},
                new Store {Id =2,Name="Duanne Read",Address ="220 Fifth Ave", City="New York",CategoryId=2},
                new Store {Id =3,Name="Max",Address ="3330 Lexington Ave", City="New York",CategoryId=3},
                new Store {Id =4,Name="Centurt 21",Address ="2 Liberty Plaza", City="New York",CategoryId=4},
                new Store {Id =5,Name="Whole Foods",Address ="1333 3rd Ave", City="New York",CategoryId=1},
                new Store {Id =6,Name="Bloomingdale",Address ="560 Lexington", City="New York",CategoryId=4},
                new Store {Id =7,Name="Saks 5th Ave",Address ="666 Fifth Ave", City="New York",CategoryId=4}
            };
        }

        public Store Add(Store newStore)
        {
            storeList.Add(newStore);
            newStore.Id = storeList.Max(x => x.Id) + 1;
            return newStore;
        }

        public Store Delete(int Id)
        {
            var store = storeList.SingleOrDefault(x => x.Id == Id);
            if (store != null)
            {
                storeList.Remove(store);
            }
            return store;
        }

        public IEnumerable<Store> StoreList()
        {
            return storeList;
        }

        public IEnumerable<Store> StoreListByCategory(int categoryId)
        {
            var storeByCategory = storeList.Where(x => x.CategoryId == categoryId).ToList();
            var storesByCategory = from s in storeList
                              where s.CategoryId == categoryId
                              orderby s.Name
                              select s;
            return storesByCategory.ToList();
        }

        public Store StoreById(int storeId)
        {
            return storeList.SingleOrDefault(s => s.Id == storeId);
        }
        public Store Update(Store updateStore)
        {
            var store = storeList.SingleOrDefault(r => r.Id == updateStore.Id);
            if (store != null)
            {
                store.Name = updateStore.Name;
                store.Address = updateStore.Address;
                store.City = updateStore.City;
                store.CategoryId = updateStore.CategoryId;
            }
            return store;
        }
    }
}
