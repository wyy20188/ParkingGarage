using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC5.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string PassWord { get; set; }
        public DateTime RegisterDate { get; set; }
        public string PhoneNumber { get; set; }
        public string CreditCard { get; set; }
        public DateTime LastLogin { get; set; }
        public int LoginCount { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Car> UserOwnCar { get; set; }
    }
}