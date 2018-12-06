using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Admin.Common.Domain;
using EVALUATION.CORE;
using EVALUATION.CORE.Dto;
using EVALUATION.DATA;
using EVALUATION.SERVICE.Manager;

namespace EVALUATION.SERVICE
{
    public class RoleClaimsTable
    {
        private DbManager _db;
        private AbpRoleClaimsManager _roleClaimsManager = null;

        /// <summary>
        /// Constructor that takes a DbManager instance 
        /// </summary>
        /// <param name="database"></param>
        public RoleClaimsTable(DbManager database)
        {
            _db = database;
            _roleClaimsManager = new AbpRoleClaimsManager();
        }

        /// <summary>
        /// Returns a ClaimsIdentity instance given a roleId
        /// </summary>
        /// <param name="roleId">The role's id</param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> FindByRoleId(int roleId)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            var item = new BusinessRequest<AbpRoleClaimsDto>
            {
                ItemToSearch = new AbpRoleClaimsDto
                {
                    RoleId = roleId
                }
            };

            var userClaims = await _roleClaimsManager.GetAbpRoleClaimsByCriteria(item);
            foreach (var c in userClaims.Items)
            {
                claimsIdentity.AddClaim(new Claim("P", c.ClaimValue));
            }
            return claimsIdentity;
        }

        /// <summary>
        /// Deletes all claims from a role given a roleId
        /// </summary>
        /// <param name="roleId">The role's id</param>
        /// <returns></returns>
        public async Task Delete(int roleId)
        {
            //var request = new BusinessRequest<ViewAbpUserPermissionsDto>();
            //request.IdCurrentUser = memberId;
            //request.ItemToSearch = new ViewAbpUserPermissionsDto() { IdUsers = memberId };
            //   await manager_claim.Delete(request);
            //db.Connection.Execute(@"Delete from MemberClaim where UserId = @memberId", new { memberId = memberId });
        }

        /// <summary>
        /// Inserts a new claim in RoleClaims table
        /// </summary>
        /// <param name="roleClaim">Role's claim to be added</param>
        /// <param name="roleId">Role's id</param>
        /// <returns></returns>
        public async Task Insert(Claim roleClaim, int roleId)
        {
            var request = new BusinessRequest<AbpRoleClaimsDto>
            {
                ItemsToSave = new List<AbpRoleClaimsDto>()
                {
                    new AbpRoleClaimsDto()
                    {
                        ClaimType = roleClaim.ValueType,
                        ClaimValue = roleClaim.Value,
                        RoleId = roleId
                    }
                }
            };

            //      await manager_claim.SaveAbpUserClaims(request);
            //db.Connection.Execute(@"Insert into MemberClaim (ClaimValue, ClaimType, MemberId) 
            //    values (@value, @type, @userId)", 
            //        new { 
            //            value=MemberClaim.Value,
            //            type=MemberClaim.Type,userId=memberId
            //            });
        }

        /// <summary>
        /// Deletes a claim from a role 
        /// </summary>
        /// <param name="role">The role to have a claim deleted</param>
        /// <param name="claim">A claim to be deleted from role</param>
        /// <returns></returns>
        public async Task Delete(IdentityRole role, Claim claim)
        {
            var request = new BusinessRequest<AbpRoleClaimsDto>();
            request.ItemToSearch = new AbpRoleClaimsDto()
            {
                RoleId = role.Id,
                //IdTenant = role.TenantId,
                ClaimValue = claim.Value,
                ClaimType = claim.ValueType
            };
            //    await manager_claim.DeleteAbpUserClaims(request);
            //db.Connection.Execute(@"Delete from MemberClaim 
            //where UserId = @memberId and @ClaimValue = @value and ClaimType = @type",
            //    new { 
            //        memberId = member.Id,
            //        ClaimValue=claim.Value,
            //        type=claim.Type 
            //    });
        }
    }
}
