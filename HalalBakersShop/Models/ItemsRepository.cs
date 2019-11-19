using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HalalBakersShop.Models
{
    public class ItemsRepository: IItemsRepository
    {
        private readonly AppDbContext _appDbContext;

        public ItemsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Items> AllItems
        {
            get
            {
                return _appDbContext.Items.Include(c => c.Category);
            }
        }

        public IEnumerable<Items> ItemsOfTheWeek
        {
            get
            {
                
                return _appDbContext.Items.Include(c => c.Category).Where(p => p.IsItemsOfTheWeek);
            }
        }

        public Items GetItemsById(int pieId)
        {
            return _appDbContext.Items.FirstOrDefault(p => p.ItemsId == pieId);
        }


        public void AddItems(Items item)
        {
            _appDbContext.Items.Add(item);
            _appDbContext.SaveChanges();
        }

        public bool updateItems(Items item)
        {
            Items itemdb = _appDbContext.Items.Where(x => x.ItemsId == item.ItemsId).FirstOrDefault();
            itemdb.Name = item.Name;
            itemdb.LongDescription = item.LongDescription;
            itemdb.ImageUrl = item.ImageUrl;
            itemdb.InStock = item.InStock;
            itemdb.ImageThumbnailUrl = item.ImageThumbnailUrl;
            itemdb.IsItemsOfTheWeek = item.IsItemsOfTheWeek;
            itemdb.Price = item.Price;
            itemdb.ShortDescription = item.ShortDescription;
            _appDbContext.SaveChanges();
            return true;
        }

        public bool deleteItem(Items item)
        {
            _appDbContext.Remove(item);
            _appDbContext.SaveChanges();
            return true;
        }
    }
}
