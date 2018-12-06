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
    public partial class ProjectTaskActionsManager
    {

        ProjectTaskActionsProvider _ProjectTaskActionsProvider;

        #region Singleton

        public ProjectTaskActionsManager() 
        { 
          _ProjectTaskActionsProvider = new ProjectTaskActionsProvider();
        }
        
        /*
        private static ProjectTaskActionsManager _instance;

        public static ProjectTaskActionsManager Instance
        {
            get { return _instance ?? (_instance = new ProjectTaskActionsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<ProjectTaskActionsDto>> GetProjectTaskActionsById(object id)
        {
            return await _ProjectTaskActionsProvider.GetProjectTaskActionsById(id);
        }
        public async Task<BusinessResponse<ProjectTaskActionsDto>> GetProjectTaskActionsByCriteria(BusinessRequest<ProjectTaskActionsDto> request)
        {
            return await _ProjectTaskActionsProvider.GetProjectTaskActionsByCriteria(request);
        }

        
        public async Task<BusinessResponse<ProjectTaskActionsDto>> SaveProjectTaskActions(BusinessRequest<ProjectTaskActionsDto> request)
        {
            var response = new BusinessResponse<ProjectTaskActionsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _ProjectTaskActionsProvider.SaveProjectTaskActions(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteProjectTaskActions(BusinessRequest<ProjectTaskActionsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _ProjectTaskActionsProvider.DeleteProjectTaskActions(request);

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

