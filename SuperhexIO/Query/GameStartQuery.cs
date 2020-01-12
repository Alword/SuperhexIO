using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Query
{
    class GameStartQuery : BaseQuery
    {
        public GameStartQuery(byte code) : base(code)
        {

        }

        public override void Handle(byte[] buffer)
        {
            Console.WriteLine($"{code}: Game START!");
        }
    }
}
