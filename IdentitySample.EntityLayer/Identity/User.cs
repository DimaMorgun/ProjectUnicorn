using IdentitySample.EntityLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentitySample.EntityLayer.Identity
{
    public class User : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RemoveDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
