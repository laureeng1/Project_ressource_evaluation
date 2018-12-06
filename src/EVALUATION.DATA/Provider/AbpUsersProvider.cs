using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Dynamic;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using EVALUATION.DATA;
using EVALUATION.DATA.Repository;
using EVALUATION.CORE.Dto;
using Admin.Common.Domain;
using Admin.Common.Enum;
using Admin.Common.Helper;

namespace EVALUATION.DATA.Provider
{
  public partial class AbpUsersProvider : ProviderBase
  {
        #region Singleton
   
        private const string _tableName = "dbo.AbpUsers";

        private readonly List<string> _keyProperties = new List<string>
        {
          "Id",
        };

        private readonly List<string> _notKeyProperties = new List<string>
        {
          "AuthenticationSource",
          "Nom",
          "Prenoms",
          "Password",
          "IsEmailConfirmed",
          "EmailConfirmationCode",
          "PasswordResetCode",
          "DateDebutValidite",
          "DateFinValidite",
          "LockoutEndDateUtc",
          "AccessFailedCount",
          "IsLockoutEnabled",
          "PhoneNumber",
          "IsPhoneNumberConfirmed",
          "SecurityStamp",
          "IsTwoFactorEnabled",
          "IsActive",
          "UserName",
          "Email",
          "LastLoginTime",
          "IdPersonne",
          "IdGarant",
          "IsDeleted",
          "DeleterUserId",
          "LastModifierUserId",
          "CreationTime",
          "CreatorUserId",
          "DateCreation",
          "DateMaj",
          "CreatedBy",
          "ModifiedBy",
          "DataKey",
          "IdTenant",
        };
        
        private static AbpUsersProvider _instance;
    
        public static AbpUsersProvider Instance
        {
            get { return _instance ?? (_instance = new AbpUsersProvider()); }
        }

        public AbpUsersProvider()
        {
        }
    
        #endregion

        #region Read

      public async Task<BusinessResponse<AbpUsersDto>> GetAbpUsersById(object id, GenericProvider provider = null)
      {
          var response = new BusinessResponse<AbpUsersDto>();

          try
          {

        		if (provider != null) provider.CloseConnetionAutomaticaly = false;
        		  provider = provider??new GenericProvider();
        
              var item = await provider.GetItemByIdAsync<AbpUsersDto>(id, _tableName, _keyProperties.First());
        		if (provider.CloseConnetionAutomaticaly) 
        			provider.DbManager.Dispose();


              if (item != null && item.IsDeleted == false)                  
              {
                  response.Items.Add(item);
              }
          }
          catch(Exception ex)
          {
              CustomException.Write(response, ex);
          }

          return response;
      }


        /// <summary>
        /// Recupere les données de la table
        /// </summary>
        /// <param name="request">La requete contenant les criteres de recherche</param>
        /// <returns></returns>
        public async Task<BusinessResponse<AbpUsersDto>> GetAbpUsersByCriteria(BusinessRequest<AbpUsersDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<AbpUsersDto>();
        		if (provider != null) provider.CloseConnetionAutomaticaly = false;
        		  provider = provider??new GenericProvider();
        
        		response = await provider.GetItemsByCriteriaAsync(request, _tableName, GetWhereExpression,GenerateOrderByExpression, GenerateSum);
        		if (provider.CloseConnetionAutomaticaly) 
        			provider.DbManager.Dispose();
        		return response;

            //return await new GenericProvider().GetItemsByCriteriaAsync(request, _tableName, GetWhereExpression,
            //  GenerateOrderByExpression, GenerateSum);
        }

        /// <summary>
        /// Recupere les données de la table
        /// </summary>
        /// <param name="request">La requete contenant les criteres de recherche</param>
        /// <returns></returns>
        public async Task<BusinessResponse<decimal>> GetSumAbpUsersByCriteria(BusinessRequest<AbpUsersDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<decimal>();
        		if (provider != null) provider.CloseConnetionAutomaticaly = false;
        		  provider = provider??new GenericProvider();
        
            response =  await provider.GetSumByCriteriaAsync(request, _tableName, GetWhereExpression,
                GenerateSumExpression);
        		if (provider.CloseConnetionAutomaticaly) 
        			provider.DbManager.Dispose();
        		return response;

        }

        /// <summary>
        /// Générer une expression lambda à partir d'un DTO
        /// </summary>
        /// <param name="itemToSearch">objet DTO contenant les champs de recherche</param>
        // <param name="suffix"></param>
        /// <param name="dictionary"></param>
        /// <param name="isMainCriteria"></param>
        /// <returns>Expression lambda (null si le DTO ne contient pas de champ de recherche)</returns>
        private string GetWhereExpression(AbpUsersDto itemToSearch, short suffix, ref IDictionary<string, object> dictionary, bool isMainCriteria = false) 
        {
          var lstCriteria = new List<string>();
                                                             
          #region Id
          if (itemToSearch.InfoSearchId.Consider)
          {
              var debut = itemToSearch.InfoSearchId.Intervalle != null
                  ? (object) itemToSearch.InfoSearchId.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchId.Intervalle != null
                  ? (object) itemToSearch.InfoSearchId.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("Id", itemToSearch.Id, "long", itemToSearch.InfoSearchId.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region AuthenticationSource
          if (itemToSearch.InfoSearchAuthenticationSource.Consider)
          {
                lstCriteria.AddWhereExpression("AuthenticationSource", itemToSearch.AuthenticationSource, "string", itemToSearch.InfoSearchAuthenticationSource.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region Nom
          if (itemToSearch.InfoSearchNom.Consider)
          {
                lstCriteria.AddWhereExpression("Nom", itemToSearch.Nom, "string", itemToSearch.InfoSearchNom.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region Prenoms
          if (itemToSearch.InfoSearchPrenoms.Consider)
          {
                lstCriteria.AddWhereExpression("Prenoms", itemToSearch.Prenoms, "string", itemToSearch.InfoSearchPrenoms.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region Password
          if (itemToSearch.InfoSearchPassword.Consider)
          {
                lstCriteria.AddWhereExpression("Password", itemToSearch.Password, "string", itemToSearch.InfoSearchPassword.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region IsEmailConfirmed
          if (itemToSearch.InfoSearchIsEmailConfirmed.Consider)
          {
                lstCriteria.AddWhereExpression("IsEmailConfirmed", itemToSearch.IsEmailConfirmed, "global::System.Nullable<bool>", itemToSearch.InfoSearchIsEmailConfirmed.OperatorToUse, suffix, ref dictionary);
          }            

                  #endregion

          #region EmailConfirmationCode
          if (itemToSearch.InfoSearchEmailConfirmationCode.Consider)
          {
                lstCriteria.AddWhereExpression("EmailConfirmationCode", itemToSearch.EmailConfirmationCode, "string", itemToSearch.InfoSearchEmailConfirmationCode.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region PasswordResetCode
          if (itemToSearch.InfoSearchPasswordResetCode.Consider)
          {
                lstCriteria.AddWhereExpression("PasswordResetCode", itemToSearch.PasswordResetCode, "string", itemToSearch.InfoSearchPasswordResetCode.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region DateDebutValidite
          if (itemToSearch.InfoSearchDateDebutValidite.Consider)
          {
              var debut = itemToSearch.InfoSearchDateDebutValidite.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDateDebutValidite.Intervalle.Debut.ToShortDateString()
                  :  null;
              var fin = itemToSearch.InfoSearchDateDebutValidite.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDateDebutValidite.Intervalle.Fin.ToShortDateString()
                  :  null;
              lstCriteria.AddWhereExpression("DateDebutValidite", itemToSearch.DateDebutValidite.Value.ToShortDateString(), "global::System.Nullable<System.DateTime>", itemToSearch.InfoSearchDateDebutValidite.OperatorToUse, suffix, ref dictionary,  debut, fin);
          }              

          #endregion

          #region DateFinValidite
          if (itemToSearch.InfoSearchDateFinValidite.Consider)
          {
              var debut = itemToSearch.InfoSearchDateFinValidite.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDateFinValidite.Intervalle.Debut.ToShortDateString()
                  :  null;
              var fin = itemToSearch.InfoSearchDateFinValidite.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDateFinValidite.Intervalle.Fin.ToShortDateString()
                  :  null;
              lstCriteria.AddWhereExpression("DateFinValidite", itemToSearch.DateFinValidite.Value.ToShortDateString(), "global::System.Nullable<System.DateTime>", itemToSearch.InfoSearchDateFinValidite.OperatorToUse, suffix, ref dictionary,  debut, fin);
          }              

          #endregion

          #region LockoutEndDateUtc
          if (itemToSearch.InfoSearchLockoutEndDateUtc.Consider)
          {
              var debut = itemToSearch.InfoSearchLockoutEndDateUtc.Intervalle != null
                  ? (object) itemToSearch.InfoSearchLockoutEndDateUtc.Intervalle.Debut.ToShortDateString()
                  :  null;
              var fin = itemToSearch.InfoSearchLockoutEndDateUtc.Intervalle != null
                  ? (object) itemToSearch.InfoSearchLockoutEndDateUtc.Intervalle.Fin.ToShortDateString()
                  :  null;
              lstCriteria.AddWhereExpression("LockoutEndDateUtc", itemToSearch.LockoutEndDateUtc.Value.ToShortDateString(), "global::System.Nullable<System.DateTime>", itemToSearch.InfoSearchLockoutEndDateUtc.OperatorToUse, suffix, ref dictionary,  debut, fin);
          }              

          #endregion

          #region AccessFailedCount
          if (itemToSearch.InfoSearchAccessFailedCount.Consider)
          {
              var debut = itemToSearch.InfoSearchAccessFailedCount.Intervalle != null
                  ? (object) itemToSearch.InfoSearchAccessFailedCount.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchAccessFailedCount.Intervalle != null
                  ? (object) itemToSearch.InfoSearchAccessFailedCount.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("AccessFailedCount", itemToSearch.AccessFailedCount, "global::System.Nullable<int>", itemToSearch.InfoSearchAccessFailedCount.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region IsLockoutEnabled
          if (itemToSearch.InfoSearchIsLockoutEnabled.Consider)
          {
                lstCriteria.AddWhereExpression("IsLockoutEnabled", itemToSearch.IsLockoutEnabled, "global::System.Nullable<bool>", itemToSearch.InfoSearchIsLockoutEnabled.OperatorToUse, suffix, ref dictionary);
          }            

                  #endregion

          #region PhoneNumber
          if (itemToSearch.InfoSearchPhoneNumber.Consider)
          {
                lstCriteria.AddWhereExpression("PhoneNumber", itemToSearch.PhoneNumber, "string", itemToSearch.InfoSearchPhoneNumber.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region IsPhoneNumberConfirmed
          if (itemToSearch.InfoSearchIsPhoneNumberConfirmed.Consider)
          {
                lstCriteria.AddWhereExpression("IsPhoneNumberConfirmed", itemToSearch.IsPhoneNumberConfirmed, "global::System.Nullable<bool>", itemToSearch.InfoSearchIsPhoneNumberConfirmed.OperatorToUse, suffix, ref dictionary);
          }            

                  #endregion

          #region SecurityStamp
          if (itemToSearch.InfoSearchSecurityStamp.Consider)
          {
                lstCriteria.AddWhereExpression("SecurityStamp", itemToSearch.SecurityStamp, "string", itemToSearch.InfoSearchSecurityStamp.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region IsTwoFactorEnabled
          if (itemToSearch.InfoSearchIsTwoFactorEnabled.Consider)
          {
                lstCriteria.AddWhereExpression("IsTwoFactorEnabled", itemToSearch.IsTwoFactorEnabled, "global::System.Nullable<bool>", itemToSearch.InfoSearchIsTwoFactorEnabled.OperatorToUse, suffix, ref dictionary);
          }            

                  #endregion

          #region IsActive
          if (itemToSearch.InfoSearchIsActive.Consider)
          {
                lstCriteria.AddWhereExpression("IsActive", itemToSearch.IsActive, "global::System.Nullable<bool>", itemToSearch.InfoSearchIsActive.OperatorToUse, suffix, ref dictionary);
          }            

                  #endregion

          #region UserName
          if (itemToSearch.InfoSearchUserName.Consider)
          {
                lstCriteria.AddWhereExpression("UserName", itemToSearch.UserName, "string", itemToSearch.InfoSearchUserName.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region Email
          if (itemToSearch.InfoSearchEmail.Consider)
          {
                lstCriteria.AddWhereExpression("Email", itemToSearch.Email, "string", itemToSearch.InfoSearchEmail.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region LastLoginTime
          if (itemToSearch.InfoSearchLastLoginTime.Consider)
          {
              var debut = itemToSearch.InfoSearchLastLoginTime.Intervalle != null
                  ? (object) itemToSearch.InfoSearchLastLoginTime.Intervalle.Debut.ToShortDateString()
                  :  null;
              var fin = itemToSearch.InfoSearchLastLoginTime.Intervalle != null
                  ? (object) itemToSearch.InfoSearchLastLoginTime.Intervalle.Fin.ToShortDateString()
                  :  null;
              lstCriteria.AddWhereExpression("LastLoginTime", itemToSearch.LastLoginTime.Value.ToShortDateString(), "global::System.Nullable<System.DateTime>", itemToSearch.InfoSearchLastLoginTime.OperatorToUse, suffix, ref dictionary,  debut, fin);
          }              

          #endregion

          #region IdPersonne
          if (itemToSearch.InfoSearchIdPersonne.Consider)
          {
              var debut = itemToSearch.InfoSearchIdPersonne.Intervalle != null
                  ? (object) itemToSearch.InfoSearchIdPersonne.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchIdPersonne.Intervalle != null
                  ? (object) itemToSearch.InfoSearchIdPersonne.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("IdPersonne", itemToSearch.IdPersonne, "global::System.Nullable<long>", itemToSearch.InfoSearchIdPersonne.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region IdGarant
          if (itemToSearch.InfoSearchIdGarant.Consider)
          {
              var debut = itemToSearch.InfoSearchIdGarant.Intervalle != null
                  ? (object) itemToSearch.InfoSearchIdGarant.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchIdGarant.Intervalle != null
                  ? (object) itemToSearch.InfoSearchIdGarant.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("IdGarant", itemToSearch.IdGarant, "global::System.Nullable<long>", itemToSearch.InfoSearchIdGarant.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region IsDeleted
          if (itemToSearch.InfoSearchIsDeleted.Consider)
          {
                lstCriteria.AddWhereExpression("IsDeleted", itemToSearch.IsDeleted, "global::System.Nullable<bool>", itemToSearch.InfoSearchIsDeleted.OperatorToUse, suffix, ref dictionary);
          }            

                  #endregion

          #region DeleterUserId
          if (itemToSearch.InfoSearchDeleterUserId.Consider)
          {
              var debut = itemToSearch.InfoSearchDeleterUserId.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDeleterUserId.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchDeleterUserId.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDeleterUserId.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("DeleterUserId", itemToSearch.DeleterUserId, "global::System.Nullable<long>", itemToSearch.InfoSearchDeleterUserId.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region LastModifierUserId
          if (itemToSearch.InfoSearchLastModifierUserId.Consider)
          {
              var debut = itemToSearch.InfoSearchLastModifierUserId.Intervalle != null
                  ? (object) itemToSearch.InfoSearchLastModifierUserId.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchLastModifierUserId.Intervalle != null
                  ? (object) itemToSearch.InfoSearchLastModifierUserId.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("LastModifierUserId", itemToSearch.LastModifierUserId, "global::System.Nullable<long>", itemToSearch.InfoSearchLastModifierUserId.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region CreationTime
          if (itemToSearch.InfoSearchCreationTime.Consider)
          {
              var debut = itemToSearch.InfoSearchCreationTime.Intervalle != null
                  ? (object) itemToSearch.InfoSearchCreationTime.Intervalle.Debut.ToShortDateString()
                  :  null;
              var fin = itemToSearch.InfoSearchCreationTime.Intervalle != null
                  ? (object) itemToSearch.InfoSearchCreationTime.Intervalle.Fin.ToShortDateString()
                  :  null;
              lstCriteria.AddWhereExpression("CreationTime", itemToSearch.CreationTime.Value.ToShortDateString(), "global::System.Nullable<System.DateTime>", itemToSearch.InfoSearchCreationTime.OperatorToUse, suffix, ref dictionary,  debut, fin);
          }              

          #endregion

          #region CreatorUserId
          if (itemToSearch.InfoSearchCreatorUserId.Consider)
          {
              var debut = itemToSearch.InfoSearchCreatorUserId.Intervalle != null
                  ? (object) itemToSearch.InfoSearchCreatorUserId.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchCreatorUserId.Intervalle != null
                  ? (object) itemToSearch.InfoSearchCreatorUserId.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("CreatorUserId", itemToSearch.CreatorUserId, "global::System.Nullable<long>", itemToSearch.InfoSearchCreatorUserId.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region DateCreation
          if (itemToSearch.InfoSearchDateCreation.Consider)
          {
              var debut = itemToSearch.InfoSearchDateCreation.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDateCreation.Intervalle.Debut.ToShortDateString()
                  :  null;
              var fin = itemToSearch.InfoSearchDateCreation.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDateCreation.Intervalle.Fin.ToShortDateString()
                  :  null;
              lstCriteria.AddWhereExpression("DateCreation", itemToSearch.DateCreation.Value.ToShortDateString(), "global::System.Nullable<System.DateTime>", itemToSearch.InfoSearchDateCreation.OperatorToUse, suffix, ref dictionary,  debut, fin);
          }              

          #endregion

          #region DateMaj
          if (itemToSearch.InfoSearchDateMaj.Consider)
          {
              var debut = itemToSearch.InfoSearchDateMaj.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDateMaj.Intervalle.Debut.ToShortDateString()
                  :  null;
              var fin = itemToSearch.InfoSearchDateMaj.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDateMaj.Intervalle.Fin.ToShortDateString()
                  :  null;
              lstCriteria.AddWhereExpression("DateMaj", itemToSearch.DateMaj.Value.ToShortDateString(), "global::System.Nullable<System.DateTime>", itemToSearch.InfoSearchDateMaj.OperatorToUse, suffix, ref dictionary,  debut, fin);
          }              

          #endregion

          #region CreatedBy
          if (itemToSearch.InfoSearchCreatedBy.Consider)
          {
              var debut = itemToSearch.InfoSearchCreatedBy.Intervalle != null
                  ? (object) itemToSearch.InfoSearchCreatedBy.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchCreatedBy.Intervalle != null
                  ? (object) itemToSearch.InfoSearchCreatedBy.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("CreatedBy", itemToSearch.CreatedBy, "global::System.Nullable<long>", itemToSearch.InfoSearchCreatedBy.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region ModifiedBy
          if (itemToSearch.InfoSearchModifiedBy.Consider)
          {
              var debut = itemToSearch.InfoSearchModifiedBy.Intervalle != null
                  ? (object) itemToSearch.InfoSearchModifiedBy.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchModifiedBy.Intervalle != null
                  ? (object) itemToSearch.InfoSearchModifiedBy.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("ModifiedBy", itemToSearch.ModifiedBy, "global::System.Nullable<long>", itemToSearch.InfoSearchModifiedBy.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region DataKey
          if (itemToSearch.InfoSearchDataKey.Consider)
          {
                lstCriteria.AddWhereExpression("DataKey", itemToSearch.DataKey, "string", itemToSearch.InfoSearchDataKey.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region IdTenant
          if (itemToSearch.InfoSearchIdTenant.Consider)
          {
              var debut = itemToSearch.InfoSearchIdTenant.Intervalle != null
                  ? (object) itemToSearch.InfoSearchIdTenant.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchIdTenant.Intervalle != null
                  ? (object) itemToSearch.InfoSearchIdTenant.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("IdTenant", itemToSearch.IdTenant, "global::System.Nullable<long>", itemToSearch.InfoSearchIdTenant.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

                   
          #region build the query

          var response = Utilities.BuildQuery(lstCriteria);

          if (isMainCriteria)
              response = string.IsNullOrEmpty(response) ? string.Format(" WHERE ( IsDeleted = '{0}' ) ", "false") : string.Format(" WHERE ({0} AND IsDeleted = '{1}') ", response, "false");            
          #endregion

          return response;
      }



              /// <summary>
        /// Générer une expression lambda à partir d'un DTO
        /// </summary>
        /// <param name="itemToSearch">objet DTO contenant les champs de recherche</param>
        // <param name="suffix"></param>
        /// <param name="dictionary"></param>
        /// <param name="isMainCriteria"></param>
        /// <returns>Expression lambda (null si le DTO ne contient pas de champ de recherche)</returns>
        private string GetTableUpdateExpression(AbpUsersDto itemToSave, List<string> keyProperties, List<string> notKeyProperties) 
        {
                                                             
          #region Id

           if (!itemToSave.InfoSearchId.Consider)
          {
             

              notKeyProperties.Remove("Id");
          }
                    
          #endregion

          #region AuthenticationSource

           if (!itemToSave.InfoSearchAuthenticationSource.Consider)
          {
             

              notKeyProperties.Remove("AuthenticationSource");
          }
                    
          #endregion

          #region Nom

           if (!itemToSave.InfoSearchNom.Consider)
          {
             

              notKeyProperties.Remove("Nom");
          }
                    
          #endregion

          #region Prenoms

           if (!itemToSave.InfoSearchPrenoms.Consider)
          {
             

              notKeyProperties.Remove("Prenoms");
          }
                    
          #endregion

          #region Password

           if (!itemToSave.InfoSearchPassword.Consider)
          {
             

              notKeyProperties.Remove("Password");
          }
                    
          #endregion

          #region IsEmailConfirmed

           if (!itemToSave.InfoSearchIsEmailConfirmed.Consider)
          {
             

              notKeyProperties.Remove("IsEmailConfirmed");
          }
                    
          #endregion

          #region EmailConfirmationCode

           if (!itemToSave.InfoSearchEmailConfirmationCode.Consider)
          {
             

              notKeyProperties.Remove("EmailConfirmationCode");
          }
                    
          #endregion

          #region PasswordResetCode

           if (!itemToSave.InfoSearchPasswordResetCode.Consider)
          {
             

              notKeyProperties.Remove("PasswordResetCode");
          }
                    
          #endregion

          #region DateDebutValidite

           if (!itemToSave.InfoSearchDateDebutValidite.Consider)
          {
             

              notKeyProperties.Remove("DateDebutValidite");
          }
                    
          #endregion

          #region DateFinValidite

           if (!itemToSave.InfoSearchDateFinValidite.Consider)
          {
             

              notKeyProperties.Remove("DateFinValidite");
          }
                    
          #endregion

          #region LockoutEndDateUtc

           if (!itemToSave.InfoSearchLockoutEndDateUtc.Consider)
          {
             

              notKeyProperties.Remove("LockoutEndDateUtc");
          }
                    
          #endregion

          #region AccessFailedCount

           if (!itemToSave.InfoSearchAccessFailedCount.Consider)
          {
             

              notKeyProperties.Remove("AccessFailedCount");
          }
                    
          #endregion

          #region IsLockoutEnabled

           if (!itemToSave.InfoSearchIsLockoutEnabled.Consider)
          {
             

              notKeyProperties.Remove("IsLockoutEnabled");
          }
                    
          #endregion

          #region PhoneNumber

           if (!itemToSave.InfoSearchPhoneNumber.Consider)
          {
             

              notKeyProperties.Remove("PhoneNumber");
          }
                    
          #endregion

          #region IsPhoneNumberConfirmed

           if (!itemToSave.InfoSearchIsPhoneNumberConfirmed.Consider)
          {
             

              notKeyProperties.Remove("IsPhoneNumberConfirmed");
          }
                    
          #endregion

          #region SecurityStamp

           if (!itemToSave.InfoSearchSecurityStamp.Consider)
          {
             

              notKeyProperties.Remove("SecurityStamp");
          }
                    
          #endregion

          #region IsTwoFactorEnabled

           if (!itemToSave.InfoSearchIsTwoFactorEnabled.Consider)
          {
             

              notKeyProperties.Remove("IsTwoFactorEnabled");
          }
                    
          #endregion

          #region IsActive

           if (!itemToSave.InfoSearchIsActive.Consider)
          {
             

              notKeyProperties.Remove("IsActive");
          }
                    
          #endregion

          #region UserName

           if (!itemToSave.InfoSearchUserName.Consider)
          {
             

              notKeyProperties.Remove("UserName");
          }
                    
          #endregion

          #region Email

           if (!itemToSave.InfoSearchEmail.Consider)
          {
             

              notKeyProperties.Remove("Email");
          }
                    
          #endregion

          #region LastLoginTime

           if (!itemToSave.InfoSearchLastLoginTime.Consider)
          {
             

              notKeyProperties.Remove("LastLoginTime");
          }
                    
          #endregion

          #region IdPersonne

           if (!itemToSave.InfoSearchIdPersonne.Consider)
          {
             

              notKeyProperties.Remove("IdPersonne");
          }
                    
          #endregion

          #region IdGarant

           if (!itemToSave.InfoSearchIdGarant.Consider)
          {
             

              notKeyProperties.Remove("IdGarant");
          }
                    
          #endregion

          #region IsDeleted

           if (!itemToSave.InfoSearchIsDeleted.Consider)
          {
             

              notKeyProperties.Remove("IsDeleted");
          }
                    
          #endregion

          #region DeleterUserId

           if (!itemToSave.InfoSearchDeleterUserId.Consider)
          {
             

              notKeyProperties.Remove("DeleterUserId");
          }
                    
          #endregion

          #region LastModifierUserId

           if (!itemToSave.InfoSearchLastModifierUserId.Consider)
          {
             

              notKeyProperties.Remove("LastModifierUserId");
          }
                    
          #endregion

          #region CreationTime

           if (!itemToSave.InfoSearchCreationTime.Consider)
          {
             

              notKeyProperties.Remove("CreationTime");
          }
                    
          #endregion

          #region CreatorUserId

           if (!itemToSave.InfoSearchCreatorUserId.Consider)
          {
             

              notKeyProperties.Remove("CreatorUserId");
          }
                    
          #endregion

          #region DateCreation

           if (!itemToSave.InfoSearchDateCreation.Consider)
          {
             

              notKeyProperties.Remove("DateCreation");
          }
                    
          #endregion

          #region DateMaj

           if (!itemToSave.InfoSearchDateMaj.Consider)
          {
             

              notKeyProperties.Remove("DateMaj");
          }
                    
          #endregion

          #region CreatedBy

           if (!itemToSave.InfoSearchCreatedBy.Consider)
          {
             

              notKeyProperties.Remove("CreatedBy");
          }
                    
          #endregion

          #region ModifiedBy

           if (!itemToSave.InfoSearchModifiedBy.Consider)
          {
             

              notKeyProperties.Remove("ModifiedBy");
          }
                    
          #endregion

          #region DataKey

           if (!itemToSave.InfoSearchDataKey.Consider)
          {
             

              notKeyProperties.Remove("DataKey");
          }
                    
          #endregion

          #region IdTenant

           if (!itemToSave.InfoSearchIdTenant.Consider)
          {
             

              notKeyProperties.Remove("IdTenant");
          }
                    
          #endregion

                   
          #region build the query

           var notKeyPropertiesBuild =
                notKeyProperties.Select(nkeyProp => string.Format("{0} = {1}", nkeyProp, nkeyProp.GetSqlQueryParam()))
                    .ToList();
            var notKeyPropertiesSqlString = string.Join(", ", notKeyPropertiesBuild);

            var keyBuild = keyProperties.Select(key => string.Format("{0} = {1}", key, key.GetSqlQueryParam())).ToList();
            var keySqlString = string.Join(" AND ", keyBuild);

          #endregion

          return String.Format("UPDATE {0} SET {1} WHERE {2}", _tableName, notKeyPropertiesSqlString, keySqlString);
      }

      /// <summary>
        /// Générer une expression lambda à partir d'un DTO
        /// </summary>
        /// <param name="itemToSearch">objet DTO contenant les champs de recherche</param>
        /// <returns>Expression lambda</returns>
      private static string GenerateOrderByExpression(AbpUsersDto itemToSearch, string sortOrder)
      {
          string field = null;

          if (itemToSearch.InfoSearchId.IsOrderByField)
            field = "Id";
          if (itemToSearch.InfoSearchAuthenticationSource.IsOrderByField)
            field = "AuthenticationSource";
          if (itemToSearch.InfoSearchNom.IsOrderByField)
            field = "Nom";
          if (itemToSearch.InfoSearchPrenoms.IsOrderByField)
            field = "Prenoms";
          if (itemToSearch.InfoSearchPassword.IsOrderByField)
            field = "Password";
          if (itemToSearch.InfoSearchIsEmailConfirmed.IsOrderByField)
            field = "IsEmailConfirmed";
          if (itemToSearch.InfoSearchEmailConfirmationCode.IsOrderByField)
            field = "EmailConfirmationCode";
          if (itemToSearch.InfoSearchPasswordResetCode.IsOrderByField)
            field = "PasswordResetCode";
          if (itemToSearch.InfoSearchDateDebutValidite.IsOrderByField)
            field = "DateDebutValidite";
          if (itemToSearch.InfoSearchDateFinValidite.IsOrderByField)
            field = "DateFinValidite";
          if (itemToSearch.InfoSearchLockoutEndDateUtc.IsOrderByField)
            field = "LockoutEndDateUtc";
          if (itemToSearch.InfoSearchAccessFailedCount.IsOrderByField)
            field = "AccessFailedCount";
          if (itemToSearch.InfoSearchIsLockoutEnabled.IsOrderByField)
            field = "IsLockoutEnabled";
          if (itemToSearch.InfoSearchPhoneNumber.IsOrderByField)
            field = "PhoneNumber";
          if (itemToSearch.InfoSearchIsPhoneNumberConfirmed.IsOrderByField)
            field = "IsPhoneNumberConfirmed";
          if (itemToSearch.InfoSearchSecurityStamp.IsOrderByField)
            field = "SecurityStamp";
          if (itemToSearch.InfoSearchIsTwoFactorEnabled.IsOrderByField)
            field = "IsTwoFactorEnabled";
          if (itemToSearch.InfoSearchIsActive.IsOrderByField)
            field = "IsActive";
          if (itemToSearch.InfoSearchUserName.IsOrderByField)
            field = "UserName";
          if (itemToSearch.InfoSearchEmail.IsOrderByField)
            field = "Email";
          if (itemToSearch.InfoSearchLastLoginTime.IsOrderByField)
            field = "LastLoginTime";
          if (itemToSearch.InfoSearchIdPersonne.IsOrderByField)
            field = "IdPersonne";
          if (itemToSearch.InfoSearchIdGarant.IsOrderByField)
            field = "IdGarant";
          if (itemToSearch.InfoSearchIsDeleted.IsOrderByField)
            field = "IsDeleted";
          if (itemToSearch.InfoSearchDeleterUserId.IsOrderByField)
            field = "DeleterUserId";
          if (itemToSearch.InfoSearchLastModifierUserId.IsOrderByField)
            field = "LastModifierUserId";
          if (itemToSearch.InfoSearchCreationTime.IsOrderByField)
            field = "CreationTime";
          if (itemToSearch.InfoSearchCreatorUserId.IsOrderByField)
            field = "CreatorUserId";
          if (itemToSearch.InfoSearchDateCreation.IsOrderByField)
            field = "DateCreation";
          if (itemToSearch.InfoSearchDateMaj.IsOrderByField)
            field = "DateMaj";
          if (itemToSearch.InfoSearchCreatedBy.IsOrderByField)
            field = "CreatedBy";
          if (itemToSearch.InfoSearchModifiedBy.IsOrderByField)
            field = "ModifiedBy";
          if (itemToSearch.InfoSearchDataKey.IsOrderByField)
            field = "DataKey";
          if (itemToSearch.InfoSearchIdTenant.IsOrderByField)
            field = "IdTenant";
          var sqlSortOrder = (sortOrder == MySortOrder.Ascending) ? "ASC" : "DESC";

          return !string.IsNullOrEmpty(field) ? string.Format(" ORDER BY {0} {1}", field, sqlSortOrder) : string.Format(" ORDER BY {0} {1}", "Id", sqlSortOrder);
      }

      /// <summary>
      /// Générer une expression lambda à partir d'un DTO
      /// </summary>
      /// <param name="itemToSearch">objet DTO contenant les champs de recherche</param>
      /// <returns>Expression lambda</returns>
      private static string GenerateSumExpression(AbpUsersDto itemToSearch)
      {
          string field = null;

          if (itemToSearch.InfoSearchAccessFailedCount.IsSumField)
            field = "AccessFailedCount";                                         
            if (itemToSearch.InfoSearchDeleterUserId.IsSumField)
            field = "DeleterUserId";                                         
            if (itemToSearch.InfoSearchLastModifierUserId.IsSumField)
            field = "LastModifierUserId";                                         
            if (itemToSearch.InfoSearchCreatorUserId.IsSumField)
            field = "CreatorUserId";                                         
            if (itemToSearch.InfoSearchCreatedBy.IsSumField)
            field = "CreatedBy";                                         
            if (itemToSearch.InfoSearchModifiedBy.IsSumField)
            field = "ModifiedBy";                                         
            return field;
      }

      /// <summary>
      /// Générer une expression lambda à partir d'un DTO
      /// </summary>
      /// <param name="criteria"></param>
      /// <param name="paramObj"></param>
      /// <param name="itemToSearch">objet DTO contenant les champs de recherche</param>
      /// <param name="itemToReturn"></param>
      /// <returns>Expression lambda</returns>
      private AbpUsersDto GenerateSum(string criteria, object paramObj, AbpUsersDto itemToSearch, AbpUsersDto itemToReturn)
      {
        /* mis en commentaire par brice parceque le provider n'a pas transité par 
           Le generiprovider pour executer la requete
       //   if (itemToSearch.InfoSearchAccessFailedCount.IsSumField)
       //     itemToReturn.InfoSearchAccessFailedCount.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(AccessFailedCount) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
         //   if (itemToSearch.InfoSearchDeleterUserId.IsSumField)
       //     itemToReturn.InfoSearchDeleterUserId.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(DeleterUserId) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
         //   if (itemToSearch.InfoSearchLastModifierUserId.IsSumField)
       //     itemToReturn.InfoSearchLastModifierUserId.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(LastModifierUserId) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
         //   if (itemToSearch.InfoSearchCreatorUserId.IsSumField)
       //     itemToReturn.InfoSearchCreatorUserId.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(CreatorUserId) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
         //   if (itemToSearch.InfoSearchCreatedBy.IsSumField)
       //     itemToReturn.InfoSearchCreatedBy.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(CreatedBy) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
         //   if (itemToSearch.InfoSearchModifiedBy.IsSumField)
       //     itemToReturn.InfoSearchModifiedBy.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(ModifiedBy) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
            */
          return itemToReturn;
      }

      #endregion

        #region Create, Update, Delete
      
        public async Task<BusinessResponse<AbpUsersDto>> SaveAbpUsers(BusinessRequest<AbpUsersDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<AbpUsersDto>();
        		if (provider != null) provider.CloseConnetionAutomaticaly = false;
        		  provider = provider??new GenericProvider();
        
            response = await provider.SaveItemsAsync(request, _tableName, _keyProperties.Clone(), _notKeyProperties.Clone(),
                FormatItemsToSave,GetTableUpdateExpression);
        		if (provider.CloseConnetionAutomaticaly) 
        			provider.DbManager.Dispose();
        		return response;

            //return await new GenericProvider().SaveItemsAsync(request, _tableName, _keyProperties, _notKeyProperties,
            //    FormatItemsToSave);
        }
         public async Task< BusinessResponse<Boolean>> DeleteAbpUsers(BusinessRequest<AbpUsersDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<Boolean>();
        		if (provider != null) provider.CloseConnetionAutomaticaly = false;
        		  provider = provider??new GenericProvider();
        
            response =  await provider.DeleteItemsAsync(request, _tableName, _keyProperties, _notKeyProperties,
                FormatItemsToDelete);
        		if (provider.CloseConnetionAutomaticaly) 
        			provider.DbManager.Dispose();
        		return response;

            //return await new GenericProvider().DeleteItemsAsync(request, _tableName, _keyProperties, _notKeyProperties,
                //FormatItemsToDelete);
        }
      private void FormatItemsToSave(List<AbpUsersDto> itemsToSave, List<AbpUsersDto> itemsToInsert,
          List<AbpUsersDto> itemsToUpdate, long idCurrentUser, short idCurrentStructure, string dataKey)
      {
          foreach (var entity in itemsToSave)
          {
              entity.DateMaj = Utilities.CurrentDate; 
              entity.ModifiedBy = idCurrentUser;
              entity.DataKey = dataKey; 
              //long
              if (entity.Id == 0)  
              {
                  entity.IsDeleted = false;
                  entity.DateCreation = Utilities.CurrentDate; 
                  entity.CreatedBy = idCurrentUser;
                  itemsToInsert.Add(entity);
              }
              else
              {
                  itemsToUpdate.Add(entity);
              }
          }
      }
       
      private async void FormatItemsToDelete(List<AbpUsersDto> itemsToSave, List<AbpUsersDto> itemsToDelete, long idCurrentUser, short idCurrentStructure, string dataKey)
      {
          foreach (var entity in itemsToSave)
          {
              entity.DateMaj = Utilities.CurrentDate; 
              entity.ModifiedBy = idCurrentUser;
              entity.DataKey = dataKey; 
                            

              //Recherche de l'existance du item a supprimer
              var responseItem = await this.GetAbpUsersById(entity.Id);
              if (responseItem.HasError)
                  throw new Exception(responseItem.Message);

              if(!responseItem.Items.Any()) throw new CustomException("l'élément à supprimer n'existe pas");
             entity.IsDeleted = true;
             itemsToDelete.Add(entity);

          }
      }
          #endregion
  }
}

