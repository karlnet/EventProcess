using hhnextWeb.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace hhnextWeb.Data.Infrastructure
{
    public class AppRoleStore   : RoleStore<AppRole, string, AppUserRole>,   IQueryableRoleStore<AppRole, string>,   IRoleStore<AppRole, string>, IDisposable
    {
        public AppRoleStore(): base(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public AppRoleStore(DbContext context): base(context)
        {
        }
    }
    public class AppUserStore: UserStore<AppUser, AppRole, string,AppUserLogin, AppUserRole,AppUserClaim>, IUserStore<AppUser, string>,IDisposable
    {
        public AppUserStore(): this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public AppUserStore(DbContext context): base(context)
        {
        }
    }
    public class AppDbContext: IdentityDbContext<AppUser, AppRole,string, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceGroup> DeviceGroups { get; set; }
        public DbSet<DevicePort> DevicePorts { get; set; }
        public DbSet<DevicePortGroup> DevicePortGroups { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<RoleDeviceGroup> RoleDeviceGroups { get; set; }
        public DbSet<RoleDevicePortGroup> RoleDevicePortGroups { get; set; }


        public AppDbContext()
            : base("DefaultConnection"/*, throwIfV1Schema: false*/)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>("DefaultConnection"));

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppRole>().ToTable("AppRoles");
            //modelBuilder.Entity<AppUserRole>().ToTable("AppUserRoles");
            //modelBuilder.Entity<AppUserLogin>().ToTable("AppUserLogins");
            //modelBuilder.Entity<AppUserClaim>().ToTable("AppUserClaims");

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }


    }
}