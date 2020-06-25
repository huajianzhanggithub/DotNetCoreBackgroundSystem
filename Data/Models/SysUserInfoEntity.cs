using Data.Enums;
using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class SysUserInfoEntity : BaseEntity<int>
    {
        public string Nickname { get; set; }
        public string ImageUrl { get; set; }
        public SexEnum Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public int SysUserAuthId { get; set; }
        public virtual SysUserAuthEntity SysUserAuth { get; set; }
    }
}
