using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ChessBlazorWebApp.Logic.Comunication
{
    public class ServerComunication
    {
        private readonly HttpClient client;
        public string sesionId { get; set; }

        public ServerComunication()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/Comunication");
            //client.BaseAddress = new Uri("https://localhost:7284/Operation");
        }

        // Przykład: wysyłanie wiadomości jako JSON (POST)
        public async Task<HttpResponseMessage> SendMessageAsync(string message)
        {
            var content = new StringContent($"\"{message}\"", System.Text.Encoding.UTF8, "application/json");
            return await client.PostAsync("send", content);
        }

        // Przykład: pobieranie danych z serwera (GET)
        public async Task<string> GetMessageAsync()
        {
            return await client.GetStringAsync("get");
        }
    }
}
