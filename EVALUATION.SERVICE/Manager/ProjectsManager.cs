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
    public partial class ProjectsManager
    {

        ProjectsProvider _ProjectsProvider;

        #region Singleton

        public ProjectsManager() 
        { 
          _ProjectsProvider = new ProjectsProvider();
        }
        
        /*
        private static ProjectsManager _instance;

        public static ProjectsManager Instance
        {
            get { return _instance ?? (_instance = new ProjectsManager()); }
        }
        */
        #endregion

        public async Task<BusinessResponse<ProjectsDto>> GetProjectsById(object id)
        {
            return await _ProjectsProvider.GetProjectsById(id);
        }

        public async Task<BusinessResponse<ProjectsDto>> GetProjectsByCriteria(BusinessRequest<ProjectsDto> request)
        {
            return await _ProjectsProvider.GetProjectsByCriteria(request);
        }

        
        public async Task<BusinessResponse<ProjectsDto>> SaveProjects(BusinessRequest<ProjectsDto> request)
        {
            var response = new BusinessResponse<ProjectsDto>();
            
            {
                TransactionQueueManager.BeginWork(request, response);                    

                try
                {
                    /*** Commencer la logique ici ***/                                                    

                    response = await _ProjectsProvider.SaveProjects(request);

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

        public async Task<BusinessResponse<Boolean>> DeleteProjects(BusinessRequest<ProjectsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            {
                    TransactionQueueManager.BeginWork(request, response);                    

                    try
                    {
                        /*** Commencer la logique ici ***/                                                    

                        response = await _ProjectsProvider.DeleteProjects(request);

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


        public async Task<BusinessResponse<ProjectsDto>> DeleteCustomProjects(BusinessRequest<ProjectsDto> request)
        {
            var response = new BusinessResponse<ProjectsDto>();

            {
                TransactionQueueManager.BeginWork(request, response);

                try
                {
                    /*** Commencer la logique ici ***/
                    foreach (var item in request.ItemsToSave)
                    {
                        var getProjet = await _ProjectsProvider.GetProjectsByCriteria(new BusinessRequest<ProjectsDto>()
                        {
                            ItemToSearch = new ProjectsDto()
                            {
                                Id = item.Id
                            }
                        });
                        if (getProjet.HasError)
                            throw new Exception(getProjet.Message);

                        if (getProjet.Items.Any())
                        {
                            var itemToDelete = getProjet.Items.FirstOrDefault();
                            itemToDelete.IsDeleted = true;
                            response = await _ProjectsProvider.SaveProjects(new BusinessRequest<ProjectsDto>()
                            {
                                ItemsToSave = new List<ProjectsDto>() { itemToDelete },
                                IdCurrentUser = request.IdCurrentUser
                            });
                            if (response.HasError)
                                throw new Exception(response.Message);
                        }

                    }

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

