using Data.Models;
using Service.Implements.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Repository;

namespace Service.Implements
{
    public class SysUserServiceImplement : BaseServiceImplement<SysUserInfoEntity>, ISysUserService
    {
        protected ISysUserAuthSearchRepository AuthRepository { get; }
        protected ISysUserInfoSearchRepository InfoRepository { get; }
        public SysUserServiceImplement(ISysUserAuthSearchRepository authRepository, ISysUserInfoSearchRepository infoRepository)
        {
            AuthRepository = authRepository;
            InfoRepository = infoRepository;
        }
        public void ChangePassword(int userId, string oldPwd, string newPwd)
        {
            throw new NotImplementedException();
        }

        public void Register(SysUserAuthEntity auth, SysUserInfoEntity info)
        {
            throw new NotImplementedException();
        }
    }
}
