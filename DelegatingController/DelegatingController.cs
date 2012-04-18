using System;
using System.Web.Mvc;

namespace DelegatingController
{
    public class DelegatingController : Controller, IDelegateToHandlers
    {
        public DelegatingController()
        {
            Invoker = new NullInvoker();
        }

        public IInvoker Invoker { get; set; }
    }

    public class NullInvoker : IInvoker 
    {
        public TU Execute <T, TU>(T inputmodel)
        {
            throw new NotImplementedException();
        }

        public T Execute <T>()
        {
            throw new NotImplementedException();
        }

        public void Execute <T>(T command)
        {
            throw new NotImplementedException();
        }
    }
}
