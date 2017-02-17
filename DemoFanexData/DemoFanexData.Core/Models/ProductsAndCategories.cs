using System.Collections.Generic;

namespace DemoFanexData.Core.Models
{
    public class ProductsAndCategories
    {
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}