using SuperhexIO.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Query
{
    public class SelfMovement : BaseQuery
    {
        public SelfMovement(int code) : base(code)
        {
        }

        public override void Handle(byte[] buffer)
        {
            float x = buffer.ToFloat32(1);
            float y = buffer.ToFloat32(5);
            float dir = buffer.ToFloat32(9);
            float targetDir = buffer.ToFloat32(13);
            Console.WriteLine($"X {x} Y{y} dir {dir} targetDIR {targetDir}");
        }
    }
}

//function se(e)
//{
//    var t = (e.getFloat32(1, !0), e.getFloat32(5, !0), e.getFloat32(9, !0), e.getFloat32(13, !0));
//    Bt[Gt] = t
//  }
