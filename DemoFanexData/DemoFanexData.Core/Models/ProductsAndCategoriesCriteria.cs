namespace DemoFanexData.Core.Models
{
    using Fanex.Data.Repository;

    internal class ProductsAndCategoriesCriteria : CriteriaBase
    {
        public override string GetSettingKey() => "GetAllProductsAndCategories";

        public override bool IsValid() => true;
    }
}