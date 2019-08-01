using System.Collections.Generic;
using MyGateway.Models;

namespace MyGateway.Models
{
    internal class Result
    {
        public string MasterQuestionnaireID { get; set; }
        public string description { get; set; }
        public string updatedDate { get; set; }
        public string updatedByUserName { get; set; }
        public string baseForms { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public List<CreditCardGroup> CreditCardGroups { get; set; }
        public bool CreditCardParsingPassed { get; set; }
        public string CreditCardValidationError { get; set; }
    }


}