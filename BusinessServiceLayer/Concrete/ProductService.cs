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
        private IProductRepository productRepository;

        public ProductService(IProductRepository ProductRepository)
        {
            this.productRepository = ProductRepository;
        }

        public IEnumerable<Product> Products
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Product DeleteProduct(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void SaveProduct(Product category)
        {
            throw new NotImplementedException();
        }
    }
}
