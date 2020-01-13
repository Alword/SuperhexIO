using SuperhexIO.Extensions;
using SuperhexIO.Protocols;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Query
{
    class GameStartQuery : BaseQuery
    {
        private readonly Handshake handshake;
        public GameStartQuery(byte code, Handshake handshake) : base(code)
        {
            this.handshake = handshake;
        }

        public override void Handle(byte[] buffer)
        {
            Console.WriteLine($"{code}: Game START!");
            handshake.Invoke();
        }

        public void GetPlayerInfo(byte[] buffer) 
        {
            short playerId = buffer.ToInt16(1);
            Console.WriteLine($"Player Id is {playerId}");
        }
    }
}
