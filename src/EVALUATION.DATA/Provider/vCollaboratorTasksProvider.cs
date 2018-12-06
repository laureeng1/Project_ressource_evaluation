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
  public partial class vCollaboratorTasksProvider : ProviderBase
  {
        #region Singleton
   
        private const string _tableName = "dbo.vCollaboratorTasks";

        private readonly List<string> _keyProperties = new List<string>
        {
          "Id",
          "IdProject",
          "IdCurrentCollaborator",
          "Sequence",
          "ProjectName",
          "Label",
          "Status",
          "TimePlannedTime",
        };

        private readonly List<string> _notKeyProperties = new List<string>
        {
          "UserFullname",
          "Priority",
          "TimeElapsedVarchar",
          "TimeRemainingVarchar",
          "DateStarted",
          "Deadline",
          "Prolongation",
          "Bruit",
          "Note",
          "IsDeleted",
        };
        
        private static vCollaboratorTasksProvider _instance;
    
        public static vCollaboratorTasksProvider Instance
        {
            get { return _instance ?? (_instance = new vCollaboratorTasksProvider()); }
        }

        public vCollaboratorTasksProvider()
        {
        }
    
        #endregion

        #region Read

      public async Task<BusinessResponse<vCollaboratorTasksDto>> GetvCollaboratorTasksById(object id, GenericProvider provider = null)
      {
          var response = new BusinessResponse<vCollaboratorTasksDto>();

          try
          {

        		if (provider != null) provider.CloseConnetionAutomaticaly = false;
        		  provider = provider??new GenericProvider();
        
              var item = await provider.GetItemByIdAsync<vCollaboratorTasksDto>(id, _tableName, _keyProperties.First());
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
        public async Task<BusinessResponse<vCollaboratorTasksDto>> GetvCollaboratorTasksByCriteria(BusinessRequest<vCollaboratorTasksDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<vCollaboratorTasksDto>();
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
        public async Task<BusinessResponse<decimal>> GetSumvCollaboratorTasksByCriteria(BusinessRequest<vCollaboratorTasksDto> request, GenericProvider provider = null)
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
        private string GetWhereExpression(vCollaboratorTasksDto itemToSearch, short suffix, ref IDictionary<string, object> dictionary, bool isMainCriteria = false) 
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

          #region UserFullname
          if (itemToSearch.InfoSearchUserFullname.Consider)
          {
                lstCriteria.AddWhereExpression("UserFullname", itemToSearch.UserFullname, "string", itemToSearch.InfoSearchUserFullname.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region Sequence
          if (itemToSearch.InfoSearchSequence.Consider)
          {
                lstCriteria.AddWhereExpression("Sequence", itemToSearch.Sequence, "string", itemToSearch.InfoSearchSequence.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region ProjectName
          if (itemToSearch.InfoSearchProjectName.Consider)
          {
                lstCriteria.AddWhereExpression("ProjectName", itemToSearch.ProjectName, "string", itemToSearch.InfoSearchProjectName.OperatorToUse, suffix, ref dictionary);
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

          #region Status
          if (itemToSearch.InfoSearchStatus.Consider)
          {
                lstCriteria.AddWhereExpression("Status", itemToSearch.Status, "string", itemToSearch.InfoSearchStatus.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region TimePlannedTime
          #endregion

          #region TimeElapsedVarchar
          if (itemToSearch.InfoSearchTimeElapsedVarchar.Consider)
          {
                lstCriteria.AddWhereExpression("TimeElapsedVarchar", itemToSearch.TimeElapsedVarchar, "string", itemToSearch.InfoSearchTimeElapsedVarchar.OperatorToUse, suffix, ref dictionary);
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

          #region Prolongation
          if (itemToSearch.InfoSearchProlongation.Consider)
          {
                lstCriteria.AddWhereExpression("Prolongation", itemToSearch.Prolongation, "string", itemToSearch.InfoSearchProlongation.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region Bruit
          if (itemToSearch.InfoSearchBruit.Consider)
          {
                lstCriteria.AddWhereExpression("Bruit", itemToSearch.Bruit, "string", itemToSearch.InfoSearchBruit.OperatorToUse, suffix, ref dictionary);
          }                               
                 
          #endregion

          #region Note
          if (itemToSearch.InfoSearchNote.Consider)
          {
              var debut = itemToSearch.InfoSearchNote.Intervalle != null
                  ? (object) itemToSearch.InfoSearchNote.Intervalle.Debut
                  :  null;
              var fin = itemToSearch.InfoSearchNote.Intervalle != null
                  ? (object) itemToSearch.InfoSearchNote.Intervalle.Fin
                  :  null;
              lstCriteria.AddWhereExpression("Note", itemToSearch.Note, "global::System.Nullable<double>", itemToSearch.InfoSearchNote.OperatorToUse, suffix, ref dictionary, debut, fin);
          }              

          #endregion

          #region IsDeleted
          if (itemToSearch.InfoSearchIsDeleted.Consider)
          {
                lstCriteria.AddWhereExpression("IsDeleted", itemToSearch.IsDeleted, "global::System.Nullable<bool>", itemToSearch.InfoSearchIsDeleted.OperatorToUse, suffix, ref dictionary);
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
        private string GetTableUpdateExpression(vCollaboratorTasksDto itemToSave, List<string> keyProperties, List<string> notKeyProperties) 
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

          #region UserFullname

           if (!itemToSave.InfoSearchUserFullname.Consider)
          {
             

              notKeyProperties.Remove("UserFullname");
          }
                    
          #endregion

          #region Sequence

           if (!itemToSave.InfoSearchSequence.Consider)
          {
             

              notKeyProperties.Remove("Sequence");
          }
                    
          #endregion

          #region ProjectName

           if (!itemToSave.InfoSearchProjectName.Consider)
          {
             

              notKeyProperties.Remove("ProjectName");
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

          #region Status

           if (!itemToSave.InfoSearchStatus.Consider)
          {
             

              notKeyProperties.Remove("Status");
          }
                    
          #endregion

          #region TimePlannedTime

           if (!itemToSave.InfoSearchTimePlannedTime.Consider)
          {
             

              notKeyProperties.Remove("TimePlannedTime");
          }
                    
          #endregion

          #region TimeElapsedVarchar

           if (!itemToSave.InfoSearchTimeElapsedVarchar.Consider)
          {
             

              notKeyProperties.Remove("TimeElapsedVarchar");
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

          #region Prolongation

           if (!itemToSave.InfoSearchProlongation.Consider)
          {
             

              notKeyProperties.Remove("Prolongation");
          }
                    
          #endregion

          #region Bruit

           if (!itemToSave.InfoSearchBruit.Consider)
          {
             

              notKeyProperties.Remove("Bruit");
          }
                    
          #endregion

          #region Note

           if (!itemToSave.InfoSearchNote.Consider)
          {
             

              notKeyProperties.Remove("Note");
          }
                    
          #endregion

          #region IsDeleted

           if (!itemToSave.InfoSearchIsDeleted.Consider)
          {
             

              notKeyProperties.Remove("IsDeleted");
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
      private static string GenerateOrderByExpression(vCollaboratorTasksDto itemToSearch, string sortOrder)
      {
          string field = null;

          if (itemToSearch.InfoSearchId.IsOrderByField)
            field = "Id";
          if (itemToSearch.InfoSearchIdProject.IsOrderByField)
            field = "IdProject";
          if (itemToSearch.InfoSearchIdCurrentCollaborator.IsOrderByField)
            field = "IdCurrentCollaborator";
          if (itemToSearch.InfoSearchUserFullname.IsOrderByField)
            field = "UserFullname";
          if (itemToSearch.InfoSearchSequence.IsOrderByField)
            field = "Sequence";
          if (itemToSearch.InfoSearchProjectName.IsOrderByField)
            field = "ProjectName";
          if (itemToSearch.InfoSearchLabel.IsOrderByField)
            field = "Label";
          if (itemToSearch.InfoSearchPriority.IsOrderByField)
            field = "Priority";
          if (itemToSearch.InfoSearchStatus.IsOrderByField)
            field = "Status";
          if (itemToSearch.InfoSearchTimePlannedTime.IsOrderByField)
            field = "TimePlannedTime";
          if (itemToSearch.InfoSearchTimeElapsedVarchar.IsOrderByField)
            field = "TimeElapsedVarchar";
          if (itemToSearch.InfoSearchTimeRemainingVarchar.IsOrderByField)
            field = "TimeRemainingVarchar";
          if (itemToSearch.InfoSearchDateStarted.IsOrderByField)
            field = "DateStarted";
          if (itemToSearch.InfoSearchDeadline.IsOrderByField)
            field = "Deadline";
          if (itemToSearch.InfoSearchProlongation.IsOrderByField)
            field = "Prolongation";
          if (itemToSearch.InfoSearchBruit.IsOrderByField)
            field = "Bruit";
          if (itemToSearch.InfoSearchNote.IsOrderByField)
            field = "Note";
          if (itemToSearch.InfoSearchIsDeleted.IsOrderByField)
            field = "IsDeleted";
          var sqlSortOrder = (sortOrder == MySortOrder.Ascending) ? "ASC" : "DESC";

          return !string.IsNullOrEmpty(field) ? string.Format(" ORDER BY {0} {1}", field, sqlSortOrder) : string.Format(" ORDER BY {0} {1}", "Id", sqlSortOrder);
      }

      /// <summary>
      /// Générer une expression lambda à partir d'un DTO
      /// </summary>
      /// <param name="itemToSearch">objet DTO contenant les champs de recherche</param>
      /// <returns>Expression lambda</returns>
      private static string GenerateSumExpression(vCollaboratorTasksDto itemToSearch)
      {
          string field = null;

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
      private vCollaboratorTasksDto GenerateSum(string criteria, object paramObj, vCollaboratorTasksDto itemToSearch, vCollaboratorTasksDto itemToReturn)
      {
        /* mis en commentaire par brice parceque le provider n'a pas transité par 
           Le generiprovider pour executer la requete
          */
          return itemToReturn;
      }

      #endregion

        #region Create, Update, Delete
      
        public async Task<BusinessResponse<vCollaboratorTasksDto>> SavevCollaboratorTasks(BusinessRequest<vCollaboratorTasksDto> request, GenericProvider provider = null)
        {
        		var response = new BusinessResponse<vCollaboratorTasksDto>();
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
         public async Task< BusinessResponse<Boolean>> DeletevCollaboratorTasks(BusinessRequest<vCollaboratorTasksDto> request, GenericProvider provider = null)
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
      private void FormatItemsToSave(List<vCollaboratorTasksDto> itemsToSave, List<vCollaboratorTasksDto> itemsToInsert,
          List<vCollaboratorTasksDto> itemsToUpdate, long idCurrentUser, short idCurrentStructure, string dataKey)
      {
          foreach (var entity in itemsToSave)
          {
              //long
              if (entity.Id == 0)  
              {
                  entity.IsDeleted = false;
                  itemsToInsert.Add(entity);
              }
              else
              {
                  itemsToUpdate.Add(entity);
              }
          }
      }
       
      private async void FormatItemsToDelete(List<vCollaboratorTasksDto> itemsToSave, List<vCollaboratorTasksDto> itemsToDelete, long idCurrentUser, short idCurrentStructure, string dataKey)
      {
          foreach (var entity in itemsToSave)
          {
                            

              //Recherche de l'existance du item a supprimer
              var responseItem = await this.GetvCollaboratorTasksById(entity.Id);
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

