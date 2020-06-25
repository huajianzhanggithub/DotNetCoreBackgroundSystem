using System;
using System.Collections.Generic;
using System.Text;
using Data.Enums;
using Data.Infrastructure;

namespace Data.Models
{
    public class SysUserAuthEntity : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginType LoginType { get; set; }
    }
}
