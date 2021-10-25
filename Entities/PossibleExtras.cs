using System.Collections.Generic;

namespace Entities
{
    public class PossibleExtras
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ExtraValues> ExtraValues { get; set; }
    }
}
