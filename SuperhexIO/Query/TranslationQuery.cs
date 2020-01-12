using SuperhexIO.Extensions;
using SuperhexIO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Query
{
    public class TranslationQuery : BaseQuery
    {
        private GameState gameState;
        public TranslationQuery(int code, GameState gameState) : base(code)
        {
            this.gameState = gameState;
        }

        public override void Handle(byte[] buffer)
        {
            long dateTime = DateTime.UtcNow.Ticks; // t
            //    n = e.getUint32(1, !0),
            //    i = Nt + 17 * n,
            int playerId = buffer.ToInt16(5);
            //    if (a == Gt && !Yt && Tt[Gt])
            //    {
            //        var o = Math.abs((new Date).getTime() - Tt[Gt] - 51);
            //        o > Qt && (Qt = o)
            //    }
            //    Tt[a] = t;
            float x = buffer.ToFloat32(7); // r
            float y = buffer.ToFloat32(11); // s
            float dir = buffer.ToFloat32(15); // l
            float targetDir = buffer.ToFloat32(19); //d
            var points = new byte[4]; // c

            //    if (e.byteLength > 23) for (var u = e.getInt16(23, !0), g = e.getInt16(25, !0), h = 0; h < u; h++)
            //        {
            //            var f = e.getFloat32(27 + 8 * h + 0, !0),
            //            m = e.getFloat32(27 + 8 * h + 4, !0);
            //            c.push([a,
            //            g + h,
            //            f,
            //            m])
            //    }
            //    if (i<t) {
            //      for (var h = 0; h<c.length; h++) ge(c[h][0], c[h][1], c[h][2], c[h][3]);
            //Lt[a] && Ht[a] && Lt[a].splice(2 * (Ht[a] + 1)),
            //      le(a, r, s, l, d, t - i),
            //      ue(a)
            //    } else $t[a] || ($t[a] = [
            //    ]),
            gameState.RegisterTranslation(new PlayerTranslation()
            {
                PlayerId = playerId,
                X = x,
                Y = y,
                Dir = dir,
                TargetDir = targetDir,
                time = dateTime
                // TODO points??
            });
        }
    }
}

//function de(e)
//{
//    var t = (new Date).getTime(),
//    n = e.getUint32(1, !0),
//    i = Nt + 17 * n,
//    a = e.getInt16(5, !0);
//    if (a == Gt && !Yt && Tt[Gt])
//    {
//        var o = Math.abs((new Date).getTime() - Tt[Gt] - 51);
//        o > Qt && (Qt = o)
//    }
//    Tt[a] = t;
//    var r = e.getFloat32(7, !0),
//    s = e.getFloat32(11, !0),
//    l = e.getFloat32(15, !0),
//    d = e.getFloat32(19, !0),
//    c = [
//    ];
//    if (e.byteLength > 23) for (var u = e.getInt16(23, !0), g = e.getInt16(25, !0), h = 0; h < u; h++)
//        {
//            var f = e.getFloat32(27 + 8 * h + 0, !0),
//            m = e.getFloat32(27 + 8 * h + 4, !0);
//            c.push([a,
//            g + h,
//            f,
//            m])
//    }
//    if (i<t) {
//      for (var h = 0; h<c.length; h++) ge(c[h][0], c[h][1], c[h][2], c[h][3]);
//Lt[a] && Ht[a] && Lt[a].splice(2 * (Ht[a] + 1)),
//      le(a, r, s, l, d, t - i),
//      ue(a)
//    } else $t[a] || ($t[a] = [
//    ]),
//    $t[a].push({
//playerId: a,
//      x: r,
//      y: s,
//      dir: l,
//      targetDir: d,
//      time: i,
//      points: c
//    })
//  }