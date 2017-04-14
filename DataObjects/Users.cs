﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string UserRolesID { get; set; }

        public List<UserRoles> UserRoles { get; set; }

        public bool Active { get; set; }

    }
}
