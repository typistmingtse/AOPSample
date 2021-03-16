using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPSample
{
    class Program
    {
        [ExceptionAspect(ExceptionType = typeof(Exception), Message = "A Sample Exception Message", Behavior = FlowBehavior.Continue)]
        static void Main(string[] args)
        {
            throw new Exception("Sample Exception");
        }
    }
}
