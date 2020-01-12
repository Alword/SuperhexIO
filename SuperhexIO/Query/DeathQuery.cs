using SuperhexIO.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Query
{
    class DeathQuery : BaseQuery
    {
        public DeathQuery(int code) : base(code)
        {
        }

        public override void Handle(byte[] buffer)
        {
            short playerId = buffer.ToInt16(1); // i
            short killerId = buffer.ToInt16(3); // a
            Console.WriteLine($"player {playerId} is dead, killer is {killerId}");

            // TODO Draw impact

            // TODO Release hexes
        }
    }
}
//function fe(n)
//{
//    var i = n.getInt16(1, !0),
//    a = n.getInt16(3, !0);
//    console.log('player is dead', i, 'killer is ', a);
//    for (var o = [
//    ], l = Yt || !At ? k(tt * ut, nt * ut) : k(St[Gt] * ut, Ct[Gt] * ut), d = {
//      q: 0,
//      r: 0
//    }, c = - ct; c <= ct; c++) for (var u = - ct; u <= ct; u++) if (d.q = l.q + c, d.r = l.r + u, K(d.q, d.r)) if (r(d.q, d.r) == i) {
//      if (s(d.q, d.r), G(l, d) <= ct) {
//        var g = v(e(i), void 0, void 0, void 0, 0, !0);
//g.hexPosition = {
//          q: d.q,
//          r: d.r
//        },
//        g.position = y(d.q, d.r),
//        g.width = gt - ft* ut * 2,
//        g.height = ht - ft* ut * 2,
//        g.x += ft* ut,
//        g.y += ft* ut,
//        Ve.addChild(g),
//        o.push(g)
//      }
//    } else p(d.q, d.r) == i && h(d.q, d.r);
//    if (o.length > 0 && setTimeout(function () {
//    Kt.push({
//    type: 'UNCAPTURING',
//        hexs: o,
//        from: 1,
//        to: 0,
//        time: 0,
//        length: 500,
//        playerId: i
//      })
//    }, 500), n.byteLength >= 13) {
//      var f = n.getFloat32(5, !0),
//      m = n.getFloat32(9, !0),
//      w = new PIXI.Graphics,
//      I = 0.01 * mt;
//w.beginFill(16777215),
//      w.drawCircle(f* ut, m* ut, I),
//      w.endFill(),
//      w.alpha = 1,
//      Ye.addChild(w),
//      Kt.push({
//        type: 'IMPACT',
//        from: 0,
//        to: 1,
//        time: 0,
//        length: 300,
//        playerId: i,
//        impactX: f,
//        impactY: m,
//        sprite: w
//      })
//    }
//    for (var b = [
//    ], x = 0; x< 9; x++) {
//      var w = new PIXI.Graphics,
//      I = ut / 6 + Math.random() * ut / 9;
//w.lineStyle(yt* I / mt, e(i), 1),
//      w.beginFill(t(i)),
//      w.drawCircle(St[i] * ut, Ct[i] * ut, I),
//      w.endFill(),
//      b.push(w),
//      w.animationDirection = Math.random() * Math.PI * 2,
//      w.animationSpeed = 2 * Math.random() + 2,
//      Ye.addChild(w)
//    }
//    if (Kt.push({
//      type: 'EXPLOSION',
//      parts: b,
//      from: 1,
//      to: 0,
//      time: 0,
//      length: 500,
//      moveLength: 500,
//      playerId: i
//    }), Et[i] && (Kt.push({
//      type: 'TRAIL_DISAPPEAR',
//      trailGraphics: Et[i],
//      from: 1,
//      to: 0,
//      time: 0,
//      length: 200,
//      playerId: i
//    }), delete Et[i], delete Lt[i], delete Dt[i], delete wn[i], delete Ht[i]), Yt || i != Gt) me(i);
//     else {
//      Yt = !0,
//      tt = St[Gt],
//      nt = Ct[Gt],
//      delete St[Gt],
//      delete Ct[Gt],
//      delete Pt[Gt],
//      delete Bt[Gt],
//      delete $t[Gt],
//      _e.visible = !1,
//      je.visible = !1,
//      document.getElementById('rankValue').innerHTML = '',
//      document.getElementById('finalScore').innerHTML = tn + 500 * en;
//var E = 100 * tn / (1 + 3 * dt * (dt + 1));
//document.getElementById('finalMapPercent').innerHTML = E.toString().match(/^-?\d+(?:\.\d{ 0,1})?/) [0],
//      document.getElementById('finalKills').innerHTML = en,
//      document.getElementById('finalBlocks').innerHTML = tn,
//      setTimeout(function () {
//    document.getElementById('fps') && (document.getElementById('fps').style.display = 'none'),
//        document.getElementById('respawn').style.display = 'block',
//        document.getElementById('victory').style.display = 'none',
//        Ne = setTimeout(function() {
//        location.reload()
//        }, 900000),
//        'undefined' != typeof ga && (ga('set', 'page', '/respawn'), ga('send', 'pageview'))
//      }, 1000),
//      'undefined' != typeof aiptag && aiptag.cmd.display.push(function () {
//        aipDisplayTag.display('TKS_superhex-io_300x250')
//      }),
//      factorem && factorem.refreshAds([1], !0)
//    }
//    delete ln[i],
//    delete sn[i],
//    delete dn[i],
//    Yt || an--,
//    Yt || i == Gt || a != Gt || (en++, Pe(500)),
//    Ee()
//  }