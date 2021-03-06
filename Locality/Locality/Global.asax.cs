﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Locality.Data;
using Locality.Data.Repositories;
using Locality.Domain.Events;
using Locality.Domain.Payments;
using Locality.Domain.Tickets;
using Locality.Domain.Users;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Integration.WebApi;
using Microsoft.AspNet.Identity;

namespace Locality
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<LocalityContext>();
            container.Register(typeof(IRepository<>), typeof(Repository<>) );
            container.Register<IUserService, UserService>();
            container.Register<IEventService, EventService>();
            container.Register<ITicketService, TicketService>();
            container.Register<IPaymentService, PaymentService>();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
        }
    }
}
