using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hhnextWeb.Data.Entities
{
    public class Device
    {
        public Device()
        {
            //this.boardPorts = new HashSet<BoardPort>();
            //this.applicationUserBoards = new HashSet<Board>();

        }

        public int      DeviceId { get; set; }
        public string   DeviceNo { get; set; }
        public string   DeviceName { get; set; }
        public int      DeviceGroupId { get; set; }
        public string   DeviceType { get; set; }

        public int      DriverId { get; set; }
        public int      ProjectId { get; set; }

        public string   MAC { get; set; }
        public string   ROMVersion { get; set; }
     
        public string   PrivateIP { get; set; }
        public string   PublicIP { get; set; }
        public string   SSID { get; set; }
        public string   BSSID { get; set; }
        public string   Token { get; set; }
        public string   Config { get; set; }
        public string   Address { get; set; }
        public string   Manufacturer { get; set; }
        public string   Brand { get; set; }
        public string   Model { get; set; }
        public string   Status { get; set; }
       
        
        public string   Comments { get; set; }
        public string   Item1 { get; set; }
        public string   Item2 { get; set; }
        public string   Item3 { get; set; }
        public string   Item4 { get; set; }

        public DateTime? Offtime { get; set; }
        public DateTime? Onlinetime { get; set; }
        public DateTime? Createtime { get; set; }

        public virtual  DeviceGroup DeviceGroup { get; set; }
        public virtual  Driver Driver { get; set; }
        public virtual  Project Project { get; set; }
        public virtual  ICollection<DevicePort> DevicePorts { get; set; }
        //public virtual  ICollection<RoleDeviceGroup> UserDevices { get; set; }
    }
}