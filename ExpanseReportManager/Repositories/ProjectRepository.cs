using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Repositories
{
    public class ProjectRepository
    {
        public NotesDeFraisEntities Entities;

        public ProjectRepository(NotesDeFraisEntities entities)
        {
            this.Entities = entities;
        }

        public IQueryable<Project> GetAll()
        {
           return Entities.Projects;
        }

        public Project GetById(string id)
        {
            return Entities.Projects.FirstOrDefault(p => p.Project_ID.ToString() == id);
        }

        public void Add(Project project)
        {
           Entities.Projects.Add(project);
        }

        public IQueryable<Project> Search(string query)
        {
            return Entities.Projects.Where(p => p.Name.ToUpper().Contains(query.ToUpper()));
        }

        public void delete(string id)
        {
            Entities.Projects.Remove(GetById(id));
             
        }

        public void save()
        {
            Entities.SaveChanges();
        }
    }
}