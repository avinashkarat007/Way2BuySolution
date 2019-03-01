using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Way2Buy.BusinessObjects.Entities;

namespace Way2Buy.DataPersistenceLayer.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product category);

        Product DeleteProduct(int categoryId);

        Product GetProduct(int categoryId);
    }
}
