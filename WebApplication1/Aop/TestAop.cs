﻿using System;
using Castle.DynamicProxy;

namespace WebApplication1.Aop
{
    public class TestAop : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"invocation.Methond={invocation.Method}");
            Console.WriteLine($"invocation.Arguments={string.Join(",", invocation.Arguments)}");

            invocation.Proceed(); //继续执行

            Console.WriteLine($"方法{invocation.Method}执行完成了");
        }
    }
}
