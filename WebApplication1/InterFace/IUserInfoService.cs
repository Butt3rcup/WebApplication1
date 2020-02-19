using System.Threading.Tasks;

namespace WebApplication1.InterFace
{
    /// <summary>User</summary>
    public interface IUserInfoService
    {
   

          Task<string[]> GetUsers();
    }
}
