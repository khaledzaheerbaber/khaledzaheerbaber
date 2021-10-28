using Autofac;
using Autofac.Integration.WebApi;
using DAL;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace RestAPI.App_Start
{
    public class AutoFacConfig
    {
        public static void Configuration()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<MyContext>().AsSelf();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<DepartementService>().As<IDepartementService>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}