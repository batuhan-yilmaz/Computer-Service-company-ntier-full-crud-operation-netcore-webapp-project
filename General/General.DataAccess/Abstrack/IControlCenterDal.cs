using General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Abstrack
{
    public interface IControlCenterDal : IRepository<ControlCenter>
    {
        List<CompanyService> GetServicesAll();
        ControlCenter GetDefault();
        CompanyService GetCompanyServicesById(int id);
        void Create(CompanyService entity);
        void Update(CompanyService entity);
        void Delete(CompanyService entity);
    }
}
