using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedApp_Api.DatabaseModels;
using MedApp_Api.Models;

namespace MedApp_Api.Intefaces
{
    public interface IRoles
    {
        public Task<ResponseModel> GetRoles();
        public Task<ResponseModel> GetById(string roleId);
        public Task<ResponseModel> AddRole(Role role);
        public Task<ResponseModel> UpdateRole(Role role);
        public Task<ResponseModel> Delete(string roleId);
    }
}