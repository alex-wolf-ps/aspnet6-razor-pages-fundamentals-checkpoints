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
            var response = await client.PostAsJsonAsync<HelpTicket>("/api/tickets", ticket);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<HelpTicket>> GetAll()
        {
            // Ignore for now
            return null;
        }
    }
}
