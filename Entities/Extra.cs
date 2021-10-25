using System.Collections.Generic;

namespace Entities
{
    public class Extra
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public ICollection<ExtraValues> ExtraValues { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
