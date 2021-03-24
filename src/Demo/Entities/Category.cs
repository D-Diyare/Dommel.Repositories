using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dommel.Repositories.Demo.Entities.Base;

namespace Dommel.Repositories.Demo.Entities
{
    [Table(nameof(Category))]
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}