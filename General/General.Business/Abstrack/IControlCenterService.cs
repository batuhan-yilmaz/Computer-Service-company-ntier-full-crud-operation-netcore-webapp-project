using General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Abstrack
{
    public interface IControlCenterService
    {
        ControlCenter GetDefault();
        ControlCenter GetById(int id);
        CompanyService GetCompanyServicesById(int id);
        List<ControlCenter> GetAll();
        void Create(ControlCenter entity);
        void Update(ControlCenter entity);
        void Delete(ControlCenter entity);
        List<CompanyService> GetServicesAll();
        void Create(CompanyService entity);
        void Update(CompanyService entity);
        void Delete(CompanyService entity);
    }
}
