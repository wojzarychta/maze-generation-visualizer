using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Cell
    {
        bool visited;               // true if generating algorithm was on the cell
        bool topWall;               // true if generating algorithm can cross top wall of the cell
        bool botWall;               // see above
        bool leftWall;              // see above
        bool rightWall;             // see above
        bool path;                  // true if cell is part of maze path (not being wall)
        bool solution;              // true if cell is part of path connecting statr cell and destination cell

        public bool Visited {
            get { return visited; }
            set { visited = value;}
        }
        public bool TopWall
        {
            get { return topWall; }
            set { topWall = value; }
        }
        public bool BotWall
        {
            get { return botWall; }
            set { botWall = value; }
        }
        public bool LeftWall
        {
            get { return leftWall; }
            set { leftWall = value; }
        }
        public bool RightWall
        {
            get { return rightWall; }
            set { rightWall = value; }
        }
        public bool Path
        {
            get { return path; }
            set { path = value; }
        }
        public bool Solution
        {
            get { return solution; }
            set { solution = value; }
        }
    }
}
