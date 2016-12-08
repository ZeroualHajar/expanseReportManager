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

        public ProjectService()
        {
            this.Repository = new ProjectRepository(new NotesDeFraisEntities() );
            this.Mapper = new ProjectMapper();
        }

        public ICollection<ProjectViewModels> GetAll()
        {
            ICollection<ProjectViewModels> result = new List<ProjectViewModels>();
            IQueryable<Project> liste = Repository.GetAll();
            foreach (Project p in liste)
            {
                result.Add(Mapper.DataToModel(p));
            }
            return result;
        }

        public ProjectViewModels GetById(string id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
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

        public List<ProjectViewModels> Search(string query)
        {
            List<ProjectViewModels> result = new List<ProjectViewModels>();

            IQueryable<Project> projets = Repository.Search(query);
            foreach (Project res in projets)
            {
                result.Add(Mapper.DataToModel(res));
            }

            return result;
        }

    }
}


