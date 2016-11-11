using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hhnextWeb.Data.Entities
{
    public class DevicePort
    {
        
        public int          PortId { get; set; }
        public int          DeviceId { get; set; }
        public string       PortNo { get; set; }
        public string       PortName { get; set; }
        public string       Alias { get; set; }
        public int          DevicePortGroupId { get; set; }
        public string       PortType { get; set; }
        public string       Enable { get; set; }

        public string       DataType { get; set; }
        public decimal?     Uplimit { get; set; }
        public decimal?     Lowlimit { get; set; }
        public decimal?     UpOffset { get; set; }
        public decimal?     LowOffset { get; set; }
        public decimal?     Max { get; set; }
        public decimal?     Min { get; set; }
        public string       DefaultValue { get; set; }

        public string       Permission { get; set; }
        public string       IP { get; set; }
        public string       Config { get; set; }
        public string       Address { get; set; }

        public string       Comments { get; set; }
        public string       Item1 { get; set; }
        public string       Item2 { get; set; }
        public string       Item3 { get; set; }
        public string       Item4 { get; set; }

        public virtual Device Device { get; set; }
        public virtual DevicePortGroup DevicePortGroup { get; set; }

        public DevicePort()
        {

            //this.board = new Board();
            //this.portDescription = new PortDescription();
        }

        public int getIntDefaultValue()
        {
            return int.Parse(this.DefaultValue);
        }

        public decimal getDecimalDefaultValue()
        {
            return decimal.Parse(DefaultValue);
        }


    }
}