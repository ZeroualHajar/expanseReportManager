using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;
using ExpanseReportManager.Models;
using ExpanseReportManager.Repositories;
using ExpanseReportManager.Mapper;


namespace ExpanseReportManager.Services
{
    public class ProjectService
    {
        public ProjectRepository Repository;
        public ProjectMapper Mapper;

        public ProjectService(NotesDeFraisEntities entities)
        {
            this.Repository = new ProjectRepository(entities);
            this.Mapper = new ProjectMapper();
        }

        public ICollection<ProjectViewModels> GetAll()
        {
            return Mapper.AllToModel(Repository.GetAll());
        }

        public ICollection<ProjectViewModels> GetAllByPole(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(p => p.Pole_ID.ToString() == id));
        }

        public ICollection<ProjectViewModels> GetAllByCustomer(string id)
        {
            return Mapper.AllToModel(Repository.GetAll().Where(p => p.Customer_ID.ToString() == id));
        }

        public ProjectViewModels GetById(string id)
        {
            Project project = Repository.GetById(id);
            return project == null ? null : Mapper.DataToModel(project);
        }

        public void Add(ProjectViewModels client)
        {
            Project project = new Project();
            project.Project_ID = Guid.NewGuid();

            Repository.Add(Mapper.ModelToData(project, client));

            Repository.save();
        }

        public void Edit(ProjectViewModels project)
        {
            Project projet = Repository.GetById(project.Project_ID);
            Mapper.ModelToData(projet, project);
            Repository.save();
        }

        public void Delete(string id)
        {
            Repository.delete(id);
            Repository.save();

        }

        public ICollection<ProjectViewModels> Search(string query)
        {
            return Mapper.AllToModel(Repository.Search(query));
        }

    }
}


