using System.Collections.Generic;

namespace Entities.DTOs
{
    public class ShowExtra
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public List<ShowExtraValues> ExtraValues { get; set; }
    }
}
