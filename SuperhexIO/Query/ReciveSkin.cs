using SuperhexIO.Extensions;
using SuperhexIO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Query
{
    public class ReciveSkin : BaseQuery
    {
        public readonly GameState gameState;
        public ReciveSkin(int code, GameState gameState) : base(code)
        {
            this.gameState = gameState;
        }

        public override void Handle(byte[] buffer)
        {
            int skinId = buffer.ToInt16(1);
            int playerId = buffer.ToInt16(3);
            gameState.RegisterSkin(playerId, skinId);
        }
    }
}

//var t = e.getInt16(1, !0),
//   n = e.getInt16(3, !0);
//console.log('skin id received for player', t, n),
//    ln[t] = n