using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relogger
{
    public static class RegistrationExtensions
    {
        public static ComponentRegistration<T> Relog<T>(this ComponentRegistration<T> registration)
            where T : class
        {
            return registration.Interceptors<ReloggerInterceptor>();
        }
    }
}
