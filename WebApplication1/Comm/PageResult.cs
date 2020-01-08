using System.Collections.Generic;

namespace WebApplication1.Comm
{
    /// <summary>
    /// 通用返回类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<T>
    {

        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public List<T> DataList { get; set; }
    }
}
