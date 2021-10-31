using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBL
{
    public class TestContext : DbContext
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=123";
        public TestContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) =>
            dbContextOptionsBuilder.UseNpgsql(ConnectionString);

        public DbSet<Report> Reports { get;set; }



    }
}
