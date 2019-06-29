using Microsoft.Owin;
using Owin;
using TodoList.Ioc.Config;

[assembly: OwinStartupAttribute(typeof(ToDoList.Web.Startup))]
namespace ToDoList.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            SimpleInjectorAppInitializer.Initialize();

            //ConfigureAuth(app);
        }
    }
}
