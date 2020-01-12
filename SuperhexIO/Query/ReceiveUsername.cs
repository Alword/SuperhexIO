using SuperhexIO.Extensions;
using SuperhexIO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Query
{
    public class ReceiveUsername : BaseQuery
    {
        private GameState gameState;
        public ReceiveUsername(int code, GameState gameState) : base(code)
        {
            this.gameState = gameState;
        }

        public override void Handle(byte[] buffer)
        {
            short playerId = buffer.ToInt16(1);
            int length = buffer[3];
            StringBuilder nickName = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                int charId = buffer[4 + 2 * i] | buffer[4 + 2 * i + 1] << 8;
                nickName.Append(char.ConvertFromUtf32(charId));
            }
            gameState.RegisterNick(playerId, nickName.ToString());
        }
    }
}
//function be(e)
//{
//    for (var t = e.getInt16(1, !0), n = e.getUint8(3, !0), i = '', a = 0; a < n; a++)
//    {
//        var o = e.getUint8(4 + 2 * a, !0) | e.getUint8(4 + 2 * a + 1, !0) << 8;
//        i += String.fromCharCode(o)
//    }
//    console.log('username received for player', t, i),
//    sn[t] = Ie(we(i)),
//    Yt || t != Gt || (it = i, Fe.removeChild(je), je = new PIXI.Text(it, {
//      fontFamily: 'Arial',
//      fontSize: 16 / pn,
//      fill: 16777215
//    }), je.x = window.innerWidth / 2 - je.width / 2, je.y = window.innerHeight / 2 - ht - mt, Fe.addChild(je))
//  }