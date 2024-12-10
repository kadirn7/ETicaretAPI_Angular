using ETicaretAPI.Persistence.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretDbContext> //Power shell ile migration oluşturmak gerekirse.
    {                                                                                        // dotnet ef migrations add mig_1 gibi 
        public ETicaretDbContext CreateDbContext(string[] args)
        {
            

            DbContextOptionsBuilder<ETicaretDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
