using System;
using System.Net.WebSockets;
using System.Threading;

namespace SuperhexIO.Protocols
{
    class Rejoin : BaseCommand
    {
        byte[] buffer = new byte[1];
        public Rejoin(ClientWebSocket clientWebSocket) : base(clientWebSocket)
        {
            buffer[0] = 4;
        }

        public override async void Invoke()
        {
            await client.SendAsync(buffer, WebSocketMessageType.Binary, true, CancellationToken.None);
            Console.Write("Rejoint");
        }
    }
}
