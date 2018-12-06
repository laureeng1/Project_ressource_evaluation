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
  public partial class ProjectTaskActionsProvider : ProviderBase
  {
        #region Singleton
   
        private const string _tableName = "dbo.ProjectTaskActions";

        private readonly List<string> _keyProperties = new List<string>
        {
          "Id",
        };

        private readonly List<string> _notKeyProperties = new List<string>
        {
          "IdProjectTask",
          "Description",
          "Overtime",
          "OvertimeTime",
          "NewDeadline",
          "ActionType",
          "Duration",
          "DurationTime",
          "ActionDate",
          "DateOfDay",
          "IsDeleted",
          "DateCreation",
          "DateMaj",
          "CreatedBy",
          "ModifiedBy",
          "DataKey",
          "IdTenant",
        };
        
        private static ProjectTaskActionsProvider _instance;
    
        public static ProjectTaskActionsProvider Instance
        {
            get { return _instance ?? (_instance = new ProjectTaskActionsProvider()); }
        }

        public ProjectTaskActionsProvider()
        {
        }
    
        #endregion

        #region Read

      public async Task<BusinessResponse<ProjectTaskActionsDto>> GetProjectTaskActionsById(object id, GenericProvider provider = null)
      {
          var response = new BusinessResponse<ProjectTaskActionsDto>();

          try
          {

        		if (provider != null) provider.CloseConnetionAutomaticaly = false;
        		  provider = provider??new GenericProvider();
        
              var item = await provider.GetItemByIdAsync<ProjectTaskActionsDto>(id, _tableName, _keyProperties.First());
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
        public async Task<BusinessResponse<ProjectTaskActionsDto>> GetProjectTaskActionsByCriteria(BusinessRequest<ProjectTaskActionsDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<ProjectTaskActionsDto>();
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
        public async Task<BusinessResponse<decimal>> GetSumProjectTaskActionsByCriteria(BusinessRequest<ProjectTaskActionsDto> request, GenericProvider provider = null)
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
        private string GetWhereExpression(ProjectTaskActionsDto itemToSearch, short suffix, ref IDictionary<string, object> dictionary, bool isMainCriteria = false) 
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

          #region IdProjectTask
          if (itemToSearch.InfoSearchIdProjectTask.Consider)
          {
              var debut = itemToSearch.InfoSearchIdProjectTask.Intervalle != null
                  ? (object) itemToSearch.InfoSearchIdProjectTask.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchIdProjectTask.Intervalle != null
                  ? (object) itemToSearch.InfoSearchIdProjectTask.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("IdProjectTask", itemToSearch.IdProjectTask, "long", itemToSearch.InfoSearchIdProjectTask.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region Description
          if (itemToSearch.InfoSearchDescription.Consider)
          {
                lstCriteria.AddWhereExpression("Description", itemToSearch.Description, "string", itemToSearch.InfoSearchDescription.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region Overtime
          if (itemToSearch.InfoSearchOvertime.Consider)
          {
              var debut = itemToSearch.InfoSearchOvertime.Intervalle != null
                  ? (object) itemToSearch.InfoSearchOvertime.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchOvertime.Intervalle != null
                  ? (object) itemToSearch.InfoSearchOvertime.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("Overtime", itemToSearch.Overtime, "global::System.Nullable<double>", itemToSearch.InfoSearchOvertime.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region OvertimeTime
          #endregion

          #region NewDeadline
          if (itemToSearch.InfoSearchNewDeadline.Consider)
          {
              var debut = itemToSearch.InfoSearchNewDeadline.Intervalle != null
                  ? (object) itemToSearch.InfoSearchNewDeadline.Intervalle.Debut.ToShortDateString()
                  :  null;
              var fin = itemToSearch.InfoSearchNewDeadline.Intervalle != null
                  ? (object) itemToSearch.InfoSearchNewDeadline.Intervalle.Fin.ToShortDateString()
                  :  null;
              lstCriteria.AddWhereExpression("NewDeadline", itemToSearch.NewDeadline.Value.ToShortDateString(), "global::System.Nullable<System.DateTime>", itemToSearch.InfoSearchNewDeadline.OperatorToUse, suffix, ref dictionary,  debut, fin);
          }              

          #endregion

          #region ActionType
          if (itemToSearch.InfoSearchActionType.Consider)
          {
                lstCriteria.AddWhereExpression("ActionType", itemToSearch.ActionType, "string", itemToSearch.InfoSearchActionType.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region Duration
          if (itemToSearch.InfoSearchDuration.Consider)
          {
              var debut = itemToSearch.InfoSearchDuration.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDuration.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchDuration.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDuration.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("Duration", itemToSearch.Duration, "global::System.Nullable<double>", itemToSearch.InfoSearchDuration.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region DurationTime
          #endregion

          #region ActionDate
          if (itemToSearch.InfoSearchActionDate.Consider)
          {
              var debut = itemToSearch.InfoSearchActionDate.Intervalle != null
                  ? (object) itemToSearch.InfoSearchActionDate.Intervalle.Debut.ToShortDateString()
                  :  null;
              var fin = itemToSearch.InfoSearchActionDate.Intervalle != null
                  ? (object) itemToSearch.InfoSearchActionDate.Intervalle.Fin.ToShortDateString()
                  :  null;
              lstCriteria.AddWhereExpression("ActionDate", itemToSearch.ActionDate.Value.ToShortDateString(), "global::System.Nullable<System.DateTime>", itemToSearch.InfoSearchActionDate.OperatorToUse, suffix, ref dictionary,  debut, fin);
          }              

          #endregion

          #region DateOfDay
          if (itemToSearch.InfoSearchDateOfDay.Consider)
          {
              var debut = itemToSearch.InfoSearchDateOfDay.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDateOfDay.Intervalle.Debut.ToShortDateString()
                  :  null;
              var fin = itemToSearch.InfoSearchDateOfDay.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDateOfDay.Intervalle.Fin.ToShortDateString()
                  :  null;
              lstCriteria.AddWhereExpression("DateOfDay", itemToSearch.DateOfDay.Value.ToShortDateString(), "global::System.Nullable<System.DateTime>", itemToSearch.InfoSearchDateOfDay.OperatorToUse, suffix, ref dictionary,  debut, fin);
          }              

          #endregion

          #region IsDeleted
          if (itemToSearch.InfoSearchIsDeleted.Consider)
          {
                lstCriteria.AddWhereExpression("IsDeleted", itemToSearch.IsDeleted, "global::System.Nullable<bool>", itemToSearch.InfoSearchIsDeleted.OperatorToUse, suffix, ref dictionary);
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
              lstCriteria.AddWhereExpression("IdTenant", itemToSearch.IdTenant, "global::System.Nullable<int>", itemToSearch.InfoSearchIdTenant.OperatorToUse, suffix, ref dictionary, debut, fin);
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
        private string GetTableUpdateExpression(ProjectTaskActionsDto itemToSave, List<string> keyProperties, List<string> notKeyProperties) 
        {
                                                             
          #region Id

           if (!itemToSave.InfoSearchId.Consider)
          {
             

              notKeyProperties.Remove("Id");
          }
                    
          #endregion

          #region IdProjectTask

           if (!itemToSave.InfoSearchIdProjectTask.Consider)
          {
             

              notKeyProperties.Remove("IdProjectTask");
          }
                    
          #endregion

          #region Description

           if (!itemToSave.InfoSearchDescription.Consider)
          {
             

              notKeyProperties.Remove("Description");
          }
                    
          #endregion

          #region Overtime

           if (!itemToSave.InfoSearchOvertime.Consider)
          {
             

              notKeyProperties.Remove("Overtime");
          }
                    
          #endregion

          #region OvertimeTime

           if (!itemToSave.InfoSearchOvertimeTime.Consider)
          {
             

              notKeyProperties.Remove("OvertimeTime");
          }
                    
          #endregion

          #region NewDeadline

           if (!itemToSave.InfoSearchNewDeadline.Consider)
          {
             

              notKeyProperties.Remove("NewDeadline");
          }
                    
          #endregion

          #region ActionType

           if (!itemToSave.InfoSearchActionType.Consider)
          {
             

              notKeyProperties.Remove("ActionType");
          }
                    
          #endregion

          #region Duration

           if (!itemToSave.InfoSearchDuration.Consider)
          {
             

              notKeyProperties.Remove("Duration");
          }
                    
          #endregion

          #region DurationTime

           if (!itemToSave.InfoSearchDurationTime.Consider)
          {
             

              notKeyProperties.Remove("DurationTime");
          }
                    
          #endregion

          #region ActionDate

           if (!itemToSave.InfoSearchActionDate.Consider)
          {
             

              notKeyProperties.Remove("ActionDate");
          }
                    
          #endregion

          #region DateOfDay

           if (!itemToSave.InfoSearchDateOfDay.Consider)
          {
             

              notKeyProperties.Remove("DateOfDay");
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
      private static string GenerateOrderByExpression(ProjectTaskActionsDto itemToSearch, string sortOrder)
      {
          string field = null;

          if (itemToSearch.InfoSearchId.IsOrderByField)
            field = "Id";
          if (itemToSearch.InfoSearchIdProjectTask.IsOrderByField)
            field = "IdProjectTask";
          if (itemToSearch.InfoSearchDescription.IsOrderByField)
            field = "Description";
          if (itemToSearch.InfoSearchOvertime.IsOrderByField)
            field = "Overtime";
          if (itemToSearch.InfoSearchOvertimeTime.IsOrderByField)
            field = "OvertimeTime";
          if (itemToSearch.InfoSearchNewDeadline.IsOrderByField)
            field = "NewDeadline";
          if (itemToSearch.InfoSearchActionType.IsOrderByField)
            field = "ActionType";
          if (itemToSearch.InfoSearchDuration.IsOrderByField)
            field = "Duration";
          if (itemToSearch.InfoSearchDurationTime.IsOrderByField)
            field = "DurationTime";
          if (itemToSearch.InfoSearchActionDate.IsOrderByField)
            field = "ActionDate";
          if (itemToSearch.InfoSearchDateOfDay.IsOrderByField)
            field = "DateOfDay";
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
      private static string GenerateSumExpression(ProjectTaskActionsDto itemToSearch)
      {
          string field = null;

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
      private ProjectTaskActionsDto GenerateSum(string criteria, object paramObj, ProjectTaskActionsDto itemToSearch, ProjectTaskActionsDto itemToReturn)
      {
        /* mis en commentaire par brice parceque le provider n'a pas transité par 
           Le generiprovider pour executer la requete
       //   if (itemToSearch.InfoSearchCreatedBy.IsSumField)
       //     itemToReturn.InfoSearchCreatedBy.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(CreatedBy) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
         //   if (itemToSearch.InfoSearchModifiedBy.IsSumField)
       //     itemToReturn.InfoSearchModifiedBy.Sum = Connexion.Instance.Query<decimal>(string.Format("SELECT SUM(ModifiedBy) FROM {0} {1} ", _tableName, criteria), paramObj).Single();
                                        
            */
          return itemToReturn;
      }

      #endregion

        #region Create, Update, Delete
      
        public async Task<BusinessResponse<ProjectTaskActionsDto>> SaveProjectTaskActions(BusinessRequest<ProjectTaskActionsDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<ProjectTaskActionsDto>();
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
         public async Task< BusinessResponse<Boolean>> DeleteProjectTaskActions(BusinessRequest<ProjectTaskActionsDto> request, GenericProvider provider = null)
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
      private void FormatItemsToSave(List<ProjectTaskActionsDto> itemsToSave, List<ProjectTaskActionsDto> itemsToInsert,
          List<ProjectTaskActionsDto> itemsToUpdate, long idCurrentUser, short idCurrentStructure, string dataKey)
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
       
      private async void FormatItemsToDelete(List<ProjectTaskActionsDto> itemsToSave, List<ProjectTaskActionsDto> itemsToDelete, long idCurrentUser, short idCurrentStructure, string dataKey)
      {
          foreach (var entity in itemsToSave)
          {
              entity.DateMaj = Utilities.CurrentDate; 
              entity.ModifiedBy = idCurrentUser;
              entity.DataKey = dataKey; 
                            

              //Recherche de l'existance du item a supprimer
              var responseItem = await this.GetProjectTaskActionsById(entity.Id);
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

