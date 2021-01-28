
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Blog.Models
{
   public class User
    {
        [Key]
        public int id { get; set; }

        [MaxLength(50)]
        [Display(Name = "Username")]
        [Required]
        public string username { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Range(10, 50)]
        public string email { get; set; }

       
        [MaxLength(50)]
        [Display(Name = "Password")]
        public System.Security.SecureString password { get; set; }
       
        public bool is_staff { get; set; }

    }

  




    public class Author
    {

        public int id { get; set; }
        public User user { get; set; }
        public List<Article> blogs { get; set; }

    }
    public class Article
    {
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string content { get; set; }
        public byte[] thumbnail { get; set; }
        public int authorId { get; set; }
        public Author author { get; set; }
    }

    public class ArticleDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public int authorId { get; set; }

    }


    public class ArticleDetailDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public byte[] thumbnail { get; set; }
        public int authorId { get; set; }

    }


}