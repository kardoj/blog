using AspNetCore.Identity.MongoDbCore.Models;
using System;

namespace Blog.Web.Identity
{
    public class User : MongoIdentityUser<Guid>
    {
        public User() { }

        public User(string userName, string email) : base(userName, email) { }
    }
}
