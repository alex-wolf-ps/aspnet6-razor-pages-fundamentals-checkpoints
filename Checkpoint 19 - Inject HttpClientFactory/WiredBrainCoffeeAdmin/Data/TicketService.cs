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
            // Ignore this for now
            return null;
        }

        public async Task<List<HelpTicket>> GetAll()
        {
            // TODO: Retrieve all help tickets from the "/api/tickets" path
            return null;
        }
    }
}
