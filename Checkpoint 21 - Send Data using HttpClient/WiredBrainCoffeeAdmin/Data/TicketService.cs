using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Data
{
    public class TicketService : ITicketService
    {
        private HttpClient client;

        public TicketService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<string> Add(HelpTicket ticket)
        {
            // TODO: Post the ticket data
            return null;
        }

        public async Task<List<HelpTicket>> GetAll()
        {
            // Ignore for now
            return null;
        }
    }
}
