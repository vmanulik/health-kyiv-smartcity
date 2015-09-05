using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace HealthSmartCity.Infrastructure
{
    public class AutofacControllerFactory1 : DefaultControllerFactory
    {
        private readonly Dictionary<string, Func<RequestContext, IController>> _controllerMap;

        public AutofacControllerFactory1()
        {
            List<IController> lstControllers = DependencyResolver.Current.GetServices<IController>().ToList();
            _controllerMap = new Dictionary<string, Func<RequestContext, IController>>();

            foreach (Controller contr in lstControllers)
            {
                string ctrName = contr.ControllerContext.RouteData.Values["Controller"].ToString();
                _controllerMap.Add(ctrName, c => contr);
            }
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {

            if (_controllerMap.ContainsKey(controllerName))
            {
                return _controllerMap[controllerName](requestContext);
            }
            else
                throw new KeyNotFoundException(controllerName);
        }
    }
}
