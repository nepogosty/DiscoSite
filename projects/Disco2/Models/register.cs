﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Disco2.Models
{
    public class LoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
    public class RegisterModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }
}