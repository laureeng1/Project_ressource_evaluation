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
using EVALUATION.DATA.SpProvider;

namespace EVALUATION.SERVICE.Manager
{
    public partial class AbpUsersManager
    {

        AbpUsersProvider _AbpUsersProvider;

        #region Singleton

        public AbpUsersManager()
        {
            _AbpUsersProvider = new AbpUsersProvider();
        }


        //private static AbpUsersManager _instance;

        //public static AbpUsersManager Instance
        //{
        //    get { return _instance ?? (_instance = new AbpUsersManager()); }
        //}
        
        #endregion

        public async Task<BusinessResponse<AbpUsersDto>> GetAbpUsersById(object id)
        {
            return await _AbpUsersProvider.GetAbpUsersById(id);
        }
        public async Task<BusinessResponse<AbpUsersDto>> GetAbpUsersByCriteria(BusinessRequest<AbpUsersDto> request)
        {
            return await _AbpUsersProvider.GetAbpUsersByCriteria(request);
        }


        public async Task<BusinessResponse<AbpUsersDto>> SaveAbpUsers(BusinessRequest<AbpUsersDto> request)
        {
            var response = new BusinessResponse<AbpUsersDto>();           
            {
                TransactionQueueManager.BeginWork(request, response);                    
                try
                {
                    /*** Commencer la logique ici ***/               
                    response = await _AbpUsersProvider.SaveAbpUsers(request);
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

        public async Task<BusinessResponse<Boolean>> DeleteAbpUsers(BusinessRequest<AbpUsersDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpUsersProvider.DeleteAbpUsers(request);

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

