using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace ObjectContextApp
{
    class SportCar
    {
        public SportCar()
        {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", ToString(), ctx.ContextID);
            foreach (IContextProperty itfCtxProp in ctx.ContextProperties)
                Console.WriteLine("->Ctx Prop: {0}", itfCtxProp.Name);
        }
    }
}
