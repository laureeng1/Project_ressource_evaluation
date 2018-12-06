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
    public partial class RolesManager
    {

        RolesProvider _RolesProvider;

        #region Singleton

        public RolesManager() 
        { 
          _RolesProvider = new RolesProvider();
        }
        
        /*
        private static RolesManager _instance;

        public static RolesManager Instance
        {
            get { return _instance ?? (_instance = new RolesManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<RolesDto>> GetRolesById(object id)
        {
            return await _RolesProvider.GetRolesById(id);
        }
        public async Task<BusinessResponse<RolesDto>> GetRolesByCriteria(BusinessRequest<RolesDto> request)
        {
            return await _RolesProvider.GetRolesByCriteria(request);
        }

        
        public async Task<BusinessResponse<RolesDto>> SaveRoles(BusinessRequest<RolesDto> request)
        {
            var response = new BusinessResponse<RolesDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _RolesProvider.SaveRoles(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteRoles(BusinessRequest<RolesDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _RolesProvider.DeleteRoles(request);

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

