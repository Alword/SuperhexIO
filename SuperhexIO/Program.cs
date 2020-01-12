using SuperhexIO.Commands;
using SuperhexIO.Protocols;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace SuperhexIO
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string server = await GetServers.GetBestInZone();
            Console.WriteLine(server);

            List<ClientWebSocket> sockets = new List<ClientWebSocket>();

            ClientWebSocket clientWebSocket = new ClientWebSocket();
            // for N
            sockets.Add(clientWebSocket);
            await clientWebSocket.ConnectAsync(new Uri($"wss://{server.Replace(":", "/")}"), CancellationToken.None);

            // game register

            Registration registration = new Registration(clientWebSocket);
            registration.Invoke();

            // game processor

            byte[] memory = new byte[43]; // TODO how many
            while (clientWebSocket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult text = await clientWebSocket.ReceiveAsync(memory, CancellationToken.None);
                Console.WriteLine(memory[0]);
            }

            Console.ReadLine();
        }
    }
}
