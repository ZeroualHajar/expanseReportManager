using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Mapper;
using ExpanseReportManager.Repositories;
using ExpanseReportManagerModel;
using ExpanseReportManager.Models;

namespace ExpanseReportManager.Services
{
    public class RoleService
    {
        public RoleRepository Repository;
        public RoleMapper Mapper;

        public RoleService()
        {
            this.Repository = new RoleRepository(new NotesDeFraisEntities());
            this.Mapper = new RoleMapper();
        }

        public ICollection<RoleViewModels> GetAll()
        {
            ICollection<RoleViewModels> result = new List<RoleViewModels>();

            IQueryable<AspNetRole> roles = Repository.GetAll();

            foreach (AspNetRole role in roles)
            {
                result.Add(Mapper.DataToModel(role));
            }

            return result;
        }

        public RoleViewModels GetById(string id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
        }

        public void Add(RoleViewModels model)
        {
            AspNetRole role = new AspNetRole();
            role = Mapper.ModelToData(role, model);
            role.Id = Guid.NewGuid().ToString();

            Repository.Add(role);
            Repository.Save();
        }

        public void Delete(string id)
        {
            Repository.Delete(id);
            Repository.Save();
        }

        public void Edit(RoleViewModels model)
        {
            AspNetRole role = Repository.GetById(model.Id);
            role = Mapper.ModelToData(role, model);
            Repository.Save();
        } 

    }
}