using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Example.Models
{
    public class VehicleViewModel
    {
        public String Year { get; set; }

        //[RequiredIf(new string[] {"Year, !null"})]
        public String Make { get; set; }

        [RequiredIf(new string[] {"Year,1994", "Make,!null"})]
        public String Model { get; set; }

        public String Trim { get; set; }
    }
}
