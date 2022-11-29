using Cloud.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.EntityFrameworkCore
{
    public static class ApplicationDbContextExtensions
    {
        public static async Task ExecuteSqlRawAsync(this ApplicationDbContext db, StringBuilder sql) => await db.Database.ExecuteSqlRawAsync(sql.ToString());
    }
}
