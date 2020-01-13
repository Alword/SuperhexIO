using SuperhexIO.Commands;
using SuperhexIO.Models;
using SuperhexIO.Protocols;
using SuperhexIO.Query;
using System;
using System.Collections.Generic;
using System.Linq;
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

            // game processor

            GameState gameState = new GameState();
            Dictionary<byte, BaseQuery> commands = new Dictionary<byte, BaseQuery>
            {
                { 1, new GameStartQuery(1,new Handshake(clientWebSocket)) }, // TODO hz
                // 2
                {3, new SelfMovement(3) },
                {4, new CaptureHex(4) }, // TODO capture
                // 5 
                { 13, new TranslationQuery(13, gameState)},
                // 6
                // 14
                { 7, new DeathQuery(7) }, // TODO decapture
                // {8, }  
                // 9
                // {10, }
                { 11, new ReceiveUsername(11,gameState)},
                { 15, new ReciveSkin(15,gameState)},
                // 12
                // 99
            };


            Queue<byte[]> messageQueue = new Queue<byte[]>();
            HandleClientInput(clientWebSocket, messageQueue);

            byte[] buffer = new byte[43]; // TODO how many
            while (clientWebSocket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult text = await clientWebSocket.ReceiveAsync(buffer, CancellationToken.None);

                byte key = buffer[0];
                if (commands.ContainsKey(key))
                {
                    if (!text.EndOfMessage)
                    {
                        buffer = await HandleLongMessage(buffer, clientWebSocket);
                    }
                    commands[key].Handle(buffer);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Command {key} is not implemented");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            Console.ReadLine();
        }

        static async Task<byte[]> HandleLongMessage(byte[] currentBuffer, ClientWebSocket clientWebSocket)
        {
            bool isEndOfMessage = false;
            List<byte> data = currentBuffer.ToList();
            byte[] extraMemory = new byte[256];
            while (!isEndOfMessage)
            {
                var messageInfo = await clientWebSocket.ReceiveAsync(extraMemory, CancellationToken.None);
                isEndOfMessage = messageInfo.EndOfMessage;
                data.AddRange(extraMemory.ToList());
            }
            return data.ToArray();
        }

        static async void HandleClientInput(ClientWebSocket clientWebSocket, Queue<byte[]> bufferQueue)
        {
            await Task.Factory.StartNew(() =>
            {
                Random random = new Random();
                Registration registration = new Registration(clientWebSocket);
                registration.Invoke();
                Movement movement = new Movement(clientWebSocket);
                Rejoin rejoin = new Rejoin(clientWebSocket);
                while (true)
                {
                    Console.ReadLine();
                    float angle = (float)random.NextDouble() * (3f + 3f) - 3f;
                    movement.Invoke(angle);
                }
            });
        }
    }
}
