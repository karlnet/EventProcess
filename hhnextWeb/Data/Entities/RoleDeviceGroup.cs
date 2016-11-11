using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hhnextWeb.Data.Entities
{
    public class RoleDeviceGroup
    {

        public RoleDeviceGroup()
        {

            //this.board = new Board();
            //this.applicationUser = new ApplicationUser();
        }

        public int RoleDeviceGroupId { get; set; }
        public int DeviceGroupId { get; set; }
        //public string AppRoleId { get; set; }

        public bool read { get; set; }
        public bool write { get; set; }
        public bool exec { get; set; }
        public bool item { get; set; }


        public virtual  AppRole AppRole { get; set; }
        public virtual  DeviceGroup DeviceGroup { get; set; }
    }
}