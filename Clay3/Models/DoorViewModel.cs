using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Clay3.Models
{
    public class DoorViewModel
    {
        public DoorItem[] doors { get; set; }

        public OpenRecord[] records { get; set; }
    }
}