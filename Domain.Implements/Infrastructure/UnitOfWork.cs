using Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Implements.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext DbContext;
        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
