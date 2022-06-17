using System;
using System.Collections.Generic;

#nullable disable

namespace DemoEFCore.Models
{
    public partial class AccountUser
    {
        public Guid UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserFullname { get; set; }
        public int UserRole { get; set; }
    }
}
