﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
            
        }

        public string TProductByMaxPrice()
        {
            return _productDal.ProductByMaxPrice();
        }

        public string TProductByMinPrice()
        {
            return _productDal.ProductByMinPrice();
        }

        public void TAdd(Product entity)
        {
           _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetByID(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public int TProductCount()
        {
            return _productDal.ProductCount();
        }

        public int TProductCountByCategoryNameDrink()
        {
            return _productDal.ProductCountByCategoryNameDrink();
        }

        public int TProductCountByCategoryNameHamburger()
        {
            return _productDal.ProductCountByCategoryNameHamburger();
        }

        public decimal TProductPriveAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public decimal TProductAvgPriceByCategoryNameHamburger()
        {
            return _productDal.ProductAvgPriceByCategoryNameHamburger();
        }
    }
}
