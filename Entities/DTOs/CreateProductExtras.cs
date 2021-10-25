using System.Collections.Generic;

namespace Entities.DTOs
{
    public class CreateProductExtras
    {
        public int Count { get; set; }
        public double Price { get; set; }
        public List<CreateProductExtraValues> ExtraValues { get; set; }

    }
}
