using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Models;
using ExpanseReportManagerModel;
using ExpanseReportManager.Repositories;
using ExpanseReportManager.Mapper;

namespace ExpanseReportManager.Services
{
    public class UserService
    {
        private UserMapper Mapper;
        private UserRepository Repository;

        public UserService(NotesDeFraisEntities entities)
        {
            this.Mapper = new UserMapper();
            this.Repository = new UserRepository(entities);
        }

        public UserViewModels GetById(string id)
        {
            return Mapper.DataToModel(Repository.GetById(id));
        }

        public string GetEmployeeId(string userId)
        {
            return Repository.GetEmployeeId(userId);
        }
    }
}