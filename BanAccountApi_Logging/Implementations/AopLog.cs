using System;
using Newtonsoft.Json;
using AspectInjector.Broker;

namespace BanAccountApi_Logging.Implementations
{
    [Aspect(Scope.Global)]
    [Injection(typeof(AopLog))]
    public class AopLog : Attribute
    {
        /// <summary>
        /// This method will be called before each method or function execution
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        [Advice(Kind.Around, Targets = Target.Method)]
        public object HandleMethod(
            [Argument(Source.Name)] string name,
            [Argument(Source.Arguments)] object[] arguments,
            [Argument(Source.Target)] Func<object[], object> method)
        {
            try
            {
                string execMethodName = string.Concat(method.Method.DeclaringType.FullName, ".", name);

                LogBase.WriteLog(execMethodName);

                //Actual method call happens here
                var result = method(arguments);

                //Once the method exec is complete, the call comes over here
                string execOutput = JsonConvert.SerializeObject(result);

                LogBase.WriteLog(execOutput);

                return result;
            }
            catch (Exception ex)
            {
                //The control gets here in case there is an error in target method execution
                string execErrorOutput = string.Concat("ERROR: ", JsonConvert.SerializeObject(ex));

                LogBase.WriteLog(execErrorOutput);

                return ex;
            }
        }
    }
}
