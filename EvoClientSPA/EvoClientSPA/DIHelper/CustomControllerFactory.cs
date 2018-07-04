using EvoClientSPA.APIServices;
using EvoClientSPA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace EvoClientSPA.DIHelper
{
    public class CustomControllerFactory: IControllerFactory
    {
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            IPersonClientAPIAdapter adapter = new PersonClientAPIAdapter();
            var controller = new PersonController(adapter);
            return controller;
        }
        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(
           System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}