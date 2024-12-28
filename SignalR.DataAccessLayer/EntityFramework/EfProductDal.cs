using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            using var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public decimal ProductAvgPriceByCategoryNameHamburger()
        {
            using var context = new SignalRContext();
            return context.Products
            .Where(p => p.Category.CategoryName == "Hamburger") 
            .Average(p => p.Price);



        }

        public string ProductByMaxPrice()
        {
            using var context = new SignalRContext();
            var result = context.Products
           .Where(x => x.Price == context.Products
           .Max(y => y.Price))
           .Select(z => new { z.ProductName, Price = z.Price.ToString() })
           .FirstOrDefault();

            if (result != null)
            {
                return $"{result.ProductName} {result.Price:0.00}₺";
            }

            return "No product found with minimum price.";
        }
        public string ProductByMinPrice()
        {
            using var context = new SignalRContext();
            var result = context.Products
            .Where(x => x.Price == context.Products
            .Min(y => y.Price))
            .Select(z => new { z.ProductName, Price = z.Price
            .ToString() })
            .FirstOrDefault();

            if (result != null)
            {
                return $"{result.ProductName} {result.Price:0.00}₺";
            }

            return "Ürün Bulunamadı.";
        
    }

    public int ProductCount()
    {
        using var context = new SignalRContext();
        return context.Products.Count();
    }

    public int ProductCountByCategoryNameDrink()
    {
        using var context = new SignalRContext();
        return context.Products
            .Where(x => x.CategoryID == (context.Categories
            .Where(y => y.CategoryName == "Hamburger")
            .Select(z => z.CategoryID)
            .FirstOrDefault()))
            .Count();
    }

    public int ProductCountByCategoryNameHamburger()
    {
        using var context = new SignalRContext();
        return context.Products
            .Where(x => x.CategoryID == (context.Categories
            .Where(y => y.CategoryName == "Icecek")
            .Select(z => z.CategoryID)
            .FirstOrDefault()))
            .Count();
    }

    public decimal ProductPriceAvg()
    {
        using var context = new SignalRContext();
        return context.Products.Average(x => x.Price);
    }
}
}
