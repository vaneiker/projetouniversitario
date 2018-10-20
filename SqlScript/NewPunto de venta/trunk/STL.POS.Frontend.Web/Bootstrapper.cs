using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using STL.POS.Data;
using STL.POS.WsProxy;
using STL.POS.WsProxy.SysflexService;
using STL.POS.Frontend.Security.SecurityProvider;
using STL.POS.PlexysProxy;
using STL.POS.AchWsProxy;
using STL.POS.PlexysProxy.PlexisService;
using STL.POS.AchWsProxy.AchPayments;
using STL.POS.THProxy;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Reflection;
using STL.POS.VirtualOfficeProxy;
using STL.POS.AgentWSProxy;
//using STL.POS.VirtualOfficeProxy;

namespace STL.POS.Frontend.Web
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            Logger.SetLogWriter(new LogWriterFactory().Create());
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IAuthenticationProvider, AuthenticationProvider>();
            container.RegisterInstance(typeof(PosModel), new PosModel(), new PerRequestLifetimeManager());

            System.Diagnostics.Trace.WriteLine("PASO!!");

            container.RegisterInstance(typeof(SysFlexServiceClient), new SysFlexServiceClient("BasicHttpBinding_ISysFlexService"));
            container.RegisterType<ICoreProxy, CoreProxy>(new ContainerControlledLifetimeManager());
            container.RegisterType<ITHProxy, THProxy.THProxy>(new ContainerControlledLifetimeManager());
            container.RegisterType<IGPPayments, GPPaymentsClient>(new ContainerControlledLifetimeManager(), new InjectionConstructor());
            container.RegisterType<IAchPaymentProxy, AchPaymentProxy>(new ContainerControlledLifetimeManager());
            container.RegisterType<IVirtualOfficeProxy, VirtualOfficeProxy.VirtualOfficeProxy>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAgentProxy, AgentProxy>(new ContainerControlledLifetimeManager());

            container.RegisterInstance<IPlexisServices>(new PlexisServicesClient());
            container.RegisterType<IProxyClient, ProxyClient>();
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}