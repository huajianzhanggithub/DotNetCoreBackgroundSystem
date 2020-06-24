using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure
{
    /// <summary>
    /// 用来确保一次请求一个工作流程
    /// </summary>
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
