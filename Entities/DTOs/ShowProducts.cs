using System;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class ShowProducts
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ShowPicture Picture { get; set; }
        public List<object> Comments { get; set; }
        public List<object> Extras { get; set; }
        public List<object> Specials { get; set; }
    }
}
