using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Models
{
    public struct PlayerTranslation
    {
        public int PlayerId;
        public float X;
        public float Y;
        public float Dir;
        public float TargetDir;
        public long time;

        public override string ToString()
        {
            return $"PlayerId {PlayerId}, X {X}, Y {Y}, Dir {Dir}, TargetDir {TargetDir}, Time {time}";
        }
    }
}
