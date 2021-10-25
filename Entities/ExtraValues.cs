namespace Entities
{
    public class ExtraValues
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public PossibleExtras PossibleExtra { get; set; }
        public int PossibleExtraId { get; set; }
        public Extra Extra { get; set; }
        public int ExtraId { get; set; }

    }
}
