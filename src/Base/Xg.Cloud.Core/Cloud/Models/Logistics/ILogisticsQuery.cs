using System.Threading.Tasks;

namespace Cloud.Models.Logistics
{
    public interface ILogisticsQuery
    {
        Task<T> GenericNoQuery<T>(LogisticsRequest request) where T : class;

        Task<FuQingNoQueryResponse> NoQuery(LogisticsRequest request);
    }
}
