using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testMiddelware
{
    public class DataBase : DbContext
    {

        public DbSet<ClassTest> Classes { get; set; }

        public DataBase(DbContextOptions<DataBase> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ClassTest>(testc =>
            {
                testc.HasKey(x => x.Name);
                testc.Property(x => x.Name);
            });
        }
    }
}
