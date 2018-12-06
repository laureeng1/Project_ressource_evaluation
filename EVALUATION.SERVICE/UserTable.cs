using Admin.Common.Domain;
using Admin.Common.Enum;
using EVALUATION.CORE;
using EVALUATION.CORE.Dto;
using EVALUATION.DATA;
using EVALUATION.SERVICE.Manager;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;

namespace EVALUATION.SERVICE
{
    /// <summary>
    /// Class that represents the Users table in the Database
    /// </summary>
    public class UserTable<TUser> where TUser : IdentityMember,new()
    {
        private DbManager db;
        private AbpUsersManager managerU = new AbpUsersManager();
        private readonly BusinessRequest<AbpUsersDto> request = new BusinessRequest<AbpUsersDto>();
        
        /// <summary>
        /// Constructor that takes a DbManager instance 
        /// </summary>
        /// <param name="database"></param>
        public UserTable(DbManager database)
        {
            db = database;
        }

        /// <summary>
        /// Returns the Member's name given a Member id
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public string GetUserName(string memberId)
        {
            var response = managerU.GetAbpUsersById(memberId);
            if (response == null)
            {
                throw new Exception("L'utilisateur n'a pas été trouvé");
            }
            return response.Result.Items[0].UserName;


        }

        /// <summary>
        /// Returns a Member ID given a Member name
        /// </summary>
        /// <param name="userName">The Member's name</param>
        /// <returns></returns>
        public async Task<string> GetmemberId(string userName)
        {

            var response = await managerU.GetAbpUsersById(userName);
            return Convert.ToString(response.Items[0].Id.ToString());
        }

        /// <summary>
        /// Returns an TUser given the Member's id
        /// </summary>
        /// <param name="memberId">The Member's id</param>
        /// <returns></returns>
        public async Task<TUser> GetUserById(int memberId)
        {

            var response = await managerU.GetAbpUsersById(memberId);
            if (response.Items.Count > 0)
            {
                var item = response.Items.FirstOrDefault();

                return new TUser()
                {
                    Id = (int)item.Id,
                    UserName = item.UserName,
                    AccessFailedCount = item.AccessFailedCount??0,
                    Nom = item.Nom,
                    Prenoms = item.Prenoms,
                    Email = item.Email,
                    IsEmailConfirmed = item.IsEmailConfirmed ?? false,
                    IsLockoutEnabled = item.IsLockoutEnabled ?? false,
                    LockoutEndDateUtc = item.LockoutEndDateUtc,
                    PasswordHash = item.Password,
                    PhoneNumber = item.PhoneNumber,
                    IsPhoneNumberConfirmed = item.IsPhoneNumberConfirmed ?? false,
                    SecurityStamp = item.SecurityStamp,
                    //TenantId = (int)item.IdTenant,
                    IsTwoFactorEnabled = item.IsTwoFactorEnabled ?? false
                };
             };
            return new TUser();

        }

        /// <summary>
        /// Returns a list of TUser instances given a Member name
        /// </summary>
        /// <param name="userName">Member's name</param>
        /// <returns></returns>
        public async Task<TUser> GetUserByName(string userName)
        {       
            var response =
                await managerU.GetAbpUsersByCriteria(
                    new BusinessRequest<AbpUsersDto>() {
                        ItemToSearch = new AbpUsersDto() {
                            UserName = userName,
                            InfoSearchUserName =
                            {
                                Consider = true,
                                OperatorToUse = OperatorEnum.EQUAL
                            }   
                        }
                    });

            if (response.Items.Count > 0)
            {
                var item = response.Items.FirstOrDefault();
                var identityMember = new TUser()
                    {
                        Id = (int)item.Id,
                        UserName = item.UserName,
                        Nom = item.Nom,
                        Prenoms = item.Prenoms,
                        AccessFailedCount = item.AccessFailedCount??0,
                        Email = item.Email,
                        IsEmailConfirmed = item.IsEmailConfirmed??false,
                        IsLockoutEnabled = item.IsLockoutEnabled ?? false,
                        LockoutEndDateUtc = item.LockoutEndDateUtc,
                    DateDebutValidite = item.DateDebutValidite,
                    DateFinValidite = item.DateFinValidite,
                    PasswordHash = item.Password,
                        PhoneNumber = item.PhoneNumber,
                        IsPhoneNumberConfirmed = item.IsPhoneNumberConfirmed ?? false,
                        SecurityStamp = item.SecurityStamp,                       
                        TenantId = (int) item.IdTenant,
                        IsTwoFactorEnabled = item.IsTwoFactorEnabled ?? false,
                        IsActive = (bool) item.IsActive
                    };                   
                           
                    return identityMember;               
            }
            return null;
        }
    
        public async Task<List<TUser>> GetUserByEmail(string email)
        {
            //return null;
            var response = await managerU.GetAbpUsersById(email);
            return response.Items.Select(t => new {

                Id = (int)response.Items[0].Id,
                UserName = response.Items[0].UserName,
                AccessFailedCount = response.Items[0].AccessFailedCount,
                EmailAddress = response.Items[0].Email,
                IsEmailConfirmed = response.Items[0].IsEmailConfirmed,
                IsLockoutEnabled = response.Items[0].IsLockoutEnabled,
                LockoutEndDateUtc = response.Items[0].LockoutEndDateUtc,
                DateDebutValidite = response.Items[0].DateDebutValidite,
                DateFinValidite = response.Items[0].DateFinValidite,
                PasswordHash = response.Items[0].Password,
                PhoneNumber = response.Items[0].PhoneNumber,
                IsPhoneNumberConfirmed = response.Items[0].IsPhoneNumberConfirmed,
                SecurityStamp = response.Items[0].SecurityStamp,
                TenantId = (int)response.Items[0].IdTenant,
                IsTwoFactorEnabled = response.Items[0].IsTwoFactorEnabled
            }) as List<TUser>;
        }

        /// <summary>
        /// Return the Member's password hash
        /// </summary>
        /// <param name="memberId">The Member's id</param>
        /// <returns></returns>
        public async Task<string> GetPasswordHash(int memberId)
        {
            var response = await managerU.GetAbpUsersById(memberId);
            return response.Items[0].Password;
        }

        /// <summary>
        /// Sets the Member's password hash
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public async Task SetPasswordHash(int memberId, string passwordHash)
        {
            await managerU.SaveAbpUsers(new BusinessRequest<AbpUsersDto>()
            {
                ItemsToSave = new List<AbpUsersDto>() {

                    new AbpUsersDto()
                    {
                           Id = memberId,
                           Password = passwordHash
                    }
                }
            });
        }

        /// <summary>
        /// Returns the Member's security stamp
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public async Task<string> GetSecurityStamp(int memberId)
        {
            var response = await managerU.GetAbpUsersById(memberId);
            return response.Items[0].SecurityStamp;
        }

        /// <summary>
        /// Inserts a new Member in the Users table
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public async Task Insert(TUser member)
        {
            request.ItemsToSave = new List<AbpUsersDto>()
            {
                new AbpUsersDto()
                {
                    UserName = member.UserName,
                    Nom = member.Nom,
                    Prenoms = member.Prenoms,                    
                    Password = member.PasswordHash,
                    SecurityStamp = member.SecurityStamp,
                    Email = member.Email,
                    IsEmailConfirmed = member.IsEmailConfirmed,
                    CreationTime = member.CreationTime,
                    PhoneNumber = member.PhoneNumber,
                    IsPhoneNumberConfirmed = member.IsPhoneNumberConfirmed,
                    AccessFailedCount = member.AccessFailedCount,
                    LockoutEndDateUtc = member.LockoutEndDateUtc,
                    DateDebutValidite = member.DateDebutValidite,
                   DateFinValidite = member.DateFinValidite,
                    IsLockoutEnabled = member.IsLockoutEnabled,
                    IdTenant = member.TenantId,
                    CreatorUserId = member.CreatorUserId,
                    IsActive = member.IsActive,
                    IdPersonne = member.IdPersonne
                    
                    //PrestataireId = member.IdPrestataireMedical
                }
            };
            await managerU.SaveAbpUsers(request);
        }

        /// <summary>
        /// Update a Member in the Users table
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public async void Update(TUser member)
        {
            var user = await managerU.GetAbpUsersById(member.Id);
            var abpUsersDto = user.Items.FirstOrDefault();
            if (abpUsersDto != null)
            {
                abpUsersDto.Id = member.Id;
                abpUsersDto.UserName = member.UserName;
                abpUsersDto.Email = member.Email;
                abpUsersDto.IdTenant = member.TenantId;
                await managerU.SaveAbpUsers(new BusinessRequest<AbpUsersDto>()
                {
                    ItemsToSave = new List<AbpUsersDto>
                    {
                        abpUsersDto
                    },
                    IdCurrentUser = request.IdCurrentUser
                });
            }
        }

        /// <summary>
        /// Deletes a Member from the Users table
        /// </summary>
        /// <param name="memberId">The Member's id</param>
        /// <returns></returns>
        private async Task Delete(int memberId)
        {
          
            await managerU.DeleteAbpUsers(new BusinessRequest<AbpUsersDto>()
            {
                ItemToSearch = new AbpUsersDto()
                {
                    Id = memberId
                }
            });
        }

        /// <summary>
        /// Deletes a Member from the Users table
        /// </summary>
        /// <param name="Member"></param>
        /// <returns></returns>
        public async Task Delete(TUser Member)
        {

            await managerU.DeleteAbpUsers(new BusinessRequest<AbpUsersDto>()
            {
                ItemToSearch = new AbpUsersDto()
                {
                    Id = Member.Id
                }
            });
        }

        /// <summary>
        /// Updates a Member in the Users table
        /// </summary>
        /// <param name="Member"></param>
        /// <returns></returns>
        //public  async void Update(TUser member)
        //{
        //    request.ItemToSearch = new AbpUsersDto();
        //    if (request.ItemToSearch != null)
        //    {
        //        request.ItemToSearch.Id = member.Id;
        //        request.ItemToSearch.Nom = member.Nom;
        //        request.ItemToSearch.Prenoms = member.Prenoms;
        //        request.ItemToSearch.UserName = member.UserName;
        //        request.ItemToSearch.SecurityStamp = member.SecurityStamp;
        //        request.ItemToSearch.Email = member.Email;
        //        request.ItemToSearch.PhoneNumber = member.PhoneNumber;
        //        request.ItemToSearch.IsPhoneNumberConfirmed = member.IsPhoneNumberConfirmed;
        //        request.ItemToSearch.AccessFailedCount = member.AccessFailedCount;
        //        request.ItemToSearch.LockoutEndDateUtc = member.LockoutEndDateUtc;
        //        request.ItemToSearch.IsLockoutEnabled = member.IsLockoutEnabled;
        //        request.ItemToSearch.IdTenant = member.TenantId;
        //        request.ItemToSearch.IsTwoFactorEnabled = member.IsTwoFactorEnabled;
        //        request.ItemToSearch.Password = member.PasswordHash;
        //    }

        //    await managerU.SaveAbpUsers(request);           
        //}
    

        // Get All Users
        public IQueryable<TUser> GetAllUser()
        {
            var response = managerU.GetAbpUsersByCriteria(new BusinessRequest<AbpUsersDto>() { ItemToSearch = new AbpUsersDto() { } });
            var users = response.Result.Items;
            return users.Select(t => new {
                Id = (int)users[0].Id,
                UserName = users[0].UserName,
                AccessFailedCount = users[0].AccessFailedCount,
                EmailAddress = users[0].Email,
                IsEmailConfirmed = users[0].IsEmailConfirmed,
                IsLockoutEnabled = users[0].IsLockoutEnabled,
                LockoutEndDateUtc = users[0].LockoutEndDateUtc,
                DateDebutValidite = users[0].DateDebutValidite,
                DateFinValidite = users[0].DateFinValidite,
                PasswordHash = users[0].Password,
                PhoneNumber = users[0].PhoneNumber,
                IsPhoneNumberConfirmed = users[0].IsPhoneNumberConfirmed,
                SecurityStamp = users[0].SecurityStamp,
                TenantId = (int)users[0].IdTenant,
                IsTwoFactorEnabled = users[0].IsTwoFactorEnabled               
            }
            ) as IQueryable<TUser>;

        }
    }
}