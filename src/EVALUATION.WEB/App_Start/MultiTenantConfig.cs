using Admin.Common.Configuration;
using EVALUATION.CORE;
using EVALUATION.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;
using EVALUATION.SERVICE;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;

namespace EVALUATION.WEB
{
    public class MultiTenantApp
    {
        internal static readonly object Locker = new object();

        public async Task<Tenant> GetTenantBasedOnUrl(string urlHost)
        {
            if (String.IsNullOrEmpty(urlHost))
            {
                throw new ApplicationException(
                    "urlHost must be specified");
            }

            Tenant tenant = null;
           
            string cacheName = "all-tenants-cache-name";
            int cacheTimeOutSeconds = 30;

            List<Tenant> tenants = await
                new TCache<List<Tenant>>().Get(
                        cacheName, cacheTimeOutSeconds,
                        async () =>
                        {
                              List<Tenant> tenants1;
                              using (var context = new DbManager(WebConfigApplicationFactory.GetWebConfigApplication().CoreConnexionString))
                              {
                                  
                                  TenantStore _tenantstore = new TenantStore();
                                  var items =  await _tenantstore.GetAllTenant();
                                 

                                  tenants1 = items.Where(x=>x.DomainName!=null).ToList();
                                //Default tenant
                                //tenants1.Add(new Tenant { Id = 0, TenancyName = "HOST", DomainName = "mutuellecare.com", Default = true });
                                tenants1.Add(new Tenant { Id = 45, TenancyName = "HOST", DomainName = "sib.mutuellecare.com", Default = true });
                            }
                              return tenants1;
              });

            tenant = tenants.FirstOrDefault(x => x.DomainName.Replace("www", "").Trim().ToUpper().Equals(urlHost.Replace("www", "").Trim().ToUpper())) ??
                     tenants.FirstOrDefault(a => a.Default == true);




            if (tenant == null)
            {
                throw new ApplicationException
                    ("tenant not found based on URL, no default found");
            }
            return tenant;
        }
    }
}
