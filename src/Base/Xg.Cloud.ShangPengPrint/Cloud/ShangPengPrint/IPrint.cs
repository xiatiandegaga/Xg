using System.Threading.Tasks;

namespace Cloud.ShangPengPrint
{
    public interface IPrint
    {
        Task<bool> PrintAsync(ShangPengPrintRequestModel request);

        Task<bool> AddAsync(ShangPengAddRequestModel request);

        Task<bool> DeleteAsync(ShangPengDeleteRequestModel request);
    }
}
