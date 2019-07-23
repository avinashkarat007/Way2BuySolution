using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Way2Buy.BusinessObjects.Entities;

namespace BusinessServiceLayer.Abstract
{
    public interface IProductService
    {

        IEnumerable<Product> Products { get; }

        void SaveProduct(Product category);

        Product DeleteProduct(int categoryId);

        Product GetProduct(int categoryId);
    }
}
