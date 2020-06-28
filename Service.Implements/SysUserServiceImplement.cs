using Data.Models;
using Service.Implements.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Repository;
using Domain.Implements.Infrastructure;
using Utils;
using Domain.Implements.Repository;

namespace Service.Implements
{
    public class SysUserServiceImplement : BaseServiceImplement<SysUserInfoEntity>, ISysUserService
    {
        protected SysUserAuthRepository AuthRepository { get; }
        protected SysUserInfoRepository InfoRepository { get; }
        public SysUserServiceImplement(SysUserAuthRepository authRepository, SysUserInfoRepository infoRepository):base(infoRepository)
        {
            AuthRepository = authRepository;
            InfoRepository = infoRepository;
        }
        public void ChangePassword(int userId, string oldPwd, string newPwd)
        {
            var info = InfoRepository.Get(userId);
            var auth = AuthRepository.Get(info.SysUserAuthId);
            if (oldPwd==null || oldPwd!=auth?.Password)
            {
                throw new Exception("原密码错误！");
            }
            auth.Password = newPwd;
        }

        public void Register(SysUserAuthEntity auth, SysUserInfoEntity info)
        {
            var authItem = AuthRepository.Get(p => p.LoginType == auth.LoginType && p.UserName == auth.UserName);
            if (authItem!=null)
            {
                throw new Exception("用户信息已经存在！");
            }
            info.SysUserAuth = auth;
            InfoRepository.Insert(info);
        }
    }
}
