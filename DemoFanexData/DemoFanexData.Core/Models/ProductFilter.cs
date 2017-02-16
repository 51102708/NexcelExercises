namespace DemoFanexData.Core.Models
{
    public class ProductFilter
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int SupplierID { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public int UnitsOnOrder { get; set; }

        public int ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public Category Category { get; set; }
    }
}