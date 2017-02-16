namespace DemoFanexData.Core.Services
{
    using Fanex.Data;
    using Models;
    using System;
    using System.Collections.Generic;

    public class ProductService : IBaseService<ProductFilter>
    {
        public void Create(ProductFilter obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProductFilter Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductFilter> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductFilter obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductFilter> GetTenMostExpensiveProducts()
        {
            using (var objectDB = new ObjectDb("Query_TenMostExpensiveProducts"))
            {
                //var parameters = new ProductFilter
                //{
                //    Name = "<value>",
                //    UnitPrice = <value>
                //};

                IEnumerable<ProductFilter> products = objectDB.Query<ProductFilter>();

                return products;
            }
        }
    }
}