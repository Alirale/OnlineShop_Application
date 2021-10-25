namespace Entities.DTOs
{
    public class CreateComment
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string CommentText { get; set; }
    }
}
