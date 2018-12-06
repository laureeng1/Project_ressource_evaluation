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
    public partial class vProjectTasksWithCollaboratorManager
    {

        vProjectTasksWithCollaboratorProvider _vProjectTasksWithCollaboratorProvider;

        #region Singleton

        public vProjectTasksWithCollaboratorManager() 
        { 
          _vProjectTasksWithCollaboratorProvider = new vProjectTasksWithCollaboratorProvider();
        }
        
        /*
        private static vProjectTasksWithCollaboratorManager _instance;

        public static vProjectTasksWithCollaboratorManager Instance
        {
            get { return _instance ?? (_instance = new vProjectTasksWithCollaboratorManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<vProjectTasksWithCollaboratorDto>> GetvProjectTasksWithCollaboratorById(object id)
        {
            return await _vProjectTasksWithCollaboratorProvider.GetvProjectTasksWithCollaboratorById(id);
        }
        public async Task<BusinessResponse<vProjectTasksWithCollaboratorDto>> GetvProjectTasksWithCollaboratorsByCriteria(BusinessRequest<vProjectTasksWithCollaboratorDto> request)
        {
            return await _vProjectTasksWithCollaboratorProvider.GetvProjectTasksWithCollaboratorsByCriteria(request);
        }

        
        public async Task<BusinessResponse<vProjectTasksWithCollaboratorDto>> SavevProjectTasksWithCollaborators(BusinessRequest<vProjectTasksWithCollaboratorDto> request)
        {
            var response = new BusinessResponse<vProjectTasksWithCollaboratorDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _vProjectTasksWithCollaboratorProvider.SavevProjectTasksWithCollaborators(request);

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

        public async Task<BusinessResponse<Boolean>> DeletevProjectTasksWithCollaborators(BusinessRequest<vProjectTasksWithCollaboratorDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _vProjectTasksWithCollaboratorProvider.DeletevProjectTasksWithCollaborators(request);

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

