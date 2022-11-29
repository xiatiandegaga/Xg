using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cloud.Services
{
    public interface IHttpClientService
    {
        Task<string> GetAjaxAsync(string url, Dictionary<object, object> paramer = null);
        Task<string> GetAsync(string url, Dictionary<object, object> paramer = null);

        Task<string> GetStringParamerAsync(string url, Dictionary<string, string> paramer = null);

        Task<T> GetFromJsonAsync<T>(string url, Dictionary<object, object> paramer = null);

        Task<string> FormPostAsync(string url, Dictionary<string, string> formData = null);

        Task<string> JsonPostAsync(string url, string content);

        Task<byte[]> JsonPostByteAsync(string url, string content);

        Task<T> PostFromJsonAsync<T>(string url, string content);

        Task<string> DeleteAsync(string url);

        string UploadFile(string url, IDictionary<object, object> param, string file, byte[] fileByte);
    }
}
