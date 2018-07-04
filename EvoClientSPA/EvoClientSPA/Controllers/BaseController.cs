using EvoClientSPA.APIServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvoClientSPA.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BaseController<TAdapter> : Controller where TAdapter : IAdapter
    {
        private readonly TAdapter _adapter;
        [ImportingConstructor]
        public BaseController(TAdapter adapter)
        {
            _adapter = adapter;
        }
    }
}