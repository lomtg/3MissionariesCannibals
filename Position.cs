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
        public Position DeepCopy()
        {
            Position deepCopyPosition = new Position()
            {
                Boat = this.Boat,
                MissionariesLeft = this.MissionariesLeft,
                CannibalsLeft = this.CannibalsLeft,
                MissionariesRight = this.MissionariesRight,
                CannibalsRight = this.CannibalsRight
            };
            return deepCopyPosition;
        }

        public List<Position> Path = new List<Position>();
    }
}
