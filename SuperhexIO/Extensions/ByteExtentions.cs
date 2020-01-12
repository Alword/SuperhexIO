using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Extensions
{
    public static class ByteExtentions
    {
        public const int SIZEOFINT16 = sizeof(short);
        public const int SIZEOFFLOAT32 = sizeof(float);

        public static short ToInt16(this byte[] buffer, int start, bool littleEndian = true)
        {
            var slice = buffer.SubByte(start, SIZEOFINT16);
            return BitConverter.ToInt16(slice);
        }

        public static float ToFloat32(this byte[] buffer, int start, bool littleEndian = true)
        {
            var slice = buffer.SubByte(start, SIZEOFFLOAT32);
            return BitConverter.ToSingle(slice);
        }
        public static byte[] SubByte(this byte[] buffer, int start, int size) => buffer[start..(start + size)];
    }
}
