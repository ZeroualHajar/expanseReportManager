﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Models;
using ExpanseReportManager.Services;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Mapper
{
    public class PoleMapper
    {
        private EmployeeService EmployeeService;

        public PoleMapper()
        {
            this.EmployeeService = new EmployeeService();
        }

        public PoleViewModels DataToModel(Pole pole)
        {
            PoleViewModels result= new PoleViewModels();
            result.Id = pole.Pole_ID.ToString();
            result.Name = pole.Name;
            result.ManagerId = pole.Manager_ID.ToString();
            result.Manager = EmployeeService.GetById(result.ManagerId.ToString());

            return result;
        }

        public Pole ModelToData(Pole pole, PoleViewModels model)
        {
            pole.Name = model.Name;
            pole.Manager_ID = new Guid(model.ManagerId);
            return pole;
        }
    }
}

