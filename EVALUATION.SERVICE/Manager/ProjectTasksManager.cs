using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVALUATION.DATA.Provider;
using EVALUATION.CORE.Dto;
using Admin.Common.Domain;
using Admin.Common.Enum;
using Admin.Common.Helper;

namespace EVALUATION.SERVICE.Manager
{
    public partial class ProjectTasksManager
    {

        ProjectTasksProvider _ProjectTasksProvider;

        #region Singleton

        public ProjectTasksManager() 
        { 
          _ProjectTasksProvider = new ProjectTasksProvider();
        }
        
        /*
        private static ProjectTasksManager _instance;

        public static ProjectTasksManager Instance
        {
            get { return _instance ?? (_instance = new ProjectTasksManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<ProjectTasksDto>> GetProjectTasksById(object id)
        {
            return await _ProjectTasksProvider.GetProjectTasksById(id);
        }
        public async Task<BusinessResponse<ProjectTasksDto>> GetProjectTasksByCriteria(BusinessRequest<ProjectTasksDto> request)
        {
            return await _ProjectTasksProvider.GetProjectTasksByCriteria(request);
        }

        
        public async Task<BusinessResponse<ProjectTasksDto>> SaveProjectTasks(BusinessRequest<ProjectTasksDto> request)
        {
            var response = new BusinessResponse<ProjectTasksDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/
                    foreach (var item in request.ItemsToSave)
                    {
                        if (item.Sequence == null)
                        {
                            item.Sequence = "TASK-" + DateTime.Now.ToString();
                            // item.TimeRemaining = item.TimePlanned;
                        }
                    }

                    response = await _ProjectTasksProvider.SaveProjectTasks(request);

                    /*** Finir la logique ici ***/
                }
                catch (Exception ex)
                {
                    CustomException.Write(request, response, ex);                       
                }
                finally
                {
                    TransactionQueueManager.FinishWork(request, response);
                }
            }            

            return response;
        }     

        public async Task<BusinessResponse<Boolean>> DeleteProjectTasks(BusinessRequest<ProjectTasksDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _ProjectTasksProvider.DeleteProjectTasks(request);

                        /*** Finir la logique ici ***/
                    }
                    catch (Exception ex)
                    {
                        CustomException.Write(request, response, ex);                       
                    }
                    finally
                    {
                        TransactionQueueManager.FinishWork(request, response);
                    }
            }            

            return response;
        }  
    }
}

