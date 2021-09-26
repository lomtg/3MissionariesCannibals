using System;
using System.Collections.Generic;
using System.Linq;

namespace _3MissionariesCannibals
{
    class Program
    {
        static int depth = 0;
        static void Main(string[] args)
        {
            List<PossibleBoatPassengers> possibleBoats = new List<PossibleBoatPassengers>()
            {
                new PossibleBoatPassengers{Missionarie = 1, Cannibale = 0 },
                new PossibleBoatPassengers{Missionarie = 0, Cannibale = 2 },
                new PossibleBoatPassengers{Missionarie = 1, Cannibale = 1 },
                new PossibleBoatPassengers{Missionarie = 0, Cannibale = 1 },
                new PossibleBoatPassengers{Missionarie = 2, Cannibale = 0 },
            };


            Position startingPos = new Position()
            {
                Boat = true,
                CannibalsLeft = 3,
                MissionariesLeft = 3,
                CannibalsRight = 0,
                MissionariesRight = 0
            };

            List<Position> list = new List<Position>();

            list.Add(startingPos);

            int counter = 0;
            while(true)
            {
                Console.WriteLine(counter++);
                if (list.Count == 0) break;

                Position currentPosition = list[0];
                list.RemoveAt(0);

                foreach(var possiblePassengers in possibleBoats)
                {
                    Position newPos = (Position)currentPosition.Clone();
                    if(currentPosition.Boat)
                    {
                        newPos.CannibalsLeft -= possiblePassengers.Cannibale;
                        newPos.MissionariesLeft -= possiblePassengers.Missionarie;
                        newPos.CannibalsRight += possiblePassengers.Cannibale;
                        newPos.MissionariesRight += possiblePassengers.Missionarie;
                        newPos.Boat = false;
                    }
                    else
                    { 
                        newPos.CannibalsLeft += possiblePassengers.Cannibale;
                        newPos.MissionariesLeft += possiblePassengers.Missionarie;
                        newPos.CannibalsRight -= possiblePassengers.Cannibale;
                        newPos.MissionariesRight -= possiblePassengers.Missionarie;
                        newPos.Boat = true;
                    }
                    if(CheckRules(newPos,list))
                    {
                        newPos.PositionBefore = currentPosition;
                        list.Add(newPos);
                    }
                    //Console.WriteLine("First iteration ended");
                    //Console.ReadKey();
                    if(currentPosition.CannibalsRight == 3 && currentPosition.MissionariesRight == 3)
                    {
                        Console.ReadKey();
                        Console.WriteLine("WIN");
                        //Console.WriteLine(currentPosition.CannibalsLeft + " " + currentPosition.MissionariesLeft);
                        //Console.WriteLine(currentPosition.CannibalsRight + " " + currentPosition.MissionariesRight);
                        PrintPath(currentPosition); 
                    }
                }
                    //if (currentPosition.PositionBefore != null)
                    //    {
                    //        Console.WriteLine(currentPosition.PositionBefore.CannibalsLeft + " " + currentPosition.PositionBefore.MissionariesLeft);
                    //        Console.WriteLine(currentPosition.PositionBefore.CannibalsRight + " " + currentPosition.PositionBefore.MissionariesRight);
                    //    }
                    //foreach(var p in list)
                    //    {
                    //        Console.WriteLine(p.CannibalsLeft + " " + p.MissionariesLeft);
                    //        Console.WriteLine(p.CannibalsRight + " " + p.MissionariesRight);
                    //    }
                    //Console.WriteLine("END!");
            }

        }


        static bool CheckRules(Position p,List<Position> list)
        {
            if (p.CannibalsLeft > p.MissionariesLeft && p.MissionariesLeft != 0) return false;
            if (p.CannibalsRight > p.MissionariesRight && p.MissionariesRight != 0) return false;
            if (p.CannibalsLeft < 0 || p.CannibalsRight < 0 || p.MissionariesLeft < 0 || p.MissionariesRight < 0) return false;
            if (list.Any(x => x.CannibalsLeft == p.CannibalsLeft &&
                              x.MissionariesLeft == p.MissionariesLeft &&
                              x.MissionariesRight == p.MissionariesRight &&
                              x.CannibalsRight == p.CannibalsRight &&
                              x.Boat == p.Boat
            )) return false;
            return true;
        }
        

        static void PrintPath(Position p)
        {
            Console.WriteLine(depth++);
            if (p.PositionBefore != null) PrintPath(p);
            Console.WriteLine("---------------");
            Console.WriteLine("Cannibals and Missionares on left " + p.CannibalsLeft + ' ' + p.MissionariesLeft);
            Console.WriteLine("Cannibals and Missionares on right " + p.CannibalsRight + ' ' + p.MissionariesRight);
            Console.WriteLine("---------------");
        }
    }
}
