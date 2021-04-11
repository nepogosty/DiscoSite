using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Disco2.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }
}