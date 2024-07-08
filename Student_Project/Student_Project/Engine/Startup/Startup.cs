using Student_Project.Engine.Contact;
using Student_Project.Repository;
using Microsoft.Extensions.DependencyInjection;
using Student_Project.Repository.Implementation;
using Student_Project.Engine.Implementation;

namespace Student_Project.Engine.Startup
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IStudetnRepository, StudentRepository>();
            services.AddTransient<IStudentServices, StudentServices>();
        }
    }
}
