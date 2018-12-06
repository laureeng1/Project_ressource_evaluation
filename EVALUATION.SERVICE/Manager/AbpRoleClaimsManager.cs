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
    public partial class AbpRoleClaimsManager
    {

        AbpRoleClaimsProvider _AbpRoleClaimsProvider;

        #region Singleton

        public AbpRoleClaimsManager() 
        { 
          _AbpRoleClaimsProvider = new AbpRoleClaimsProvider();
        }
        
        /*
        private static AbpRoleClaimsManager _instance;

        public static AbpRoleClaimsManager Instance
        {
            get { return _instance ?? (_instance = new AbpRoleClaimsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<AbpRoleClaimsDto>> GetAbpRoleClaimsById(object id)
        {
            return await _AbpRoleClaimsProvider.GetAbpRoleClaimsById(id);
        }
        public async Task<BusinessResponse<AbpRoleClaimsDto>> GetAbpRoleClaimsByCriteria(BusinessRequest<AbpRoleClaimsDto> request)
        {
            return await _AbpRoleClaimsProvider.GetAbpRoleClaimsByCriteria(request);
        }

        
        public async Task<BusinessResponse<AbpRoleClaimsDto>> SaveAbpRoleClaims(BusinessRequest<AbpRoleClaimsDto> request)
        {
            var response = new BusinessResponse<AbpRoleClaimsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/
                    
                    var role = request.ItemsToSave.FirstOrDefault();
                    if (role.AbpRoles.AbpRoleClaims != null)
                    {
                        //Get old role claims
                        var responseRoleOldClaims = await _AbpRoleClaimsProvider.GetAbpRoleClaimsByCriteria(
                            new BusinessRequest<AbpRoleClaimsDto>()
                            {
                                ItemToSearch = new AbpRoleClaimsDto()
                                {
                                    RoleId = role.RoleId
                                },
                                TakeAll = true
                            });
                        if (responseRoleOldClaims.HasError)
                            throw new Exception(responseRoleOldClaims.Message);
                        var listtemp = responseRoleOldClaims.Items;



                        foreach (var item in listtemp)
                        {
                            item.IsDeleted = true;
                           
                            role.AbpRoles.AbpRoleClaims.Add(item);

                        }
                        foreach (var item in role.AbpRoles.AbpRoleClaims)
                        {


                            item.RoleId = role.RoleId;
                            item.ClaimType = "Habilitation";
                           


                        }
                    }
                    response = await _AbpRoleClaimsProvider.SaveAbpRoleClaims(new BusinessRequest<AbpRoleClaimsDto>
                    {
                        ItemsToSave = role.AbpRoles.AbpRoleClaims,
                        IdCurrentUser = request.IdCurrentUser
                    });


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


        public async Task<BusinessResponse<AbpRoleClaimsDto>> SaveCustomAbpRoleClaims(BusinessRequest<AbpRolesDto> request)
        {
            var response = new BusinessResponse<AbpRoleClaimsDto>();

            {
                TransactionQueueManager.BeginWork(request, response);

                try
                {
                    /*** Commencer la logique ici ***/

                    var role = request.ItemsToSave.FirstOrDefault();
                    if (role.AbpRoleClaims.Count()>0)
                    {
                        //Get old role claims
                        var responseRoleOldClaims = await _AbpRoleClaimsProvider.GetAbpRoleClaimsByCriteria(
                            new BusinessRequest<AbpRoleClaimsDto>()
                            {
                                ItemToSearch = new AbpRoleClaimsDto()
                                {
                                    RoleId = role.RoleId
                                },
                                TakeAll = true
                            });
                        if (responseRoleOldClaims.HasError)
                            throw new Exception(responseRoleOldClaims.Message);
                        var listtemp = responseRoleOldClaims.Items;

                        foreach (var item in role.AbpRoleClaims)
                        {


                            item.RoleId = role.RoleId;
                            item.ClaimType = "Habilitation";


                        }

                        foreach (var item in listtemp)
                        {
                            item.IsDeleted = true;
                            //item.CodeAbpClaims = item.ClaimValue;
                            role.AbpRoleClaims.Add(item);

                        }
                   
                    }
                    response = await _AbpRoleClaimsProvider.SaveAbpRoleClaims(new BusinessRequest<AbpRoleClaimsDto>
                    {
                        ItemsToSave = role.AbpRoleClaims,
                        IdCurrentUser = request.IdCurrentUser
                    });


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

        public async Task<BusinessResponse<Boolean>> DeleteAbpRoleClaims(BusinessRequest<AbpRoleClaimsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _AbpRoleClaimsProvider.DeleteAbpRoleClaims(request);

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

