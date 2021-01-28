using Blog.Data;
using Blog.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class UsersController : ApiController
    {
        private BlogContext db = new BlogContext();
 
        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Register
        [System.Web.Http.Route("api/Register")]
        [ResponseType(typeof(User))]
        [ValidateAntiForgeryToken]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var check = db.Users.Any(s => s.email == user.email);
            if (check)
            {
                return BadRequest();
            }

            user.is_staff = false;
            var dbuser = db.Users.Add(user);

            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();

            

            return CreatedAtRoute("DefaultApi", new { id = dbuser.id }, dbuser);
        }


        [System.Web.Http.Route("api/Login")]
        [ResponseType(typeof(User))]
        [ValidateAntiForgeryToken]
        [System.Web.Http.HttpPost]
        // POST: api/Login
        public IHttpActionResult Login(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var check = db.Users.Any(s => s.password == user.password && s.email == user.email);
            if (!check)
            {
                return BadRequest();
            }

            var dbuser = db.Users.Where(s => s.email == user.email).FirstOrDefault();

            return CreatedAtRoute("DefaultApi", new { id = dbuser.id }, dbuser);
        }
        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.id == id) > 0;
        }
    }
}