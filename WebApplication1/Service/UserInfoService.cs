using WebApplication1.InterFace;

namespace WebApplication1.Service
{
    /// <summary>
    ///
    /// </summary>
    ///

    public class UserInfoService : IUserInfoService
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>

        public string[] GetUsers()
        {
            return new[] { "张三", "李四" };
        }
    }
}
