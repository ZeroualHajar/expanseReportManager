using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Repositories;
using ExpanseReportManager.Models;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Mapper
{
    public class ProjectMapper
    {
        public ICollection<ProjectViewModels> AllToModel(IQueryable<Project> projects)
        {
            return projects.Select(project => new ProjectViewModels
            {
                Project_ID = project.Project_ID.ToString(),
                Name = project.Name,
                Description = project.Description,
                Budget = project.Budget,
                Customer_Id = project.Customer_ID.ToString(),
                Pole_Id = project.Pole_ID.ToString()
            }).ToList();
        }

        public ProjectViewModels DataToModel(Project project)
        {
            return new ProjectViewModels
            {
                Project_ID = project.Project_ID.ToString(),
                Name = project.Name,
                Description = project.Description,
                Budget = project.Budget,
                Customer_Id = project.Customer_ID.ToString(),
                Pole_Id = project.Pole_ID.ToString()
            };
        }

        public Project ModelToData(Project project, ProjectViewModels model)
        {
            project.Name = model.Name;
            project.Description =  model.Description;
            project.Budget = model.Budget;
            project.Customer_ID = new Guid(model.Customer_Id);
            project.Pole_ID = new Guid(model.Pole_Id);

            return project;
        }

    }
}