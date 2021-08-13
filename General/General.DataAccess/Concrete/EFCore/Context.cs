using General.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Concrete.EFCore
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GeneralDb;integrated security=true;MultipleActiveResultSets=true;");
            //optionsBuilder.UseSqlServer(@"Data Source=mssql13.trwww.com;Initial Catalog=gorillas_gorillastclothing;User Id=admin_gorillast;Password=Hy388?rc");

        }
        public DbSet<ControlCenter> ControlCenters { get; set; }
        public virtual DbSet<CompanyService> CompanyService { get; set; }

    }
}
