using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

namespace SuperhexIO.Protocols
{
    class Movement : BaseCommand
    {
        byte[] buffer = new byte[5];
        private float angle;
        public Movement(ClientWebSocket clientWebSocket, float angle = 0) : base(clientWebSocket)
        {
            this.angle = angle;
        }

        public override async void Invoke()
        {
            buffer[0] = 3;
            BitConverter.GetBytes(angle).CopyTo(buffer, 1);
            await client.SendAsync(buffer, WebSocketMessageType.Binary, true, CancellationToken.None);
        }

        public void Invoke(float angle)
        {
            this.angle = angle;
            Invoke();
        }
    }
}

// var angle = Math.atan2(e.clientY - window.innerHeight / 2, e.clientX - window.innerWidth / 2);

//lt = null;
//    var e = new DataView(new ArrayBuffer(5));
//e.setUint8(0, 3),
//    e.setFloat32(1, st, !0),
//    Ue && 1 == Ue.readyState && (Jt.push((new Date).getTime()), Zt.push(st), Ue.send(e.buffer))