using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Service.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public ApplicationDbContext()
            : base("AzureConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DatabaseInitializer());
            Database.Initialize(force: true);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}