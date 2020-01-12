using SuperhexIO.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Query
{
    public class ReciveSkin : BaseQuery
    {
        public readonly Dictionary<int, int> playersSkin;
        public ReciveSkin(int code, Dictionary<int, int> playersSkin) : base(code)
        {
            this.playersSkin = playersSkin;
        }

        public override void Handle(byte[] buffer)
        {
            int skinId = buffer.ToInt16(1);
            int playerId = buffer.ToInt16(3);
            if (playersSkin.ContainsKey(playerId))
            {
                playersSkin[playerId] = skinId;
            }
            else
            {
                playersSkin.Add(playerId, skinId);
            }
            Console.WriteLine($"skin {skinId} recived for player {playerId}");
        }
    }
}

//var t = e.getInt16(1, !0),
//   n = e.getInt16(3, !0);
//console.log('skin id received for player', t, n),
//    ln[t] = n