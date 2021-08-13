using General.Business.Abstrack;
using General.DataAccess.Abstrack;
using General.DataAccess.Concrete.EFCore;
using General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Concrete
{
    public class ControlCenterManager : IControlCenterService
    {

        private IControlCenterDal _controlCenterDal;

        public ControlCenterManager(IControlCenterDal controlCenterDal)
        {
            _controlCenterDal = controlCenterDal;
        }

        public void Create(ControlCenter entity)
        {
            _controlCenterDal.Create(entity);
        }

        public void Create(CompanyService entity)
        {
            _controlCenterDal.Create(entity);
        }

        public void Delete(ControlCenter entity)
        {
            _controlCenterDal.Delete(entity);
        }

        public List<ControlCenter> GetAll()
        {
            return _controlCenterDal.GetAll().ToList();
        }

        public ControlCenter GetById(int id)
        {
            return _controlCenterDal.GetById(id);
        }

        public List<CompanyService> GetServicesAll()
        {
            return _controlCenterDal.GetServicesAll();
        }

        public void Update(ControlCenter entity)
        {
            _controlCenterDal.Update(entity);
        }
        public ControlCenter GetDefault()
        {
            return _controlCenterDal.GetDefault();
        }

        public CompanyService GetCompanyServicesById(int id)
        {
            return _controlCenterDal.GetCompanyServicesById(id);
        }

        public void Update(CompanyService entity)
        {
            _controlCenterDal.Update(entity);
        }

        public void Delete(CompanyService entity)
        {
            _controlCenterDal.Delete(entity);
        }
    }
}
