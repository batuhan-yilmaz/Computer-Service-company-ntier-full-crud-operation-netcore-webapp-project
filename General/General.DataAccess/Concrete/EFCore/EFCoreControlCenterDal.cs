using General.DataAccess.Abstrack;
using General.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Concrete.EFCore
{
    public class EFCoreControlCenterDal : EFCoreGenericRepository<ControlCenter, Context>, IControlCenterDal
    {


        public List<CompanyService> GetServicesAll()
        {
            using (var context = new Context())
            {
                List<CompanyService> CompanyService = null;
                CompanyService = context.CompanyService.ToList();
                return CompanyService;

            }
        }
        public ControlCenter GetDefault()
        {
            using (var context = new Context())
            {
                return context.ControlCenters
                .Include(i => i.CompanyServices)
                .Where(i => i.ControlcenterKey == "EW0p2PLcxhAzpq3j").
                FirstOrDefault();
            }
        }


        public CompanyService GetCompanyServicesById(int id)
        {
            using (var context = new Context())
            {
                return context.CompanyService
                    .Where(i => i.Id == id)
                    .FirstOrDefault();
            }
        }


        public void Create(CompanyService entity)
        {
            using (var context = new Context())
            {
                context.CompanyService.Add(entity);
                context.SaveChanges();
            }
        }
        public void Update(CompanyService entity)
        {
            using (var context = new Context())
            {
                context.CompanyService.Update(entity);
                context.SaveChanges();
            }
        }

 
        public void Delete(CompanyService entity)
        {
            using (var context = new Context())
            {
                context.CompanyService.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
