using System;
using System.Collections.Generic;

#nullable disable

namespace PIA_Backend.Database
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
