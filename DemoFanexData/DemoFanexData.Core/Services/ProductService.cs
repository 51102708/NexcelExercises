namespace DemoFanexData.Core.Services
{
    using Fanex.Data;
    using Fanex.Data.Repository;
    using Models;
    using System;
    using System.Collections.Generic;

    public class ProductService : IBaseService<Product>
    {
        //Normal Query
        public IEnumerable<Product> GetTenMostExpensiveProducts()
        {
            using (var objectDB = new ObjectDb("GetTenMostExpensiveProducts"))
            {
                //var parameters = new ProductFilter
                //{
                //    Name = "<value>",
                //    UnitPrice = <value>
                //};

                IEnumerable<Product> products = objectDB.Query<Product>();

                return products;
            }
        }

        //Multimapping
        public IEnumerable<Product> GetProductWithCategory(int id)
        {
            using (var objectDB = new ObjectDb("GetProductWithCategory"))
            {
                var parameters = new
                {
                    Id = id
                };

                IEnumerable<Product> products = objectDB.Query<Product, Category, Product>(
                    (product, category) => { product.Category = category; return product; },
                    "CategoryID",
                    parameters
                    );

                return products;
            }
        }

        //Repository - NORMAL
        public IEnumerable<Product> GetAll()
        {
            var repository = new DynamicRepository();
            var criteria = new ProductsCriteria();

            return repository.Fetch<Product>(criteria);
        }

        //Repository - Multiple
        public ProductsAndCategories GetAllProductsAndCategories()
        {
            var repository = new DynamicRepository();
            var criteria = new ProductsAndCategoriesCriteria();

            var result = repository.FetchMultiple<Category, Product>(criteria);

            return new ProductsAndCategories()
            {
                Categories = result.Item1,
                Products = result.Item2
            };
        }

        public void Create(Product obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}