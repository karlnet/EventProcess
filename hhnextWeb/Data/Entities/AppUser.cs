using hhnextWeb.Data.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace hhnextWeb.Data.Entities
{
    public class AppUserLogin : IdentityUserLogin<string> { }
    public class AppUserClaim : IdentityUserClaim<string> { }
    public class AppUserRole : IdentityUserRole<string> { }
    public class AppUser :  IdentityUser<string, AppUserLogin,AppUserRole, AppUserClaim>
    {
        public string NickName { get; set; }
        public string UserToken { get; set; }
        public string UserKey { get; set; }
        public string UserType { get; set; } // AppOwner,   AppUser
        public DateTime Createtime { get; set; }

        public string Comments { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Item4 { get; set; }

       
        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(AppUserManager manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }


    }


}