using Cloud.PrivateNumber.YunCheng.Model;
using System.Threading.Tasks;
using WebApiClientCore.Attributes;

namespace Cloud.PrivateNumber.YunCheng
{
    public interface IAxBind: IApiService
    {
        [HttpPost("/rest/v3/voice/ax/bind/")]
        Task<BindResponse> Bind([JsonContent]BindRequest request);

        [HttpPost("/rest/v3/voice/ax/call/")]
        Task<CallResponse> Call([JsonContent] CallRequest request);

        [HttpPost("/rest/v3/voice/ax/unbind/")]
        Task<UnbindResponse> Unbind([JsonContent] UnbindRequest request);

        [HttpPost("/rest/v3/voice/ax/queryByUserId/")]
        Task<QueryByUserIdResponse> QueryByUserId([JsonContent] QueryByUserIdRequest request);
    }
}
