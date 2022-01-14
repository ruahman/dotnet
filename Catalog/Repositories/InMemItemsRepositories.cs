using System.Collections.Generic;
using System;
using Catalog.Entities;
using System.Linq;

namespace Catalog.Repositories {
    public class InMemItemsRepository {
        private readonly List<Item> items = new() {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price=9, CreatedDate=DateTime.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price=11, CreatedDate=DateTime.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron sword", Price=20, CreatedDate=DateTime.UtcNow },
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }
    }
}