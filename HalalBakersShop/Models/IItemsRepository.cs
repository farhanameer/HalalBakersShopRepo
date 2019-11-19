using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalalBakersShop.Models
{
    public interface IItemsRepository
    {
        IEnumerable<Items> AllItems { get; }
        IEnumerable<Items> ItemsOfTheWeek { get; }
        Items GetItemsById(int itemId);

        void AddItems(Items item);
        bool updateItems(Items item);

        bool deleteItem(Items item);
    }
}
