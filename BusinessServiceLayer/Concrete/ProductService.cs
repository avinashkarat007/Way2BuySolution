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
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
        }

        public IEnumerable<Product> Products
        {
            get { return this._productRepository.Products; }
        }

        public Product DeleteProduct(int categoryId)
        {
            return this._productRepository.DeleteProduct(categoryId);
        }

        public Product GetProduct(int categoryId)
        {
            return this._productRepository.GetProduct(categoryId);
        }

        public void SaveProduct(Product product)
        {
            this._productRepository.SaveProduct(product);
        }

        public IEnumerable<Category> GetCategories()
        {
            var category = this._categoryRepository.Categories.ToList();
            return category;
        }
    }
}
