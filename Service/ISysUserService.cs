using Data.Models;
using Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface ISysUserService : IBaseService<SysUserInfoEntity>
    {
        void Register(SysUserAuthEntity auth, SysUserInfoEntity info);
        void ChangePassword(int userId, string oldPwd, string newPwd);
    }
}
