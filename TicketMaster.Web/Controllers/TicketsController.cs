using System.Collections.Generic;
using System.Web.Http;

namespace TicketMaster.Web.Controllers
{
    public class TicketsController : ApiController
    {
        private static readonly List<Ticket> _tickets = new List<Ticket>
        {
            new Ticket { Id = 1, Title = "First Ticket" },
            new Ticket { Id = 2, Title = "Second Ticket" },
            new Ticket { Id = 3, Title = "Third Ticket" }
        };

        public IHttpActionResult Get()
        {
            return Ok(_tickets);
        }
    }
}
