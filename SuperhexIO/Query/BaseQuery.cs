using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Query
{
    public abstract class BaseQuery
    {
        public readonly byte code;
        public BaseQuery(int code)
        {
            this.code = (byte)code;
        }
        public override int GetHashCode()
        {
            return code;
        }

        public abstract void Handle(byte[] buffer);
    }
}
