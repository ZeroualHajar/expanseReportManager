using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Mapper;
using ExpanseReportManager.Repositories;

namespace ExpanseReportManager.Services
{
    public class RoleService
    {
        public RoleRepository Repository;
        public RoleMapper Mapper;

        public RoleService()
        {
            this.Repository = new RoleRepository();
            this.Mapper = new RoleMapper();
        }

        public List<AspNetRole> GetAll()
        {
            List<AspNetRole> result = new List<AspNetRole>();
            IQueryable<AspNetRoles> roles = Repository.GetAll();
            foreach (AspNetRoles role in roles)
            {
                result.Add(Mapper.DataToModel(role));
            }
            return result;
        }

        public AspNetRole GetById(Guid id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
        }

        public void Add(RoleViewModels model)
        {
            AspNetRole role = new AspNetRole();
            Repository.Add(Mapper.ModelToData(role, model));
            Repository.Save();
        }

        public void Delete(RoleViewModels model)
        {
            AspNetRole role = new AspNetRole();
            Repository.Delete(Mapper.ModelToData(role, model));
            Repository.Save();
        }



    }
}
