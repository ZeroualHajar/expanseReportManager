using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Models;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Mapper
{
    public class RoleMapper
    {
        public ICollection<RoleViewModels> AllToModel(IQueryable<AspNetRole> roles)
        {
            return roles.Select(role => new RoleViewModels
            {
                Id = role.Id,
                Name = role.Name
            }).ToList();
        }

        public RoleViewModels DataToModel(AspNetRole role)
        {
            return new RoleViewModels
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public AspNetRole ModelToData(AspNetRole role, RoleViewModels model)
        {
            role.Name = model.Name;

            return role;
        }
    }
}
