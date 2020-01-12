using System.Net.WebSockets;

namespace SuperhexIO.Protocols
{
    public abstract class BaseCommand<T>
    {
        protected readonly ClientWebSocket client;
        public BaseCommand(ClientWebSocket clientWebSocket) { client = clientWebSocket; }

        public abstract void Invoke(T data);
    }
}