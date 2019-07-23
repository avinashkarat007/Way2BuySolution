using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServiceLayer.Abstract;
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
    }
}
