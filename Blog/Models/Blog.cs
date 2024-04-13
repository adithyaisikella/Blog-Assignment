using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Blog
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime  PublicationDate{ get; set; }

    }
}
