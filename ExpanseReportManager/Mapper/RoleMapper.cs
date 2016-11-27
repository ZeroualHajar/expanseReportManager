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

        public RoleMapper()
        {

        }

        public RoleViewModels DataToModel(AspNetRole role)
        {
            RoleViewModels result = new RoleViewModels()
            {
                Id = role.Id,
                Name = role.Name,
                //Employees = 

            };

            return result;
        }

        public AspNetRole ModelToData(AspNetRole role, RoleViewModels model)
        {
            //pole.Pole_ID = model.Id;
            //pole.Name = model.Name;
            //pole.Manager_ID = model.ManagerId;
            return pole;
        }
    }
}
