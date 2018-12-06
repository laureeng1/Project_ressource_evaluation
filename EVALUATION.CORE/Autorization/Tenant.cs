using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  EVALUATION.CORE

{
   public class Tenant
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public string Name { get; set; }

        public string TenancyName { get; set; }


        public string ConnectionString { get; set; }

        public string DomainName{ get; set; }
        public bool Default{ get; set; }

        
        

    }
}
