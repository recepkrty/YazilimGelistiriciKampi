﻿using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Kalem", UnitPrice = 20, UnitsInStock = 50 },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Silgi", UnitPrice = 2, UnitsInStock = 40 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "PC", UnitPrice = 7000, UnitsInStock = 5 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Telefon", UnitPrice = 3000, UnitsInStock = 10 },
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Kamera", UnitPrice = 750, UnitsInStock = 20 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
