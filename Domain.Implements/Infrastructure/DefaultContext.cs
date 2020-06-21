using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Domain.Implements.Infrastructure
{
    public class DefaultContext : DbContext
    {
        private string ConnectStr { get; }
        public DefaultContext(string connectStr)
        {
            ConnectStr = connectStr;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(ConnectStr); // 如果需要别的数据库，在这里进行修改
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.GetInterfaces().Any(i=>t.Name.Contains("IEntityTypeConfiguration")));
        }
    }
}