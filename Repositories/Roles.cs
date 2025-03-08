using MedApp_Api.DatabaseModels;
using MedApp_Api.Intefaces;
using MedApp_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedApp_Api.Repositories
{
    public class Roles : IRoles
    {
        private readonly DatabaseContext database;

        public Roles(DatabaseContext _database) => database = _database;

        public async Task<ResponseModel> AddRole(Role role)
        {
            try
            {
                if (await database.Roles.AnyAsync(
                    x =>
                    x.RoleId.Equals(role.RoleId)
                ))
                {
                    return new()
                    {
                        Success = false,
                        Handled = true,
                        Message = "Role does exist"
                    };
                }

                await database.Roles.AddAsync(role);
                await database.SaveChangesAsync();

                return new()
                {
                    Success = true,
                    Message = "Role created successfully"
                };
            }
            catch (Exception ex)
            {

                return new()
                {
                    Success = false,
                    Handled = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<ResponseModel> Delete(string roleId)
        {
            try
            {
                if (!await database.Roles.AnyAsync(
                   x =>
                   x.RoleId.Equals(roleId)
               ))
                {
                    return new()
                    {
                        Success = false,
                        Handled = true,
                        Message = "Role doesn't exist"
                    };
                }

                var role = await database.Roles.FirstOrDefaultAsync
                (
                    x =>
                    x.RoleId.Equals(roleId)
                );
                 database.Roles.Remove(role!);
                 await database.SaveChangesAsync();
                 return new()
                {
                    Success = true,
                    Message = "Role deleted successfully"
                };

            }
            catch (Exception ex)
            {

                return new()
                {
                    Success = false,
                    Handled = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<ResponseModel> GetById(string roleId)
        {
            try
            {
                var role = await database.Roles.FirstOrDefaultAsync
                (
                    x =>
                    x.RoleId.Equals(roleId)
                );

                if(role==null)
                {
                    return new()
                    {
                        Success = false,
                        Handled = false,
                        Message = "Role doesn't exist",
                    };
                }

                return new()
                {
                    Success = true,
                    Message = "Role retrieved successfully",
                    Data = role
                };

            }
            catch (Exception ex)
            {

                return new()
                {
                    Success = false,
                    Handled = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseModel> GetRoles()
        {
            try
            {
                var roles = await database.Roles.ToArrayAsync();
                return new()
                {
                    Success = true,
                    Message = "Roles retrieved successfully",
                    Data = roles
                };
            }
            catch (Exception ex)
            {

                return new()
                {
                    Success = false,
                    Handled = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseModel> UpdateRole(Role role)
        {
            try
            {
                if (!await database.Roles.AnyAsync(
                   x =>
                   x.RoleId.Equals(role.RoleId)
               ))
                {
                    return new()
                    {
                        Success = false,
                        Handled = true,
                        Message = "Role doesn't exist"
                    };
                }

                database.Roles.Update(role);
                await database.SaveChangesAsync();
                return new()
                {
                    Success = true,
                    Message = "Role updated successfully"
                };
            }
            catch (Exception ex)
            {

                return new()
                {
                    Success = false,
                    Handled = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }
    }
}
