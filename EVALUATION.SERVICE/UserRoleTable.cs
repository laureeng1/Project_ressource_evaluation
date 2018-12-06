using Admin.Common.Domain;
using EVALUATION.CORE;
using EVALUATION.CORE.Dto;
using EVALUATION.DATA;
using EVALUATION.SERVICE.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EVALUATION.SERVICE
{
    /// <summary>
    /// Class that represents the UserRoles table in the Database
    /// </summary>
    public class UserRolesTable
    {
        private DbManager db;
        private AbpUserRolesManager manager_userRole = new AbpUserRolesManager();
        private AbpRolesManager manager_role = new AbpRolesManager();
        /// <summary>
        /// Constructor that takes a DbManager instance 
        /// </summary>
        /// <param name="database"></param>
        public UserRolesTable(DbManager database)
        {
            db = database;
        }

        /// <summary>
        /// Returns a list of user's roles
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public async Task<List<string>> FindByUserId(int memberId)
        {
         

            var userRoles =  await manager_userRole.GetAbpUserRolesByCriteria((new BusinessRequest<AbpUserRolesDto>()
            {
                IdCurrentUser = memberId
            }));
            var roles = new List<string>();
            foreach(var r in userRoles.Items)
            {
                var result = await manager_role.GetAbpRolesById(r.RoleId);
                string roleName = result.Items[0].Name;
                roles.Add(roleName);
            }
            return roles;
            //return db.Connection.Query<string>("Select Role.Name from MemberRole, Role where MemberRole.MemberId=@MemberId and MemberRole.RoleId = Role.Id", new{MemberId=memberId} )
            //    .ToList();
        }

        /// <summary>
        /// Deletes all roles from a user in the UserRoles table
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public async Task Delete(int memberId)
        {
            var request = new BusinessRequest<AbpUserRolesDto>() { IdCurrentUser = memberId };
            await manager_userRole.DeleteAbpUserRoles(request);
            //db.Connection.Execute(@"Delete from MemberRole where Id = @MemberId", new { MemberId = memberId });
        }

        /// <summary>
        /// Inserts a new role for a user in the UserRoles table
        /// </summary>
        /// <param name="user">The User</param>
        /// <param name="roleId">The Role's id</param>
        /// <returns></returns>
        public async Task Insert(IdentityMember member, int roleId)
        {
            var userRole = new BusinessRequest<AbpUserRolesDto>();
            userRole.ItemsToSave.Add(new AbpUserRolesDto()
            {
                UserId = member.Id,
                IdTenant = member.TenantId,
                RoleId = roleId,
                CreationTime = DateTime.UtcNow 
            });
            await manager_userRole.SaveAbpUserRoles(userRole);
            //db.Connection.Execute(@"Insert into AspNetUserRoles (UserId, RoleId) values (@userId, @roleId",
            //    new { userId = member.Id, roleId = roleId });
        }
    }
}
