using System.Collections.Generic;

namespace MyGateway.Models
{
    public class CreditCardGroup
    {
        public string GroupID { get; set; }
        public string Type { get; set; }
        public List<string> CardTypes { get; set; }
        public List<string> CardIds { get; set; }
    }
}