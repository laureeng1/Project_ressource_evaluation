using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVALUATION.CORE.Dto
{
    public partial class AbpUsersDto
    {
        public List<AbpUserAccountsDto> AbpUserAccounts { get; set; }
        public bool IsReinitialiserAccessFailed { get; set; }
        public List<AbpClaimsDto> AbpClaimsDtos { get; set; }
    }
}
