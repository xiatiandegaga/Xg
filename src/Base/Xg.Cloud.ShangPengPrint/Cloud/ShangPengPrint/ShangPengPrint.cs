using Cloud.Extensions;
using Cloud.Services;
using Cloud.Utilities;
using Cloud.Utilities.Json;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cloud.ShangPengPrint
{
    public class ShangPengPrint : IPrint
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ShangPengOptions _shangPengOptions;
        private readonly IHttpClientFactory _httpClientFactory;

        public ShangPengPrint(IOptions<ShangPengOptions> shangPengOptions, IHttpClientService httpClientService, IHttpClientFactory httpClientFactory)
        {
            _shangPengOptions = shangPengOptions.Value;
            _httpClientService = httpClientService;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> PrintAsync(ShangPengPrintRequestModel request)
        {
            ShangPengPrintRequestModel _shangPengRequestModel = new();
            _shangPengRequestModel.Appid = _shangPengOptions.Appid;
            _shangPengRequestModel.Timestamp = TimeExtension.CurrentTimeSecond();
            _shangPengRequestModel.Content = request.Content;
            _shangPengRequestModel.Sn = request.Sn;
            _shangPengRequestModel.Times = request.Times;
            _shangPengRequestModel.Sign = EncryptionUtility.MD5Up($"{ApiSignUtility.GetSortParam(JsonUtility.Serialize(_shangPengRequestModel))}&appsecret={_shangPengOptions.AppSecret}");
            var formData = JsonUtility.Deserialize<Dictionary<string, string>>(JsonUtility.Serialize(_shangPengRequestModel));
            var req = await _httpClientService.FormPostAsync($"{_shangPengOptions.DomainUrl}/{_shangPengOptions.ActionPrintUrl}", formData);
            var ret = JsonUtility.Deserialize<ShangPengPrintResponseModel>(req);
            if (ret.Errorcode == default)
                return true;
            return false;
        }

        public async Task<bool> AddAsync(ShangPengAddRequestModel request)
        {
            ShangPengAddRequestModel _shangPengAddModel = new();
            _shangPengAddModel.Appid = _shangPengOptions.Appid;
            _shangPengAddModel.Timestamp = TimeExtension.CurrentTimeSecond();
            _shangPengAddModel.Sn = request.Sn;
            _shangPengAddModel.Pkey = request.Pkey;
            _shangPengAddModel.Name = request.Name;
            var waitSign = $"{ApiSignUtility.GetSortParam(JsonUtility.Serialize(_shangPengAddModel))}&appsecret={_shangPengOptions.AppSecret}";
            _shangPengAddModel.Sign = EncryptionUtility.MD5(waitSign).ToUpper();
            var formData = JsonUtility.Deserialize<Dictionary<string, string>>(JsonUtility.Serialize(_shangPengAddModel));

            var req = await _httpClientService.FormPostAsync($"{_shangPengOptions.DomainUrl}/{_shangPengOptions.ActionAddUrl}", formData);
            var ret = JsonUtility.Deserialize<ShangPengPrintResponseModel>(req);
            if (ret.Errorcode == default)
                return true;
            return false;
        }

        public async Task<bool> DeleteAsync(ShangPengDeleteRequestModel request)
        {
            ShangPengDeleteRequestModel _shangPengDeleteModel = new();
            _shangPengDeleteModel.Appid = _shangPengOptions.Appid;
            _shangPengDeleteModel.Timestamp = TimeExtension.CurrentTimeSecond();
            _shangPengDeleteModel.Sn = request.Sn;
            var waitSign = $"{ApiSignUtility.GetSortParam(JsonUtility.Serialize(_shangPengDeleteModel))}&appsecret={_shangPengOptions.AppSecret}";
            _shangPengDeleteModel.Sign = EncryptionUtility.MD5(waitSign).ToUpper();
            var formData = ApiSignUtility.GetSortParam(JsonUtility.Serialize(_shangPengDeleteModel));
            var req = await _httpClientService.DeleteAsync($"{_shangPengOptions.DomainUrl}{_shangPengOptions.ActionDeleteUrl}?{formData}");
            var ret = JsonUtility.Deserialize<ShangPengPrintResponseModel>(req);
            if (ret.Errorcode == default)
                return true;
            return false;
        }

        public async Task<bool> QueryAsync(ShangPengQueryRequestModel request)
        {
            ShangPengQueryRequestModel _shangPengQueryModel = new();
            _shangPengQueryModel.Appid = _shangPengOptions.Appid;
            _shangPengQueryModel.Timestamp = TimeExtension.CurrentTimeSecond();
            _shangPengQueryModel.Id = request.Id;
            var waitSign = $"{ApiSignUtility.GetSortParam(JsonUtility.Serialize(_shangPengQueryModel))}&appsecret={_shangPengOptions.AppSecret}";
            _shangPengQueryModel.Sign = EncryptionUtility.MD5(waitSign).ToUpper();
            var formData = JsonUtility.Deserialize<Dictionary<string, string>>(JsonUtility.Serialize(_shangPengQueryModel));
            var req = await _httpClientService.GetStringParamerAsync($"{_shangPengOptions.DomainUrl}{_shangPengOptions.ActionQueryUrl}", formData);
            var ret = JsonUtility.Deserialize<ShangPengQueryResponseModel>(req);
            if (ret.Errorcode == default && ret.Status)
                return true;
            else
            {
                return false;
            }
        }
    }
}
