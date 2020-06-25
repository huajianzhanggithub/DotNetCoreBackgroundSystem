﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure
{
    /// <summary>
    /// 用来确保一次请求一个工作流程,执行该方法的时候，一个完整的工作流程执行完成了。也就是说，当执行该方法后，当前请求不会再与数据库发生连接。
    /// </summary>
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
