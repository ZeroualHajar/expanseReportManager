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
        public RoleViewModels DataToModel(AspNetRole role)
        {
            RoleViewModels result = new RoleViewModels()
            {
                Id = role.Id,
                Name = role.Name
            };

            return result;
        }

        public AspNetRole ModelToData(AspNetRole role, RoleViewModels model)
        {
            role.Name = model.Name;

            return role;
        }
    }
}
