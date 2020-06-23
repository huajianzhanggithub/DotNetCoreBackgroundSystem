using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
