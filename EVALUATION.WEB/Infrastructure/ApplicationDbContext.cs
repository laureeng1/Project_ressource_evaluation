using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Admin.Common.Configuration;
using EVALUATION.DATA;

namespace EVALUATION.WEB.Infrastructure
{
    public class ApplicationDbContext: DbManager
    {
        public ApplicationDbContext(string connectionName)
            : base(connectionName)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext(WebConfigApplicationFactory.GetWebConfigApplication().CoreConnexionString);
        }
    }
}