namespace ChessBlazorWebApp.Logic.Comunication
{
    public class MessagesToServer
    {
        public string sesionId { get; set; }
        public int userId { get; set; }
        public string data { get; set; }

        public MessagesToServer() { }
        public MessagesToServer(string sesionId, int userId, string data) 
        {
            this.sesionId = sesionId;
            this.userId = userId;
            this.data = data;
        }
    }
}
