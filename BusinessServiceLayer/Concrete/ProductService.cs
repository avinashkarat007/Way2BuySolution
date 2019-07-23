using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServiceLayer.Abstract;
using Way2Buy.BusinessObjects.Entities;
using Way2Buy.DataPersistenceLayer.Abstract;

namespace BusinessServiceLayer.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository ProductRepository)
        {
            this.productRepository = ProductRepository;
        }

        public IEnumerable<Product> Products
        {
            get { return this.productRepository.Products; }
        }


        public Product DeleteProduct(int categoryId)
        {
            return this.productRepository.DeleteProduct(categoryId);
        }

        public Product GetProduct(int categoryId)
        {
            return this.productRepository.GetProduct(categoryId);
        }

        public void SaveProduct(Product product)
        {
            this.productRepository.SaveProduct(product);
        }
    }
}
