using System;

namespace TicketMaster.Web.Controllers
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Ticket()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
    }
}
