using System;
using System.Collections.Generic;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Pic Picture { get; set; }
        public int PictureId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Extra> Extras { get; set; }
        public ICollection<Special> Specials { get; set; }
    }
}
