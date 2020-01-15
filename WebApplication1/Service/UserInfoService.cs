using WebApplication1.InterFace;

namespace WebApplication1.Service
{
    
    /// <summary>
    /// UserInfo
    /// </summary>
    public class UserInfoService : IUserInfoService
    {
        

        public string[] GetUsers()
        {
            return new[] { "张三", "李四" };
        }
    }
}
