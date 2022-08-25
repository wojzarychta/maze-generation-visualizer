using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Cell
    {

        bool visited;             //zmienna do tworzenia losowego labiryntu; czy pole zostało już odwiedzone
        bool topWall;                 //zmienna do tworzenia losowego labiryntu; czy można przejść przez górną ścianę komórki
        bool botWall;                 //zmienna do tworzenia losowego labiryntu; czy można przejść przez dolną ścianę komórki
        bool leftWall;                //zmienna do tworzenia losowego labiryntu; czy można przejść przez lewą ścianę komórki
        bool rightWall;               //zmienna do tworzenia losowego labiryntu; czy można przejść przez prawą ścianę komórki
        bool path;
        bool solution;

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
