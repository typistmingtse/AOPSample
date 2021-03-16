using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOPSample
{
    [Serializable]
    class ExceptionAspect : OnExceptionAspect
    {
        public string Message { get; set; }

        public Type ExceptionType { get; set; }

        public FlowBehavior Behavior { get; set; }

        public override void OnException(MethodExecutionArgs args)
        {
            var msg =$" { DateTime.Now }:{ Message + Environment.NewLine } ";
            msg += $"{ DateTime.Now }:Error running { args.Method.Name }. { args.Exception.Message }{ Environment.NewLine }{ args.Exception.StackTrace }";
            Debug.WriteLine(msg);
            Console.WriteLine(msg);
            args.FlowBehavior = FlowBehavior.Continue;

            Console.ReadKey();
        }

        public override Type GetExceptionType(MethodBase targetMethod) => ExceptionType;
    }
}
