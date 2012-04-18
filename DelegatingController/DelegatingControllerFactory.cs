using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace DelegatingController
{
    public class DelegatingControllerFactory : DefaultControllerFactory
    {
        private readonly Func<Type, object> _resolver;

        public DelegatingControllerFactory(Func<Type, object> resolver)
        {
            _resolver = resolver;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            var controller = (IController)_resolver(controllerType);
            if (controller as IDelegateToHandlers != null)
            {
                ((IDelegateToHandlers)controller).Invoker = new Invoker(_resolver);
            }
            return controller;
        }
    }
}