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
    public partial class AbpFeaturesManager
    {

        AbpFeaturesProvider _AbpFeaturesProvider;

        #region Singleton

        public AbpFeaturesManager() 
        { 
          _AbpFeaturesProvider = new AbpFeaturesProvider();
        }
        
        /*
        private static AbpFeaturesManager _instance;

        public static AbpFeaturesManager Instance
        {
            get { return _instance ?? (_instance = new AbpFeaturesManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpFeaturesDto>> GetAbpFeaturesById(object id)
        {
            return await _AbpFeaturesProvider.GetAbpFeaturesById(id);
        }
        public async Task<BusinessResponse<AbpFeaturesDto>> GetAbpFeaturesByCriteria(BusinessRequest<AbpFeaturesDto> request)
        {
            return await _AbpFeaturesProvider.GetAbpFeaturesByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpFeaturesDto>> SaveAbpFeatures(BusinessRequest<AbpFeaturesDto> request)
        {
            var response = new BusinessResponse<AbpFeaturesDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _AbpFeaturesProvider.SaveAbpFeatures(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteAbpFeatures(BusinessRequest<AbpFeaturesDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpFeaturesProvider.DeleteAbpFeatures(request);

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

