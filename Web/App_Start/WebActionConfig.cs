using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Web.IocNinject;

namespace Web.App_Start
{
    public static class WebActionConfig
    {
        public static void Start()
        {
            DependencyResolver.SetResolver( new NinjectResolver( new StandardKernel() ) );
        }
    }
}