using MVC5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC5.DAL
{
    //DropCreateDatabaseIfModelChanges
    public class ApplicationDBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDBContext>
    {
        protected override void Seed(ApplicationDBContext context)
        {
            var Users = new List<User>
            {
                new User { UserName="fcj" ,EmailAddress="782773117@qq.com",PassWord="123456"},
                new User { UserName="dqf" ,EmailAddress="625336789@qq.com",PassWord="123456"}
            };
            Users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var Roles = new List<Role>
            {
                new Role { RoleName="Administrator"},
                new Role { RoleName="General Users"}
            };
            Roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            var UserRoles = new List<UserRole>
            {
                new UserRole { RoleID=1 ,UserID=1 },
                new UserRole { RoleID=2 ,UserID=1 },
                new UserRole { RoleID=2 ,UserID=2 }
            };
            UserRoles.ForEach(s => context.UserRoles.Add(s));
            context.SaveChanges();
        }
    }
}