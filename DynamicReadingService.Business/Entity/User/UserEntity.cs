using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicReadingService.Business.Entity.User
{
    public class UserEntity
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
