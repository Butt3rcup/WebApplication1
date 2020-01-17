using System.Threading.Tasks;

namespace WebApplication1.InterFace
{
    /// <summary>User</summary>
    public interface IUserInfoService
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>

          Task<string[]> GetUsers();
    }
}
