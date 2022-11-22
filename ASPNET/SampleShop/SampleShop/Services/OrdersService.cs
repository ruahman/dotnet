using System;
using System.Collections.Generic;
using System.Linq;
using SampleShop.Interfaces;
using SampleShop.Model;
using SampleShop.Queries;

namespace SampleShop.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly GetAllOrdersQuery queryAll;
        private readonly GetAllItemsQuery queryAllItems;
        private readonly GetOrderByIdQuery queryById;
        private readonly AddOrderQuery queryAdd;
        private readonly DeleteOrderQuery queryDelete;


        public OrdersService(GetAllOrdersQuery queryAllOrders, GetAllItemsQuery queryAllItems,
                             GetOrderByIdQuery queryById, AddOrderQuery queryAdd,
                             DeleteOrderQuery queryDelete)
        {
            this.queryAll = queryAllOrders;
            this.queryAllItems = queryAllItems;
            this.queryById = queryById;
            this.queryAdd = queryAdd;
            this.queryDelete = queryDelete;
        }

        /// <summary>
        /// Lists all orders that exist in db
        /// </summary>
        public IEnumerable<Order> All()
        {
            return queryAll.Execute().ToList();
        }



        /// <summary>
        /// Gets single order by its id
        /// </summary>
        public Order GetById(int id)
        {
            return queryById.Execute(id);
        }

        /// <summary>
        /// Tries to add given order to db, after validating it
        /// </summary>
        public Order Add(Order newOrder)
        {
            if (newOrder == null)
            {
                throw new ArgumentNullException("newOrder");
            }

            var result = ValidateNewOrder(newOrder);
            if ((result & ValidationResult.Ok) == ValidationResult.Ok)
            {
                queryAdd.Execute(newOrder);
                return newOrder;
            }

            return null;
        }

        /// <summary>
        /// Checks whether given order can be added.
        /// Performs logical and business validation.
        /// </summary>
        public ValidationResult ValidateNewOrder(Order newOrder)
        {
            var result = ValidationResult.Default;

            if (newOrder == null)
            {
                throw new ArgumentNullException("newOrder");
            }

            var items = queryAllItems.Execute();

            foreach (var item in newOrder.OrderItems)
            {
                if (item.Value <= 0) result |= ValidationResult.NoItemQuantity;
                if (!items.Any(p => p.Id == item.Key))
                {
                    result |= ValidationResult.ItemDoesNotExist;
                }
            }

            if (result == ValidationResult.Default)
            {
                result = ValidationResult.Ok;
            }

            return result;
        }

        /// <summary>
        /// Deletes (if exists) order from db (by its id)
        /// </summary>
        public void Delete(int id)
        {
            queryDelete.Execute(id);
        }

        /// <summary>
        /// Returns all orders (listed chronologically) between a given start date and end date.
        /// Start and end dates must be from the past (not in the future or today).
        /// </summary>
        public IEnumerable<Order> GetByDates(DateTime start, DateTime end)
        {
            // TODO
            // Implement method returning all orders (use queryAll) between a give start date and end date.
            // Method should check if dates are in the past (not in the future or today) else
            // throw an ArgumentException. 
            // Return all orders in chronological order. 

            if (end >= DateTime.Now || start >= DateTime.Now)
            {
                throw new ArgumentException();
            }

            return queryAll.Execute().ToList().Where(x => x.CreateDate >= start && x.CreateDate <= end);

        }

        /// <summary>
        /// Returns the list of items sold across all orders in a given day with
        /// the total revenue
        /// Day must be from the past (not in the future or today).
        /// </summary>
        public IEnumerable<ItemSoldStatistics> GetItemsSoldByDay(DateTime day)
        {
            // TODO
            // Implement method returning data described in a method summary.
            // Use queryAll and queryAllItems.

            if (day >= DateTime.Now)
            {
                throw new ArgumentException();
            }

            var orders = queryAll.Execute().ToList().Where(x => x.CreateDate == day);

            var stats = new Dictionary<int, ItemSoldStatistics>();



            foreach (var order in orders)
            {
                foreach (var itemKeyValue in order.OrderItems)
                {
                    Item item = queryAllItems.Execute().ToList().Where(x => x.Id == itemKeyValue.Key).First();


                    stats.TryGetValue(item.Id, out ItemSoldStatistics stat);
                    stat ??= new ItemSoldStatistics();

                    stat.ItemId = item.Id;
                    stat.Total += item.Price * itemKeyValue.Value;
                    stats[item.Id] = stat;
                }
            }

            //var res = new List<ItemSoldStatistics>();
            //foreach (var dic in stats)
            //{
            //    res.Add(dic.Value);
            //}

            //return res;

            var res = stats.Select(x => x.Value).ToList();

            return res;

            //throw new NotImplementedException();
        }
    }
}
