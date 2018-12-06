using System.Threading.Tasks;
using Admin.Common.Domain;
using EVALUATION.DATA.Repository;

namespace EVALUATION.DATA
{
    public partial class ProviderBase
    {
        public async Task<BusinessResponse<dynamic>> ExecuteRawSqlTask(string sql)
        {
            return await new GenericProvider().ExecuteRawSqlTask(sql);
        }
    }
}