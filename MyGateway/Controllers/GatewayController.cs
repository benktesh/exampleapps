using System;
using System.Web.Http;
using MyGateway.Models;

namespace MyGateway.Controllers
{
    public class GatewayController : ApiController
    {
        public string GetResults(RequestData requestData)
        {
            DateTime requestDateTime = DateTime.Now;
            var manager = new Manager(); //dependency in manager
            string jsonData = manager.GetResultList(requestData, requestDateTime);
            return jsonData;
        }
    }

    public class EventsController : ApiController
    {
        private EmailAddress[] emailAddress;
        private Attendee[] attendees;
        private Event[] events;

        public EventsController()
        {

            EmailAddress[] emailAddress = new EmailAddress[]
            {
                new EmailAddress { Address = "hello@hello.com", Name = "helloname" }
            };

            Attendee[] attendees = new Attendee[]
            {
                new Attendee { EmailAddresses = emailAddress , Type = "user"}
            };

            Event[] events = new Event[]
            {
                new Event { Id = 1, Subject = "Hello World", Start = DateTime.Parse("2019-07-31 18:00:00"), End = DateTime.Parse("2019-07-31 20:00:00"), Location = "NCS Hub", Attendees = attendees }
            };

        }

    }

    public class EmailAddress
    {
        public String Address { get; set; }
        public string Name { get; set; }
    }

    public class Attendee
    {
        public EmailAddress[] EmailAddresses { get; set; }
        public string Type { get; set; }

        
    }

    public class Event
    {
        public int Id { get; set; }
        public String Subject { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Location { get; set; }
        public Attendee[] Attendees { get; set; }

         
        
    }
}
