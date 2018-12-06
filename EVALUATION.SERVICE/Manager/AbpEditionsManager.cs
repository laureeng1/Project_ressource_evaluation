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
    public partial class AbpEditionsManager
    {

        AbpEditionsProvider _AbpEditionsProvider;

        #region Singleton

        public AbpEditionsManager() 
        { 
          _AbpEditionsProvider = new AbpEditionsProvider();
        }
        
        /*
        private static AbpEditionsManager _instance;

        public static AbpEditionsManager Instance
        {
            get { return _instance ?? (_instance = new AbpEditionsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpEditionsDto>> GetAbpEditionsById(object id)
        {
            return await _AbpEditionsProvider.GetAbpEditionsById(id);
        }
        public async Task<BusinessResponse<AbpEditionsDto>> GetAbpEditionsByCriteria(BusinessRequest<AbpEditionsDto> request)
        {
            return await _AbpEditionsProvider.GetAbpEditionsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpEditionsDto>> SaveAbpEditions(BusinessRequest<AbpEditionsDto> request)
        {
            var response = new BusinessResponse<AbpEditionsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _AbpEditionsProvider.SaveAbpEditions(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpEditions(BusinessRequest<AbpEditionsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpEditionsProvider.DeleteAbpEditions(request);

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

