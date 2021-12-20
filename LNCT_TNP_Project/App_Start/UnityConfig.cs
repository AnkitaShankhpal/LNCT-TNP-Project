using LNCT_TNP_Project.Repository;
using LNCT_TNP_Project.Repository.Implementation;
using LNCT_TNP_Project.Services;
using LNCT_TNP_Project.Services.Implementation;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace LNCT_TNP_Project
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
          
            container.RegisterType<IStudentProfileRepository, StudentProfileRepository>();
            container.RegisterType<IStudentProfileServices, StudentProfileServices>();
            container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<IAdminServices, AdminServices>();
            container.RegisterType<ITNPRepository, TNPRepository>();
            container.RegisterType<ITNPServices, TNPServices>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}