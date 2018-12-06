using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVALUATION.CORE;
using EVALUATION.SERVICE.Manager;
using Admin.Common.Domain;
using EVALUATION.CORE.Dto;

namespace EVALUATION.SERVICE
{
    public class TenantStore
    {
        public AbpTenantsManager _managerTenant = new AbpTenantsManager();
        
        /// <summary>
        /// Récuperer la liste des tenants
        /// </summary>
        /// <param name="tenant">Objet Tenant</param>
        /// <returns></returns>
        public async Task<IList<Tenant>> GetAllTenant()
        {
            var result = await _managerTenant.GetAbpTenantsByCriteria(new BusinessRequest<AbpTenantsDto>()
            {
                ItemToSearch = new AbpTenantsDto(),
                TakeAll = true
            });

            List<Tenant> tenants = new List<Tenant>();
            result.Items.ForEach(ctx => tenants.Add(new Tenant() { Name = ctx.Name, Id = ctx.IdTenant, TenancyName = ctx.TenancyName,DomainName = ctx.DomainName}));
            return tenants;
        }

    }
}
