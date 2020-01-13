using SuperhexIO.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SuperhexIO.Query
{
    class CaptureHex : BaseQuery
    {
        public CaptureHex(int code) : base(code)
        {
        }

        public override void Handle(byte[] buffer)
        {
            short playerId = buffer.ToInt16(1);
            short pathCount = buffer.ToInt16(3);
            Point[] points = new Point[pathCount];
            for (int i = 0; i < pathCount; i++)
            {
                points[i].X = buffer.ToInt16(5 + 4 * i);
                points[i].Y = buffer.ToInt16(5 + 4 * i + 2);
            }
            // Console.WriteLine($"[Captured] by PlayerId: {playerId}, path: {pathCount}, hexs: TODO"); // Y(A) lencth
        }
    }
}

//function he(t)
//{
//    for (var n = t.getInt16(1, !0), i = t.getInt16(3, !0), a = [
//    ], o = 0; o < i; o++)
//    {
//        var s = t.getInt16(5 + 4 * o, !0),
//        l = t.getInt16(5 + 4 * o + 2, !0);
//        a.push({
//        q: s,
//        r: l
//        })
//    }
//var d = Y(a);
//console.log('read capture for player', n, 'and path count :', i, 'hexs to fill :', d.length),
//    Array.prototype.push.apply(d, a);
//    for (var c = Yt || !At? k(tt* ut, nt* ut)  : k(St[Gt] * ut, Ct[Gt] * ut), u = [

// ], h = 0, o = 0; o<a.length; o++) g(a[o].q, a[o].r);
//    for (var o = 0; o<d.length; o++) {
//      var f = r(d[o].q, d[o].r);
//      if (f != n && (f == Gt && tn--, h++, G(d[o], c) <= ct)) {
//        w(b(d[o].q, d[o].r), e(0)),
//        g(d[o].q, d[o].r);
//var m = v(e(n), void 0, void 0, void 0, 0, !0);
//m.hexPosition = d[o],
//        m.position = y(d[o].q, d[o].r),
//        m.width = 0.5 * (gt - ft* ut * 2),
//        m.height = 0.5 * (ht - ft* ut * 2),
//        m.x += ft* ut + 0.25 * (gt - ft* ut * 2),
//        m.y += ft* ut + 0.25 * (ht - ft* ut * 2),
//        Ve.addChild(m),
//        u.push(m)
//      }
//    }
//    if (Kt.push({
//      type: 'CAPTURING',
//      hexs: u,
//      from: 0.5,
//      to: 1,
//      time: 0,
//      length: 200,
//      playerId: n
//    }), n == Gt && (tn += h, h >= 100 && Pe(h)), Ee(), delete Lt[n], delete Dt[n], delete wn[n], delete Ht[n], Qe.removeChild(Et[n]), delete Et[n], $t[n]) for (var o = 0; o< $t[n].length; o++) $t[n][o].points = [

//   ]
//  }
