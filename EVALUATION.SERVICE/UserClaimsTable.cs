using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Linq;
using EVALUATION.DATA;
using EVALUATION.CORE;
using EVALUATION.SERVICE.Manager;
using Admin.Common.Domain;
using EVALUATION.CORE.Dto;
using System.Threading.Tasks;

namespace EVALUATION.SERVICE
{
    /// <summary>
    /// Class that represents the UserClaims table in the Database
    /// </summary>
    public class UserClaimsTable
    {
        private DbManager db;
        private AbpUserClaimsManager manager_claim = null;
        //   private AbpUserClaimsManagerManager manager_claim = new ViewAbpUserPermissionsManager();

        /// <summary>
        /// Constructor that takes a DbManager instance 
        /// </summary>
        /// <param name="database"></param>
        public UserClaimsTable(DbManager database)
        {
            db = database;
            manager_claim = new AbpUserClaimsManager();
        }

        /// <summary>
        /// Returns a ClaimsIdentity instance given a userId
        /// </summary>
        /// <param name="memberId">The user's id</param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> FindByUserId(int memberId)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            var item = new BusinessRequest<AbpUserClaimsDto>();
            item.IdCurrentUser = memberId;
            item.ItemToSearch = new AbpUserClaimsDto() { UserId = memberId };
            var userClaims = await manager_claim.GetAbpUserClaimsByCriteria(item);
            foreach (var c in userClaims.Items)
            {
                claimsIdentity.AddClaim(new Claim("P", c.ClaimValue));
            }
            return claimsIdentity;
        }

        /// <summary>
        /// Deletes all claims from a user given a userId
        /// </summary>
        /// <param name="memberId">The user's id</param>
        /// <returns></returns>
        public async Task Delete(int memberId)
        {
            //var request = new BusinessRequest<ViewAbpUserPermissionsDto>();
            //request.IdCurrentUser = memberId;
            //request.ItemToSearch = new ViewAbpUserPermissionsDto() { IdUsers = memberId };
         //   await manager_claim.Delete(request);
            //db.Connection.Execute(@"Delete from MemberClaim where UserId = @memberId", new { memberId = memberId });
        }

        /// <summary>
        /// Inserts a new claim in UserClaims table
        /// </summary>
        /// <param name="memberClaim">User's claim to be added</param>
        /// <param name="memberId">User's id</param>
        /// <returns></returns>
        public async Task Insert(Claim memberClaim, int memberId)
        {
            var request = new BusinessRequest<AbpUserClaimsDto>();
            
            request.ItemsToSave = new List<AbpUserClaimsDto>() { new AbpUserClaimsDto()
            {
                 ClaimType = memberClaim.ValueType, ClaimValue = memberClaim.Value, UserId =memberId
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
        /// Deletes a claim from a user 
        /// </summary>
        /// <param name="member">The user to have a claim deleted</param>
        /// <param name="claim">A claim to be deleted from user</param>
        /// <returns></returns>
        public async Task Delete(IdentityMember member, Claim claim)
        {
            var request = new BusinessRequest<AbpUserClaimsDto>();
            request.ItemToSearch = new AbpUserClaimsDto()
            {
                UserId = member.Id,
                IdTenant = member.TenantId,
                ClaimValue =claim.Value,
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
