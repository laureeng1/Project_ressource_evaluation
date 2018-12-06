using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using EVALUATION.DATA;
using EVALUATION.CORE;
using EVALUATION.SERVICE.Manager;
using EVALUATION.CORE.Dto;
using Admin.Common.Domain;
using System.Threading.Tasks;

namespace EVALUATION.SERVICE
{
    /// <summary>
    /// Class that represents the UserLogins table in the Database
    /// </summary>
    public class UserLoginsTable
    {
        private DbManager db;
        private AbpUserLoginsManager manager_userlogin = new AbpUserLoginsManager();
        /// <summary>
        /// Constructor that takes a DbManager instance 
        /// </summary>
        /// <param name="database"></param>
        public UserLoginsTable(DbManager database)
        {
            db = database;
        }

        /// <summary>
        /// Deletes a login from a user in the UserLogins table
        /// </summary>
        /// <param name="user">User to have login deleted</param>
        /// <param name="login">Login to be deleted from user</param>
        /// <returns></returns>
        public async Task Delete(IdentityMember member, UserLoginInfo login)
        {
            var request = new BusinessRequest<AbpUserLoginsDto>();
            request.ItemToSearch = new AbpUserLoginsDto() { IdUtilisateur=member.Id, IdTenant = member.TenantId, LoginProvider = login.LoginProvider, ProviderKey = login.ProviderKey  };
            await manager_userlogin.DeleteAbpUserLogins(request);
            //db.Connection.Execute(@"Delete from MemberLogin 
            //        where UserId = @userId 
            //        and LoginProvider = @loginProvider 
            //        and ProviderKey = @providerKey",
            //    new 
            //    {   
            //        userId=member.Id,
            //        loginProvider=login.LoginProvider,
            //        providerKey=login.ProviderKey
            //    });
        }

        /// <summary>
        /// Deletes all Logins from a user in the UserLogins table
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public async Task  Delete(string userId)
        {
            await new AbpUserLoginsManager().DeleteAbpUserLogins(new BusinessRequest<AbpUserLoginsDto>()
            {
                ItemToSearch = new AbpUserLoginsDto()
                {
                    IdUtilisateur = Int32.Parse(userId)
                }
            });
 
        }

        /// <summary>
        /// Inserts a new login in the UserLogins table
        /// </summary>
        /// <param name="user">User to have new login added</param>
        /// <param name="login">Login to be added</param>
        /// <returns></returns>
        public async Task Insert(IdentityMember member, UserLoginInfo login)
        {
            var request = new BusinessRequest<AbpUserLoginsDto>();
            request.ItemsToSave = new List<AbpUserLoginsDto>() {
                new AbpUserLoginsDto()
                {
                    IdUtilisateur = member.Id, IdTenant = member.Id, LoginProvider = login.LoginProvider,
                    ProviderKey = login.ProviderKey, DateCreation = DateTime.UtcNow, IsNewItem = true
                }

            };
            await manager_userlogin.SaveAbpUserLogins(request);
        }

        /// <summary>
        /// Return a userId given a user's login
        /// </summary>
        /// <param name="MemberLogin">The user's login info</param>
        /// <returns></returns>
        public async Task<int> FindUserIdByLogin(UserLoginInfo MemberLogin)
        {
            var request = new BusinessRequest<AbpUserLoginsDto>();
            request.ItemToSearch = new AbpUserLoginsDto() { LoginProvider= MemberLogin.LoginProvider, ProviderKey=MemberLogin.ProviderKey};

            var result = await manager_userlogin.GetAbpUserLoginsByCriteria(request);
            return (Int32)result.Items[0].IdUtilisateur;

            //return db.Connection.ExecuteScalar<int>(@"Select UserId from MemberLogin 
            ////    where LoginProvider = @loginProvider and ProviderKey = @providerKey",
            ////            new 
            ////            {   
            ////                loginProvider = MemberLogin.LoginProvider,
            ////                providerKey=MemberLogin.ProviderKey
            ////            });
        }

        /// <summary>
        /// Returns a list of user's logins
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public  async Task<List<UserLoginInfo>> FindByUserId(int memberId)
        {
            var userlogins = await manager_userlogin.GetAbpUserLoginsByCriteria(new BusinessRequest<AbpUserLoginsDto>() { ItemToSearch = new AbpUserLoginsDto() { IdUtilisateur = memberId }  });
            var userLoginInfos = new List<UserLoginInfo>();
            foreach (var item in userlogins.Items)
            {
                UserLoginInfo ul = new UserLoginInfo(item.LoginProvider, item.ProviderKey);
                userLoginInfos.Add(ul);
            }
            return userLoginInfos;
        }

    }
}
