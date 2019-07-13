using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGateway.Models
{
    public class RequestData
    {
        public string orgNumber { get; set; }

        public string baseName { get; set; }

        public bool isCreditCardItem { get; set; }
    }
}