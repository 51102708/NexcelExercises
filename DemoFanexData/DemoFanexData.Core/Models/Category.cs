using System.ComponentModel;

namespace DemoFanexData.Core.Models
{
    public class Category
    {
        [DisplayName("CategoryId")]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }
    }
}