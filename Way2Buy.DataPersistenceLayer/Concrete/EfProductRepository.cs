﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Way2Buy.BusinessObjects.Entities;
using Way2Buy.DataPersistenceLayer.Abstract;

namespace Way2Buy.DataPersistenceLayer.Concrete
{
    public class EfProductRepository : IProductRepository
    {
        private readonly EfDbContext _dbContext = new EfDbContext();

        public IEnumerable<Product> Products
        {
            get { return _dbContext.Products.ToList(); }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                _dbContext.Products.Add(product);
            }
            else
            {
                var pdt = _dbContext.Products.FirstOrDefault(x => x.ProductId  == product.ProductId);
                if (pdt != null)
                {
                    pdt.Name = product.Name.Trim();
                    pdt.Description = product.Description.Trim();
                    pdt.CategoryId = product.CategoryId;
                    pdt.Price = product.Price;
                    pdt.IsOfferItem = product.IsOfferItem;
                    pdt.OfferPrice = product.OfferPrice;
                    if (product.ImageData!= null)
                    {
                        pdt.ImageData = product.ImageData;
                        pdt.ImageMimeType = product.ImageMimeType;
                    }
                }
            }
            _dbContext.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
            return product;
        }

        public Product GetProduct(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);
            return product;
        }
    }
}
