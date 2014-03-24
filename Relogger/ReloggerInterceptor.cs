using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relogger
{
    public class ReloggerInterceptor : IInterceptor
    {
        private int Depth { get; set; }

        public ReloggerInterceptor()
        {
            Depth = 0;
        }

        public void Intercept(IInvocation invocation)
        {
            var builder = new StringBuilder();
            builder.Append('-', Depth);
            builder.Append(invocation.Method.Name).Append("(");

            var parameters = invocation.Method.GetParameters();
            for (var i = 0; i < parameters.Length; ++i)
            {
                builder.Append(parameters[i].Name).Append(":");
                if (invocation.Arguments.Length > i)
                {
                    builder.Append(invocation.Arguments[i].ToString());
                }
                else
                {
                    builder.Append("{NOT FOUND}");
                }

                if (i + 1 < parameters.Length)
                {
                    builder.Append(",");
                }
            }

            builder.Append(")");

            Console.WriteLine(builder);

            ++Depth;
            invocation.Proceed();
            --Depth;
        }
    }
}
