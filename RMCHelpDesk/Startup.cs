using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RMCHelpDesk.Startup))]
namespace RMCHelpDesk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateRoleandUser();
        }
        //private void CreateRoleandUser()
        //{
        //    RMCHelpDesk.Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        //    var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

        //}
    }
}
