using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using WebApplication1.InterFace;

namespace WebApplication1.Service
{

    /// <summary>
    /// UserInfo
    /// </summary>
    public class UserInfoService : IUserInfoService
    {





        public async Task<string[]> GetUsers()
        {



            return await Task.Run(getList);

        }



        private string[] getList()
        {
            return new[] {"张三", "李四", "王五1","赵六","aa","ac",$"{DateTime.Now}.{DateTime.Now.Millisecond}"};
        }
    }
}
