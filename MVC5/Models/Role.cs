﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}