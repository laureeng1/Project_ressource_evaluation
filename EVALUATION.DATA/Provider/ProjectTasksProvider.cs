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
  public partial class ProjectTasksProvider : ProviderBase
  {
        #region Singleton
   
        private const string _tableName = "dbo.ProjectTasks";

        private readonly List<string> _keyProperties = new List<string>
        {
          "Id",
        };

        private readonly List<string> _notKeyProperties = new List<string>
        {
          "IdProject",
          "IdCurrentCollaborator",
          "Sequence",
          "Label",
          "Priority",
          "TimePlanned",
          "TimePlannedTime",
          "TimeElapsed",
          "TimeElapsedVarchar",
          "TimeRemaining",
          "TimeRemainingVarchar",
          "DateStarted",
          "Deadline",
          "Status",
          "IsDeleted",
          "DateCreation",
          "DateMaj",
          "CreatedBy",
          "ModifiedBy",
          "DataKey",
          "IdTenant",
        };
        
        private static ProjectTasksProvider _instance;
    
        public static ProjectTasksProvider Instance
        {
            get { return _instance ?? (_instance = new ProjectTasksProvider()); }
        }

        public ProjectTasksProvider()
        {
        }
    
        #endregion

        #region Read

      public async Task<BusinessResponse<ProjectTasksDto>> GetProjectTasksById(object id, GenericProvider provider = null)
      {
          var response = new BusinessResponse<ProjectTasksDto>();

          try
          {

        		if (provider != null) provider.CloseConnetionAutomaticaly = false;
        		  provider = provider??new GenericProvider();
        
              var item = await provider.GetItemByIdAsync<ProjectTasksDto>(id, _tableName, _keyProperties.First());
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
        public async Task<BusinessResponse<ProjectTasksDto>> GetProjectTasksByCriteria(BusinessRequest<ProjectTasksDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<ProjectTasksDto>();
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
        public async Task<BusinessResponse<decimal>> GetSumProjectTasksByCriteria(BusinessRequest<ProjectTasksDto> request, GenericProvider provider = null)
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
        private string GetWhereExpression(ProjectTasksDto itemToSearch, short suffix, ref IDictionary<string, object> dictionary, bool isMainCriteria = false) 
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

          #region IdProject
          if (itemToSearch.InfoSearchIdProject.Consider)
          {
              var debut = itemToSearch.InfoSearchIdProject.Intervalle != null
                  ? (object) itemToSearch.InfoSearchIdProject.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchIdProject.Intervalle != null
                  ? (object) itemToSearch.InfoSearchIdProject.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("IdProject", itemToSearch.IdProject, "long", itemToSearch.InfoSearchIdProject.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region IdCurrentCollaborator
          if (itemToSearch.InfoSearchIdCurrentCollaborator.Consider)
          {
              var debut = itemToSearch.InfoSearchIdCurrentCollaborator.Intervalle != null
                  ? (object) itemToSearch.InfoSearchIdCurrentCollaborator.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchIdCurrentCollaborator.Intervalle != null
                  ? (object) itemToSearch.InfoSearchIdCurrentCollaborator.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("IdCurrentCollaborator", itemToSearch.IdCurrentCollaborator, "long", itemToSearch.InfoSearchIdCurrentCollaborator.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region Sequence
          if (itemToSearch.InfoSearchSequence.Consider)
          {
                lstCriteria.AddWhereExpression("Sequence", itemToSearch.Sequence, "string", itemToSearch.InfoSearchSequence.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region Label
          if (itemToSearch.InfoSearchLabel.Consider)
          {
                lstCriteria.AddWhereExpression("Label", itemToSearch.Label, "string", itemToSearch.InfoSearchLabel.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region Priority
          if (itemToSearch.InfoSearchPriority.Consider)
          {
                lstCriteria.AddWhereExpression("Priority", itemToSearch.Priority, "string", itemToSearch.InfoSearchPriority.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region TimePlanned
          if (itemToSearch.InfoSearchTimePlanned.Consider)
          {
              var debut = itemToSearch.InfoSearchTimePlanned.Intervalle != null
                  ? (object) itemToSearch.InfoSearchTimePlanned.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchTimePlanned.Intervalle != null
                  ? (object) itemToSearch.InfoSearchTimePlanned.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("TimePlanned", itemToSearch.TimePlanned, "global::System.Nullable<double>", itemToSearch.InfoSearchTimePlanned.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region TimePlannedTime
          #endregion

          #region TimeElapsed
          if (itemToSearch.InfoSearchTimeElapsed.Consider)
          {
              var debut = itemToSearch.InfoSearchTimeElapsed.Intervalle != null
                  ? (object) itemToSearch.InfoSearchTimeElapsed.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchTimeElapsed.Intervalle != null
                  ? (object) itemToSearch.InfoSearchTimeElapsed.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("TimeElapsed", itemToSearch.TimeElapsed, "global::System.Nullable<double>", itemToSearch.InfoSearchTimeElapsed.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region TimeElapsedVarchar
          if (itemToSearch.InfoSearchTimeElapsedVarchar.Consider)
          {
                lstCriteria.AddWhereExpression("TimeElapsedVarchar", itemToSearch.TimeElapsedVarchar, "string", itemToSearch.InfoSearchTimeElapsedVarchar.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region TimeRemaining
          if (itemToSearch.InfoSearchTimeRemaining.Consider)
          {
              var debut = itemToSearch.InfoSearchTimeRemaining.Intervalle != null
                  ? (object) itemToSearch.InfoSearchTimeRemaining.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchTimeRemaining.Intervalle != null
                  ? (object) itemToSearch.InfoSearchTimeRemaining.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("TimeRemaining", itemToSearch.TimeRemaining, "global::System.Nullable<double>", itemToSearch.InfoSearchTimeRemaining.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region TimeRemainingVarchar
          if (itemToSearch.InfoSearchTimeRemainingVarchar.Consider)
          {
                lstCriteria.AddWhereExpression("TimeRemainingVarchar", itemToSearch.TimeRemainingVarchar, "string", itemToSearch.InfoSearchTimeRemainingVarchar.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region DateStarted
          if (itemToSearch.InfoSearchDateStarted.Consider)
          {
              var debut = itemToSearch.InfoSearchDateStarted.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDateStarted.Intervalle.Debut.ToShortDateString()
                  :  null;
              var fin = itemToSearch.InfoSearchDateStarted.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDateStarted.Intervalle.Fin.ToShortDateString()
                  :  null;
              lstCriteria.AddWhereExpression("DateStarted", itemToSearch.DateStarted.Value.ToShortDateString(), "global::System.Nullable<System.DateTime>", itemToSearch.InfoSearchDateStarted.OperatorToUse, suffix, ref dictionary,  debut, fin);
          }              

          #endregion

          #region Deadline
          if (itemToSearch.InfoSearchDeadline.Consider)
          {
              var debut = itemToSearch.InfoSearchDeadline.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDeadline.Intervalle.Debut.ToShortDateString()
                  :  null;
              var fin = itemToSearch.InfoSearchDeadline.Intervalle != null
                  ? (object) itemToSearch.InfoSearchDeadline.Intervalle.Fin.ToShortDateString()
                  :  null;
              lstCriteria.AddWhereExpression("Deadline", itemToSearch.Deadline.Value.ToShortDateString(), "global::System.Nullable<System.DateTime>", itemToSearch.InfoSearchDeadline.OperatorToUse, suffix, ref dictionary,  debut, fin);
          }              

          #endregion

          #region Status
          if (itemToSearch.InfoSearchStatus.Consider)
          {
                lstCriteria.AddWhereExpression("Status", itemToSearch.Status, "string", itemToSearch.InfoSearchStatus.OperatorToUse, suffix, ref dictionary);
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
        private string GetTableUpdateExpression(ProjectTasksDto itemToSave, List<string> keyProperties, List<string> notKeyProperties) 
        {
                                                             
          #region Id

           if (!itemToSave.InfoSearchId.Consider)
          {
             

              notKeyProperties.Remove("Id");
          }
                    
          #endregion

          #region IdProject

           if (!itemToSave.InfoSearchIdProject.Consider)
          {
             

              notKeyProperties.Remove("IdProject");
          }
                    
          #endregion

          #region IdCurrentCollaborator

           if (!itemToSave.InfoSearchIdCurrentCollaborator.Consider)
          {
             

              notKeyProperties.Remove("IdCurrentCollaborator");
          }
                    
          #endregion

          #region Sequence

           if (!itemToSave.InfoSearchSequence.Consider)
          {
             

              notKeyProperties.Remove("Sequence");
          }
                    
          #endregion

          #region Label

           if (!itemToSave.InfoSearchLabel.Consider)
          {
             

              notKeyProperties.Remove("Label");
          }
                    
          #endregion

          #region Priority

           if (!itemToSave.InfoSearchPriority.Consider)
          {
             

              notKeyProperties.Remove("Priority");
          }
                    
          #endregion

          #region TimePlanned

           if (!itemToSave.InfoSearchTimePlanned.Consider)
          {
             

              notKeyProperties.Remove("TimePlanned");
          }
                    
          #endregion

          #region TimePlannedTime

           if (!itemToSave.InfoSearchTimePlannedTime.Consider)
          {
             

              notKeyProperties.Remove("TimePlannedTime");
          }
                    
          #endregion

          #region TimeElapsed

           if (!itemToSave.InfoSearchTimeElapsed.Consider)
          {
             

              notKeyProperties.Remove("TimeElapsed");
          }
                    
          #endregion

          #region TimeElapsedVarchar

           if (!itemToSave.InfoSearchTimeElapsedVarchar.Consider)
          {
             

              notKeyProperties.Remove("TimeElapsedVarchar");
          }
                    
          #endregion

          #region TimeRemaining

           if (!itemToSave.InfoSearchTimeRemaining.Consider)
          {
             

              notKeyProperties.Remove("TimeRemaining");
          }
                    
          #endregion

          #region TimeRemainingVarchar

           if (!itemToSave.InfoSearchTimeRemainingVarchar.Consider)
          {
             

              notKeyProperties.Remove("TimeRemainingVarchar");
          }
                    
          #endregion

          #region DateStarted

           if (!itemToSave.InfoSearchDateStarted.Consider)
          {
             

              notKeyProperties.Remove("DateStarted");
          }
                    
          #endregion

          #region Deadline

           if (!itemToSave.InfoSearchDeadline.Consider)
          {
             

              notKeyProperties.Remove("Deadline");
          }
                    
          #endregion

          #region Status

           if (!itemToSave.InfoSearchStatus.Consider)
          {
             

              notKeyProperties.Remove("Status");
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
      private static string GenerateOrderByExpression(ProjectTasksDto itemToSearch, string sortOrder)
      {
          string field = null;

          if (itemToSearch.InfoSearchId.IsOrderByField)
            field = "Id";
          if (itemToSearch.InfoSearchIdProject.IsOrderByField)
            field = "IdProject";
          if (itemToSearch.InfoSearchIdCurrentCollaborator.IsOrderByField)
            field = "IdCurrentCollaborator";
          if (itemToSearch.InfoSearchSequence.IsOrderByField)
            field = "Sequence";
          if (itemToSearch.InfoSearchLabel.IsOrderByField)
            field = "Label";
          if (itemToSearch.InfoSearchPriority.IsOrderByField)
            field = "Priority";
          if (itemToSearch.InfoSearchTimePlanned.IsOrderByField)
            field = "TimePlanned";
          if (itemToSearch.InfoSearchTimePlannedTime.IsOrderByField)
            field = "TimePlannedTime";
          if (itemToSearch.InfoSearchTimeElapsed.IsOrderByField)
            field = "TimeElapsed";
          if (itemToSearch.InfoSearchTimeElapsedVarchar.IsOrderByField)
            field = "TimeElapsedVarchar";
          if (itemToSearch.InfoSearchTimeRemaining.IsOrderByField)
            field = "TimeRemaining";
          if (itemToSearch.InfoSearchTimeRemainingVarchar.IsOrderByField)
            field = "TimeRemainingVarchar";
          if (itemToSearch.InfoSearchDateStarted.IsOrderByField)
            field = "DateStarted";
          if (itemToSearch.InfoSearchDeadline.IsOrderByField)
            field = "Deadline";
          if (itemToSearch.InfoSearchStatus.IsOrderByField)
            field = "Status";
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
      private static string GenerateSumExpression(ProjectTasksDto itemToSearch)
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
      private ProjectTasksDto GenerateSum(string criteria, object paramObj, ProjectTasksDto itemToSearch, ProjectTasksDto itemToReturn)
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
      
        public async Task<BusinessResponse<ProjectTasksDto>> SaveProjectTasks(BusinessRequest<ProjectTasksDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<ProjectTasksDto>();
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
         public async Task< BusinessResponse<Boolean>> DeleteProjectTasks(BusinessRequest<ProjectTasksDto> request, GenericProvider provider = null)
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
      private void FormatItemsToSave(List<ProjectTasksDto> itemsToSave, List<ProjectTasksDto> itemsToInsert,
          List<ProjectTasksDto> itemsToUpdate, long idCurrentUser, short idCurrentStructure, string dataKey)
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
       
      private async void FormatItemsToDelete(List<ProjectTasksDto> itemsToSave, List<ProjectTasksDto> itemsToDelete, long idCurrentUser, short idCurrentStructure, string dataKey)
      {
          foreach (var entity in itemsToSave)
          {
              entity.DateMaj = Utilities.CurrentDate; 
              entity.ModifiedBy = idCurrentUser;
              entity.DataKey = dataKey; 
                            

              //Recherche de l'existance du item a supprimer
              var responseItem = await this.GetProjectTasksById(entity.Id);
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

