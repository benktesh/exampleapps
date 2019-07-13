using System.Collections.Generic;
using MyGateway.Controllers;

namespace MyGateway.Models
{
    internal class ResultDTO
    {
        public string MasterQuestionnaireID { get; set; }
        public string Description { get; set; }
        public string OrganizationNumber { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }
        public string BaseForms { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public List<CreditCardGroup> CreditCardGroups { get; set; }
        public bool CreditCardParsingPassed { get; set; }
        public string CreditCardValidationError { get; set; }
    }
}