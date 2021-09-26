using System;
using System.Collections.Generic;
using System.Text;

namespace _3MissionariesCannibals
{
    class Position
    {
        public bool Boat { get; set; }
        public int MissionariesLeft  { get; set; }
        public int CannibalsLeft { get; set; }
        public int MissionariesRight { get; set; }
        public int CannibalsRight { get; set; }
        public Position PositionBefore { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
