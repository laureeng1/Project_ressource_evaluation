using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Linq;
using EVALUATION.CORE;
using EVALUATION.CORE.Dto;
using EVALUATION.DATA;
using EVALUATION.SERVICE.Manager;
using Admin.Common.Domain;
using System.Threading.Tasks;


namespace EVALUATION.SERVICE
{
    /// <summary>
    /// Class that represents the Role table in the Database
    /// </summary>
    public class RoleTable
    {

        private DbManager db;
        private AbpRolesManager manager_role = new AbpRolesManager();
        private readonly BusinessRequest<AbpRolesDto> request = new BusinessRequest<AbpRolesDto>();

        /// <summary>
        /// Constructor that takes a DbManager instance 
        /// </summary>
        /// <param name="database"></param>
        public RoleTable(DbManager database)
        {
            db = database;
        }

        /// <summary>
        /// Deltes a role from the Roles table
        /// </summary>
        /// <param name="roleId">The role Id</param>
        /// <returns></returns>
        public  async Task Delete(int roleId)
        {
            var request = new BusinessRequest<AbpRolesDto>() { ItemToSearch = new AbpRolesDto() { RoleId= roleId } };
            await manager_role.DeleteAbpRoles(request);
            //db.Connection.Execute(@"Delete from Role where Id = @id", new { id = roleId });

        }

        /// <summary>
        /// Inserts a new Role in the Roles table
        /// </summary>
        /// <param name="roleName">The role's name</param>
        /// <returns></returns>
        public async Task Insert(IdentityRole role)
        {
            request.ItemsToSave = new List<AbpRolesDto>()
            {
                new AbpRolesDto()
                {
                    Name =  role.Name,
                    DisplayName = role.Name,
                    IsDefault = false,
                    IsStatic = false           
                }
            };
            request.IdCurrentUser = 9;

            await manager_role.SaveAbpRoles(request);
        }

        /// <summary>
        /// Returns a role name given the roleId
        /// </summary>
        /// <param name="roleId">The role Id</param>
        /// <returns>Role name</returns>
        public async Task<string> GetRoleName(int roleId)
        {
            var role= await manager_role.GetAbpRolesById(roleId);
            return role.Items[0].Name;

        }

        /// <summary>
        /// Returns the role Id given a role name
        /// </summary>
        /// <param name="roleName">Role's name</param>
        /// <returns>Role's Id</returns>
        public async Task<int> GetRoleId(string roleName)
        {
            var request = new BusinessRequest<AbpRolesDto>() { ItemToSearch = new AbpRolesDto() { Name = roleName } };
            var role = await manager_role.GetAbpRolesByCriteria(request);
            return role.Items[0].RoleId;

        }

        /// <summary>
        /// Gets the IdentityRole given the role Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<IdentityRole> GetRoleById(int roleId)
        {
            var response = await manager_role.GetAbpRolesById(roleId);
            var _role = response.Items.FirstOrDefault();
            IdentityRole role = null;

            if (_role != null)
            {
                role = new IdentityRole(_role.Name, roleId);
            }

            return role;
        }

        /// <summary>
        /// Gets the IdentityRole given the role name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public async Task<IdentityRole> GetRoleByName(string roleName)
        {
            var response = await manager_role.GetAbpRolesByCriteria(new BusinessRequest<AbpRolesDto>() { ItemToSearch = new AbpRolesDto() { Name = roleName } });
            IdentityRole role = null;

            if (response.Items.Count > 0)
            {
                role = new IdentityRole(roleName, response.Items[0].RoleId);
            }

            return role;
        }

        public async Task Update(IdentityRole role)
        {
            var request = new BusinessRequest<AbpRolesDto>() { ItemToSearch = new AbpRolesDto() { Name = role.Name } };
            await manager_role.SaveAbpRoles(request);
     
        }
    }
}
