using Microsoft.AspNetCore.Components;
using System.Net.WebSockets;
using System.Text;

namespace ChessBlazorWebApp.Logic.Comunication
{
    public class WebSocketClient()
    {
        private ClientWebSocket _client;

        public async Task ConnectAsync(string uri)
        {
            _client = new ClientWebSocket();
            await _client.ConnectAsync(new Uri(uri), CancellationToken.None);
            Console.WriteLine("Connected to WebSocket server");

            _ = Task.Run(async () => await ReceiveMessagesAsync()); // Odbiór wiadomości w tle
        }

        public async Task SendMessageAsync(string message)
        {
            if (_client.State == WebSocketState.Open)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await _client.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        private async Task ReceiveMessagesAsync()
        {
            var buffer = new byte[1024];
            while (_client.State == WebSocketState.Open)
            {
                var result = await _client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine($"Received from server: {receivedMessage}");
            }
        }
    }
}
