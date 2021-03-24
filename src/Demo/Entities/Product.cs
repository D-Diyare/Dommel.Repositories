using System.ComponentModel.DataAnnotations.Schema;
using Dommel.Repositories.Demo.Entities.Base;

namespace Dommel.Repositories.Demo.Entities
{
    [Table(nameof(Product))]
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}