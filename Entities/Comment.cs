namespace Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CommentText { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}
