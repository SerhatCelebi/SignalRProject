using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x => x.Description == "Müsteri Masada").Count();
        }

        public string LastOrder()
        {
            using var context = new SignalRContext();

            var result = context.Orders
                .OrderByDescending(x => x.OrderID)
                .Take(1)
                .Select(y => new
                {
                    TableName = y.TableNumber.ToString(),
                    Price = y.TotalPrice.ToString()
                })
                .FirstOrDefault();

            if (result != null)
            {
                return $"Table Name: {result.TableName}, Price: {result.Price}";
            }

            return "Son sipariş yok.";
        }

        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();
            var today = DateTime.Now.Date;
            return context.Orders
                .Where(x => x.Date.Date == today)
                .Sum(y => y.TotalPrice);
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
    }
}
