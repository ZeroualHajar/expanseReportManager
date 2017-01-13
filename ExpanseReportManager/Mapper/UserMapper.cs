using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpanseReportManager.Models;
using ExpanseReportManagerModel;

namespace ExpanseReportManager.Mapper
{
    public class UserMapper
    {

        public ICollection<UserViewModels> AllToModel(IQueryable<AspNetUser> users)
        {
            return users.Select(user => new UserViewModels
            {
                Id = user.Id,
                AccessFailedCount = user.AccessFailedCount,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                UserName = user.UserName
            }).ToList();
        }

        public UserViewModels DataToModel(AspNetUser user)
        {
            return new UserViewModels
            {
                Id = user.Id,
                AccessFailedCount = user.AccessFailedCount,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                UserName = user.UserName
            };
        }

        public AspNetUser ModelToData(AspNetUser user, UserViewModels model)
        {
            user.AccessFailedCount = model.AccessFailedCount;
            user.Email = model.Email;
            user.EmailConfirmed = model.EmailConfirmed;
            user.PhoneNumber = model.PhoneNumber;
            user.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            user.UserName = user.UserName;

            return user;

        }
    }
}