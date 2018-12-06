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
    public partial class AbpOrganizationUnitsManager
    {

        AbpOrganizationUnitsProvider _AbpOrganizationUnitsProvider;

        #region Singleton

        public AbpOrganizationUnitsManager() 
        { 
          _AbpOrganizationUnitsProvider = new AbpOrganizationUnitsProvider();
        }
        
        /*
        private static AbpOrganizationUnitsManager _instance;

        public static AbpOrganizationUnitsManager Instance
        {
            get { return _instance ?? (_instance = new AbpOrganizationUnitsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpOrganizationUnitsDto>> GetAbpOrganizationUnitsById(object id)
        {
            return await _AbpOrganizationUnitsProvider.GetAbpOrganizationUnitsById(id);
        }
        public async Task<BusinessResponse<AbpOrganizationUnitsDto>> GetAbpOrganizationUnitsByCriteria(BusinessRequest<AbpOrganizationUnitsDto> request)
        {
            return await _AbpOrganizationUnitsProvider.GetAbpOrganizationUnitsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpOrganizationUnitsDto>> SaveAbpOrganizationUnits(BusinessRequest<AbpOrganizationUnitsDto> request)
        {
            var response = new BusinessResponse<AbpOrganizationUnitsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _AbpOrganizationUnitsProvider.SaveAbpOrganizationUnits(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpOrganizationUnits(BusinessRequest<AbpOrganizationUnitsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpOrganizationUnitsProvider.DeleteAbpOrganizationUnits(request);

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

