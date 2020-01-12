using SuperhexIO.Commands;
using SuperhexIO.Models;
using SuperhexIO.Protocols;
using SuperhexIO.Query;
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

            GameState gameState = new GameState();
            Dictionary<byte, BaseQuery> commands = new Dictionary<byte, BaseQuery>
            {
                { 1, new GameStartQuery(1) },
                { 15, new ReciveSkin(15,gameState.PlayerSkin) },
                { 13, new TranslationQuery(13,gameState) }
            };


            byte[] memory = new byte[43]; // TODO how many
            while (clientWebSocket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult text = await clientWebSocket.ReceiveAsync(memory, CancellationToken.None);

                byte key = memory[0];
                if (commands.ContainsKey(key))
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    commands[key].Handle(memory);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Command {key} is not implemented");
                }
            }

            Console.ReadLine();
        }
    }
}
