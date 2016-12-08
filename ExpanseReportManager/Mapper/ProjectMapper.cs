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
        public ProjectRepository Repository;

        public ProjectMapper()
        {
            this.Repository = new ProjectRepository(new NotesDeFraisEntities());
        }

        public ProjectViewModels DataToModel(Project project)
        {
            ProjectViewModels model = new ProjectViewModels();

            model.Project_ID = project.Project_ID.ToString();
            model.Name = project.Name;
            model.Description = project.Description;
            model.Budget = project.Budget;
            model.Customer_Id = project.Customer_ID.ToString();
            model.Pole_Id = project.Pole_ID.ToString();

            return model;
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