using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceAPI.Model
{
    public class Device
    {
        [Key]
        public Guid Devid { get; set; }
        public string DeviceName { get; set; }
    }
}
