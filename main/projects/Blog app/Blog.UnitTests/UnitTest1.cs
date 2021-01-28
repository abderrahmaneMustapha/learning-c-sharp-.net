using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blog.Models;
using Blog.Data;
using Blog.Controllers;
using System.Net.Http;
using System.Web.Http;

using System.Linq;
using System.Collections.Generic;
using System;

namespace Blog.UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        BlogContext db = new BlogContext();

        [TestMethod]
        public void TestRegisterDataSaved()
        {
            var controller = new UsersController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var user = getTestUsers()[2];
            var response = controller.Register(user);

         

            // check if the data is really saved 
            var check = db.Users.Any(s => s.email == "abderrahmane@mail.com");
            Assert.IsTrue(check);

        }

        [TestMethod]
        public void TestLoginSuccess()
        {
            var controller = new UsersController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            saveNewUser();

            var user = getTestUsers()[0];

            var response = controller.Login(user);

        }

        [TestMethod]
        public void TestLoginFaillure()
        {
            var controller = new UsersController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            saveNewUser();

            var user = getTestUsers()[1];

            var response = controller.Login(user);


            Assert.AreEqual(response.ToString(), "System.Web.Http.Results.BadRequestResult");
    

        }

        [TestMethod]
        public void TestCreateAuthor()
        {
            var controller = new AuthorsController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
           
            var author = unsavedNewAuthor();

           var response = controller.PostAuthor(author);

          
        }

        [TestMethod]
        public void TestCreateArticle()
        {
            var controller = new ArticlesController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var article = unsavedArticle();

            var response = controller.PostArticle(article);
            Assert.AreEqual(response.ToString(), "System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult`1[Blog.Models.ArticleDto]");
        }
        private List<User> getTestUsers()
        {
            var testUsers = new List<User>();
            testUsers.Add(new User { id = 1, email = "abd@mail.com", is_staff = true, password = "234RTY", username = "abderrahmaneMK" });
            testUsers.Add(new User { id = 2, email = "abdTYR@mail.com", is_staff = true, password = "234eeeTY", username = "abdMustapha" });
            testUsers.Add(new User
            {
                email = "abderrahmane@mail.com",
                password = "12345RTy",
                username = "abderrahmaneMustapha"
            });
            return testUsers;
        }

  

        private User saveNewUser()
        {
            
            var user = new User { id = 1, email = "abd@mail.com", is_staff = true, password = "234RTY", username = "abderrahmaneMK" };
            db.Users.Add(user);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();

            return user;
        }

        private User createUser(int id, string email , string password, string username)
        {
            var user = new User { id = id, email = email, is_staff = true, password = password, username = username};
            db.Users.Add(user);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();

            return user;

        }

        private Author saveNewAuthor()
        {

            var author = new Author { id = 1, user= saveNewUser() , blogs = null};
            db.Authors.Add(author);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();

            return author;
        }
        private Author unsavedNewAuthor()
        {

            var author = new Author { id = 1, user = saveNewUser(), blogs = null };
          

            return author;
        }

        private List<Author> getTestSavedAuthors()
        {
            var testAuthors = new List<Author>();
            testAuthors.Add(new Author { id = 0, blogs=null, user=createUser(100, "uaaa@mail.com", "azod344AA","Abderrahmane") });
            testAuthors.Add(new Author { id = 1, blogs = null, user = createUser(101, "uTTaaa@mail.com", "azod344AA", "AbderrTTahmane") });
            testAuthors.Add(new Author { id = 2, blogs = null, user = createUser(102, "uTTaaa@mail.com", "azodJFJF33344AA", "OOOOahmane") });


            foreach (var author in testAuthors)
            {
                db.Authors.Add(author);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
            }
            return testAuthors;
        }

        private Article unsavedArticle()
        {
            var article = new Article
            {
                id = 3,
                authorId = saveNewAuthor().id,
                content = "azeaz azeaze  azeaze  azeaze  azeaze  azeaze ",
                thumbnail = null,
                title = "azeazeazeaze"
            };

            return article;
        }
    }
}
