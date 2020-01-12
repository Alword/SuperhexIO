using System;
using System.IO;
using System.Net.WebSockets;
using System.Threading;

namespace SuperhexIO.Protocols
{
    public class Registration : BaseCommand<string>
    {
        public Registration(ClientWebSocket clientWebSocket) : base(clientWebSocket)
        {
        }

        public override async void Invoke(string nickName = "sad")
        {
            // new ArrayBuffer(2 + 2 * it.length + 1 + (ot ? 2 * ot.length : 0) + 2);
            byte[] buffer = new byte[2 + 2 * nickName.Length + 1 + 2];
            buffer[0] = 1;
            buffer[1] = (byte)nickName.Length;

            for (int i = 0; i < nickName.Length; i++)
            {
                buffer[2 + 2 * i] = (byte)(255 & Convert.ToInt16(nickName[i]));
                buffer[2 + 2 * i + 1] = (byte)(nickName[i] >> 8);
            }
            int z = 1 + 2 * nickName.Length + 1;
            buffer[z] = 0;

            short last = -1;
            var converted = BitConverter.GetBytes(last);
            buffer[z + 1] = converted[0];
            buffer[z + 2] = converted[1];

            await client.SendAsync(buffer, WebSocketMessageType.Binary, true, CancellationToken.None);
        }
    }
}

//var e = new DataView(new ArrayBuffer(2 + 2 * it.length + 1 + (ot ? 2 * ot.length : 0) + 2));
//e.setUint8(0, 1),
//    e.setUint8(1, it.length);
//    for (var t = 0; t<it.length; t++) {
//      var n = it.charCodeAt(t);
//e.setUint8(2 + 2 * t, 255 & n),
//      e.setUint8(2 + 2 * t + 1, n >>> 8)
//    }
//    var i = 1 + 2 * it.length + 1;
//    if (ot) {
//      e.setUint8(i, ot.length);
//      for (var t = 0; t<ot.length; t++) {
//        var n = ot.charCodeAt(t);
//e.setUint8(i + 1 + 2 * t, 255 & n),
//        e.setUint8(i + 1 + 2 * t + 1, n >>> 8)
//      }
//      i += 2 * ot.length
//    } else e.setUint8(i, 0);
//    i++,
//    e.setInt16(i, un, !0),
//    Ue.send(e.buffer),
//    Rt = !0