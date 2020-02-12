using AspNetCore.Identity.MongoDbCore.Models;
using System;

namespace Blog.Web.Identity
{
    public class UserRole : MongoIdentityRole<Guid>
    {
        public UserRole() : base() { }

        public UserRole(string roleName) : base(roleName) { }
    }
}
