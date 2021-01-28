
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Blog.Data;
using Blog.Models;

namespace Blog.Controllers
{
    public class ArticlesController : ApiController
    {
        private BlogContext db = new BlogContext();

        // GET: api/Articles
        public IQueryable<ArticleDto> GetArticles()
        {
            var articles = from article in db.Articles
                           select new ArticleDto()
                           {
                               id = article.id,
                               title = article.title,
                               authorId = article.authorId
                           };
            return articles;
        }

        // GET: api/Articles/5
        [ResponseType(typeof(ArticleDetailDto))]
        public IHttpActionResult GetArticle(int id)
        {
            var article = db.Articles.Include(b => b.author).Select(
                b
                => new ArticleDetailDto()
                {
                    id = b.id,
                    title = b.title,
                    authorId = b.authorId,
                    thumbnail = b.thumbnail

                }
                );
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/Articles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticle(int id, Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.id)
            {
                return BadRequest();
            }

            db.Entry(article).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Articles
        [ResponseType(typeof(Article))]
        public IHttpActionResult PostArticle(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Articles.Add(article);
            db.SaveChanges();

            db.Entry(article).Reference(x => x.author).Load();

            var articleDto = new ArticleDto()
            {
                id = article.id,
                title = article.title,
                authorId = article.authorId
            };

            return CreatedAtRoute("DefaultApi", new { id = article.id }, articleDto);
        }

        // DELETE: api/Articles/5
        [ResponseType(typeof(Article))]
        public IHttpActionResult DeleteArticle(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            db.Articles.Remove(article);
            db.SaveChanges();

            return Ok(article);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticleExists(int id)
        {
            return db.Articles.Count(e => e.id == id) > 0;
        }
    }
}