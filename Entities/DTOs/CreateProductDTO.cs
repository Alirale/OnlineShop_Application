using System.Collections.Generic;

namespace Entities.DTOs
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public int PictureId { get; set; }
        public int PossibleExtrasId { get; set; }
        public List<CreateProductSpecial> Specials { get; set; }
        public List<CreateProductExtras> Extra { get; set; }
    }
}
