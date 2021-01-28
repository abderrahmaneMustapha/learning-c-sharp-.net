using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class User
    {
        public int id { get; set; }

        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
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
        public string title { get; set; }
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