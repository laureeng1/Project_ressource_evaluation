﻿using System;
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
  public partial class AbpRoleClaimsProvider : ProviderBase
  {
        #region Singleton
   
        private const string _tableName = "dbo.AbpRoleClaims";

        private readonly List<string> _keyProperties = new List<string>
        {
          "Id",
        };

        private readonly List<string> _notKeyProperties = new List<string>
        {
          "RoleId",
          "ClaimType",
          "ClaimValue",
          "IsDeleted",
          "DateCreation",
          "DateMaj",
          "CreatedBy",
          "ModifiedBy",
          "DataKey",
          "IdTenant",
        };
        
        private static AbpRoleClaimsProvider _instance;
    
        public static AbpRoleClaimsProvider Instance
        {
            get { return _instance ?? (_instance = new AbpRoleClaimsProvider()); }
        }

        public AbpRoleClaimsProvider()
        {
        }
    
        #endregion

        #region Read

      public async Task<BusinessResponse<AbpRoleClaimsDto>> GetAbpRoleClaimsById(object id, GenericProvider provider = null)
      {
          var response = new BusinessResponse<AbpRoleClaimsDto>();

          try
          {

        		if (provider != null) provider.CloseConnetionAutomaticaly = false;
        		  provider = provider??new GenericProvider();
        
              var item = await provider.GetItemByIdAsync<AbpRoleClaimsDto>(id, _tableName, _keyProperties.First());
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
        public async Task<BusinessResponse<AbpRoleClaimsDto>> GetAbpRoleClaimsByCriteria(BusinessRequest<AbpRoleClaimsDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<AbpRoleClaimsDto>();
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
        public async Task<BusinessResponse<decimal>> GetSumAbpRoleClaimsByCriteria(BusinessRequest<AbpRoleClaimsDto> request, GenericProvider provider = null)
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
        private string GetWhereExpression(AbpRoleClaimsDto itemToSearch, short suffix, ref IDictionary<string, object> dictionary, bool isMainCriteria = false) 
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

          #region RoleId
          if (itemToSearch.InfoSearchRoleId.Consider)
          {
              var debut = itemToSearch.InfoSearchRoleId.Intervalle != null
                  ? (object) itemToSearch.InfoSearchRoleId.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchRoleId.Intervalle != null
                  ? (object) itemToSearch.InfoSearchRoleId.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("RoleId", itemToSearch.RoleId, "int", itemToSearch.InfoSearchRoleId.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region ClaimType
          if (itemToSearch.InfoSearchClaimType.Consider)
          {
                lstCriteria.AddWhereExpression("ClaimType", itemToSearch.ClaimType, "string", itemToSearch.InfoSearchClaimType.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region ClaimValue
          if (itemToSearch.InfoSearchClaimValue.Consider)
          {
                lstCriteria.AddWhereExpression("ClaimValue", itemToSearch.ClaimValue, "string", itemToSearch.InfoSearchClaimValue.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region IsDeleted
          if (itemToSearch.InfoSearchIsDeleted.Consider)
          {
                lstCriteria.AddWhereExpression("IsDeleted", itemToSearch.IsDeleted, "bool", itemToSearch.InfoSearchIsDeleted.OperatorToUse, suffix, ref dictionary);
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
              lstCriteria.AddWhereExpression("DateCreation", itemToSearch.DateCreation.ToShortDateString(), "global::System.DateTime", itemToSearch.InfoSearchDateCreation.OperatorToUse, suffix, ref dictionary, debut, fin);
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
              lstCriteria.AddWhereExpression("DateMaj", itemToSearch.DateMaj.ToShortDateString(), "global::System.DateTime", itemToSearch.InfoSearchDateMaj.OperatorToUse, suffix, ref dictionary, debut, fin);
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
              lstCriteria.AddWhereExpression("CreatedBy", itemToSearch.CreatedBy, "long", itemToSearch.InfoSearchCreatedBy.OperatorToUse, suffix, ref dictionary, debut, fin);
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
              lstCriteria.AddWhereExpression("ModifiedBy", itemToSearch.ModifiedBy, "long", itemToSearch.InfoSearchModifiedBy.OperatorToUse, suffix, ref dictionary, debut, fin);
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
        private string GetTableUpdateExpression(AbpRoleClaimsDto itemToSave, List<string> keyProperties, List<string> notKeyProperties) 
        {
                                                             
          #region Id

           if (!itemToSave.InfoSearchId.Consider)
          {
             

              notKeyProperties.Remove("Id");
          }
                    
          #endregion

          #region RoleId

           if (!itemToSave.InfoSearchRoleId.Consider)
          {
             

              notKeyProperties.Remove("RoleId");
          }
                    
          #endregion

          #region ClaimType

           if (!itemToSave.InfoSearchClaimType.Consider)
          {
             

              notKeyProperties.Remove("ClaimType");
          }
                    
          #endregion

          #region ClaimValue

           if (!itemToSave.InfoSearchClaimValue.Consider)
          {
             

              notKeyProperties.Remove("ClaimValue");
          }
                    
          #endregion

          #region IsDeleted

           if (!itemToSave.InfoSearchIsDeleted.Consider)
          {
             

              notKeyProperties.Remove("IsDeleted");
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
      private static string GenerateOrderByExpression(AbpRoleClaimsDto itemToSearch, string sortOrder)
      {
          string field = null;

          if (itemToSearch.InfoSearchId.IsOrderByField)
            field = "Id";
          if (itemToSearch.InfoSearchRoleId.IsOrderByField)
            field = "RoleId";
          if (itemToSearch.InfoSearchClaimType.IsOrderByField)
            field = "ClaimType";
          if (itemToSearch.InfoSearchClaimValue.IsOrderByField)
            field = "ClaimValue";
          if (itemToSearch.InfoSearchIsDeleted.IsOrderByField)
            field = "IsDeleted";
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
      private static string GenerateSumExpression(AbpRoleClaimsDto itemToSearch)
      {
          string field = null;

          if (itemToSearch.InfoSearchRoleId.IsSumField)
            field = "RoleId";                                         
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
      private AbpRoleClaimsDto GenerateSum(string criteria, object paramObj, AbpRoleClaimsDto itemToSearch, AbpRoleClaimsDto itemToReturn)
      {
        /* mis en commentaire par brice parceque le provider n'a pas transité par 
           Le generiprovider pour executer la requete
       //   if (itemToSearch.InfoSearchRoleId.IsSumField)
       //     itemToReturn.InfoSearchRoleId.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(RoleId) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
         //   if (itemToSearch.InfoSearchCreatedBy.IsSumField)
       //     itemToReturn.InfoSearchCreatedBy.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(CreatedBy) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
         //   if (itemToSearch.InfoSearchModifiedBy.IsSumField)
       //     itemToReturn.InfoSearchModifiedBy.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(ModifiedBy) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
            */
          return itemToReturn;
      }

      #endregion

        #region Create, Update, Delete
      
        public async Task<BusinessResponse<AbpRoleClaimsDto>> SaveAbpRoleClaims(BusinessRequest<AbpRoleClaimsDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<AbpRoleClaimsDto>();
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
         public async Task< BusinessResponse<Boolean>> DeleteAbpRoleClaims(BusinessRequest<AbpRoleClaimsDto> request, GenericProvider provider = null)
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
      private void FormatItemsToSave(List<AbpRoleClaimsDto> itemsToSave, List<AbpRoleClaimsDto> itemsToInsert,
          List<AbpRoleClaimsDto> itemsToUpdate, long idCurrentUser, short idCurrentStructure, string dataKey)
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
       
      private async void FormatItemsToDelete(List<AbpRoleClaimsDto> itemsToSave, List<AbpRoleClaimsDto> itemsToDelete, long idCurrentUser, short idCurrentStructure, string dataKey)
      {
          foreach (var entity in itemsToSave)
          {
              entity.DateMaj = Utilities.CurrentDate; 
              entity.ModifiedBy = idCurrentUser;
              entity.DataKey = dataKey; 
                            

              //Recherche de l'existance du item a supprimer
              var responseItem = await this.GetAbpRoleClaimsById(entity.Id);
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

