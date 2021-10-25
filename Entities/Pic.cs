using System.Collections.Generic;

namespace Entities
{
    public class Pic
    {
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public string ImagePath { get; set; }
    }
}