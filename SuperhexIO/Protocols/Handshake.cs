using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

namespace SuperhexIO.Protocols
{
    class Handshake : BaseCommand
    {
        byte[] handShake = new byte[1];
        public Handshake(ClientWebSocket clientWebSocket) : base(clientWebSocket)
        {
            handShake[0] = 99;
        }

        public override async void Invoke()
        {
            await client.SendAsync(handShake, WebSocketMessageType.Binary, true, CancellationToken.None);
        }
    }
}
