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
    public class AppRole : IdentityRole<string, AppUserRole>
    {
        public AppRole() : base() { }
        public AppRole(string name, string description) 
        {
            this.Name = name;
            this.Description = description;
        }
        public int ProjectId { get; set; }
        public virtual string Description { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<RoleDeviceGroup> RoleDeviceGroups { get; set; }
        public virtual ICollection<RoleDeviceGroup> RoleDevicePortGroups { get; set; }
    }
}