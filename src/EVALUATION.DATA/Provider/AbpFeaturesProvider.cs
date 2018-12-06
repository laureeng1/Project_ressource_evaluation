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
  public partial class AbpFeaturesProvider : ProviderBase
  {
        #region Singleton
   
        private const string _tableName = "dbo.AbpFeatures";

        private readonly List<string> _keyProperties = new List<string>
        {
          "Id",
        };

        private readonly List<string> _notKeyProperties = new List<string>
        {
          "Name",
          "Value",
          "CreationTime",
          "CreatorUserId",
          "EditionId",
          "Discriminator",
          "IsDeleted",
          "DateCreation",
          "DateMaj",
          "CreatedBy",
          "ModifiedBy",
          "DataKey",
          "IdTenant",
        };
        
        private static AbpFeaturesProvider _instance;
    
        public static AbpFeaturesProvider Instance
        {
            get { return _instance ?? (_instance = new AbpFeaturesProvider()); }
        }

        public AbpFeaturesProvider()
        {
        }
    
        #endregion

        #region Read

      public async Task<BusinessResponse<AbpFeaturesDto>> GetAbpFeaturesById(object id, GenericProvider provider = null)
      {
          var response = new BusinessResponse<AbpFeaturesDto>();

          try
          {

        		if (provider != null) provider.CloseConnetionAutomaticaly = false;
        		  provider = provider??new GenericProvider();
        
              var item = await provider.GetItemByIdAsync<AbpFeaturesDto>(id, _tableName, _keyProperties.First());
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
        public async Task<BusinessResponse<AbpFeaturesDto>> GetAbpFeaturesByCriteria(BusinessRequest<AbpFeaturesDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<AbpFeaturesDto>();
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
        public async Task<BusinessResponse<decimal>> GetSumAbpFeaturesByCriteria(BusinessRequest<AbpFeaturesDto> request, GenericProvider provider = null)
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
        private string GetWhereExpression(AbpFeaturesDto itemToSearch, short suffix, ref IDictionary<string, object> dictionary, bool isMainCriteria = false) 
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

          #region Name
          if (itemToSearch.InfoSearchName.Consider)
          {
                lstCriteria.AddWhereExpression("Name", itemToSearch.Name, "string", itemToSearch.InfoSearchName.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region Value
          if (itemToSearch.InfoSearchValue.Consider)
          {
                lstCriteria.AddWhereExpression("Value", itemToSearch.Value, "string", itemToSearch.InfoSearchValue.OperatorToUse, suffix, ref dictionary);
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
              lstCriteria.AddWhereExpression("CreationTime", itemToSearch.CreationTime.ToShortDateString(), "global::System.DateTime", itemToSearch.InfoSearchCreationTime.OperatorToUse, suffix, ref dictionary, debut, fin);
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

          #region EditionId
          if (itemToSearch.InfoSearchEditionId.Consider)
          {
              var debut = itemToSearch.InfoSearchEditionId.Intervalle != null
                  ? (object) itemToSearch.InfoSearchEditionId.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchEditionId.Intervalle != null
                  ? (object) itemToSearch.InfoSearchEditionId.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("EditionId", itemToSearch.EditionId, "global::System.Nullable<int>", itemToSearch.InfoSearchEditionId.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region Discriminator
          if (itemToSearch.InfoSearchDiscriminator.Consider)
          {
                lstCriteria.AddWhereExpression("Discriminator", itemToSearch.Discriminator, "string", itemToSearch.InfoSearchDiscriminator.OperatorToUse, suffix, ref dictionary);
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
        private string GetTableUpdateExpression(AbpFeaturesDto itemToSave, List<string> keyProperties, List<string> notKeyProperties) 
        {
                                                             
          #region Id

           if (!itemToSave.InfoSearchId.Consider)
          {
             

              notKeyProperties.Remove("Id");
          }
                    
          #endregion

          #region Name

           if (!itemToSave.InfoSearchName.Consider)
          {
             

              notKeyProperties.Remove("Name");
          }
                    
          #endregion

          #region Value

           if (!itemToSave.InfoSearchValue.Consider)
          {
             

              notKeyProperties.Remove("Value");
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

          #region EditionId

           if (!itemToSave.InfoSearchEditionId.Consider)
          {
             

              notKeyProperties.Remove("EditionId");
          }
                    
          #endregion

          #region Discriminator

           if (!itemToSave.InfoSearchDiscriminator.Consider)
          {
             

              notKeyProperties.Remove("Discriminator");
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
      private static string GenerateOrderByExpression(AbpFeaturesDto itemToSearch, string sortOrder)
      {
          string field = null;

          if (itemToSearch.InfoSearchId.IsOrderByField)
            field = "Id";
          if (itemToSearch.InfoSearchName.IsOrderByField)
            field = "Name";
          if (itemToSearch.InfoSearchValue.IsOrderByField)
            field = "Value";
          if (itemToSearch.InfoSearchCreationTime.IsOrderByField)
            field = "CreationTime";
          if (itemToSearch.InfoSearchCreatorUserId.IsOrderByField)
            field = "CreatorUserId";
          if (itemToSearch.InfoSearchEditionId.IsOrderByField)
            field = "EditionId";
          if (itemToSearch.InfoSearchDiscriminator.IsOrderByField)
            field = "Discriminator";
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
      private static string GenerateSumExpression(AbpFeaturesDto itemToSearch)
      {
          string field = null;

          if (itemToSearch.InfoSearchCreatorUserId.IsSumField)
            field = "CreatorUserId";                                         
            if (itemToSearch.InfoSearchEditionId.IsSumField)
            field = "EditionId";                                         
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
      private AbpFeaturesDto GenerateSum(string criteria, object paramObj, AbpFeaturesDto itemToSearch, AbpFeaturesDto itemToReturn)
      {
        /* mis en commentaire par brice parceque le provider n'a pas transité par 
           Le generiprovider pour executer la requete
       //   if (itemToSearch.InfoSearchCreatorUserId.IsSumField)
       //     itemToReturn.InfoSearchCreatorUserId.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(CreatorUserId) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
         //   if (itemToSearch.InfoSearchEditionId.IsSumField)
       //     itemToReturn.InfoSearchEditionId.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(EditionId) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
         //   if (itemToSearch.InfoSearchCreatedBy.IsSumField)
       //     itemToReturn.InfoSearchCreatedBy.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(CreatedBy) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
         //   if (itemToSearch.InfoSearchModifiedBy.IsSumField)
       //     itemToReturn.InfoSearchModifiedBy.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(ModifiedBy) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
            */
          return itemToReturn;
      }

      #endregion

        #region Create, Update, Delete
      
        public async Task<BusinessResponse<AbpFeaturesDto>> SaveAbpFeatures(BusinessRequest<AbpFeaturesDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<AbpFeaturesDto>();
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
         public async Task< BusinessResponse<Boolean>> DeleteAbpFeatures(BusinessRequest<AbpFeaturesDto> request, GenericProvider provider = null)
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
      private void FormatItemsToSave(List<AbpFeaturesDto> itemsToSave, List<AbpFeaturesDto> itemsToInsert,
          List<AbpFeaturesDto> itemsToUpdate, long idCurrentUser, short idCurrentStructure, string dataKey)
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
       
      private async void FormatItemsToDelete(List<AbpFeaturesDto> itemsToSave, List<AbpFeaturesDto> itemsToDelete, long idCurrentUser, short idCurrentStructure, string dataKey)
      {
          foreach (var entity in itemsToSave)
          {
              entity.DateMaj = Utilities.CurrentDate; 
              entity.ModifiedBy = idCurrentUser;
              entity.DataKey = dataKey; 
                            

              //Recherche de l'existance du item a supprimer
              var responseItem = await this.GetAbpFeaturesById(entity.Id);
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

