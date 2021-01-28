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
            
            Console.WriteLine(response.ToString());

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

        private void saveNewUser()
        {
            
            var user = new User { id = 1, email = "abd@mail.com", is_staff = true, password = "234RTY", username = "abderrahmaneMK" };
            db.Users.Add(user);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }
    }
}
