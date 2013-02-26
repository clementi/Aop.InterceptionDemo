using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity.InterceptionExtension;
using log4net;

namespace Aop.InterceptionDemo
{
    public class LogBehavior : IInterceptionBehavior
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LogBehavior));

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var factor = input.Arguments[0];

            Log.InfoFormat("{0} accelerating to warp {1}.", input.Target, factor);

            var methodReturn = getNext().Invoke(input, getNext);

            if (methodReturn.Exception == null)
                Log.InfoFormat("{0} now at warp {1}.", input.Target, factor);
            else
            {
                Log.ErrorFormat(
                    "{0} could not accelerate to warp {1}: {2}.", 
                    input.Target, 
                    factor,
                    methodReturn.Exception.Message);

                return input.CreateMethodReturn(null);
            }

            return methodReturn;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}