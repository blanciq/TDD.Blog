namespace TDD.Blog.Models
{
    public class Comment
    {
        public long CommentId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public long PostId { get; set; }
        public Post Post { get; set; }
    }
}