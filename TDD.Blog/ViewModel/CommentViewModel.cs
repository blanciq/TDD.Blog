using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TDD.Blog.ViewModel
{
    public class CommentViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [Required]
        public long PostId { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}