using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Enums
{
    /// <summary>
    /// 登陆类型
    /// </summary>
    public enum LoginType : byte
    {
        /// <summary>
        /// token登录
        /// </summary>
        Token,
        /// <summary>
        /// 用户名密码
        /// </summary>
        Password
    }
    public enum SexEnum
    {
        /// <summary>
        /// 男
        /// </summary>
        Male,
        /// <summary>
        /// 女
        /// </summary>
        Female,
        /// <summary>
        /// 隐私
        /// </summary>
        None
    }
}
