namespace DemoFanexData.Core.Models
{
    using Fanex.Data.Repository;

    internal class ProductsCriteria : CriteriaBase
    {
        public override string GetSettingKey() => "GetAllProducs";

        public override bool IsValid() => true;
    }
}