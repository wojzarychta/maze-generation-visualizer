using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Timer = System.Windows.Forms.Timer;

namespace Maze
{
    class MazeGenerator
    {
        const int UP = 0;
        const int DOWN = 1;
        const int RIGHT = 2;
        const int LEFT = 3;
        int mazeSize = 29;
        Cell[,] maze;
        Point startCell, finishCell;
        Panel panel;
        Point currentCell;
        Stack stack;

        internal Cell[,] Maze { get => maze; set => maze = value; }
        public int MazeSize { get => mazeSize; set => mazeSize = value; }
        public Point CurrentCell { get => currentCell; set => currentCell = value; }
        public Point StartCell { get => startCell; set => startCell = value; }
        public Point FinishCell { get => finishCell; set => finishCell = value; }

        public MazeGenerator(Panel _panel)
        {
            panel = _panel;
            Initialize();
        }

        public void Initialize(int size = 25)
        {
            //funckja przygotowywuje komórki labiryntu pod jego generowanie
            MazeSize = size;
            StartCell = new Point(1, MazeSize - 2);
            FinishCell = new Point(MazeSize - 2, 1);
            CurrentCell = new Point((Size)StartCell);

            Maze = new Cell[MazeSize, MazeSize];
            for (int i = 0; i < MazeSize; i++)
            {
                for (int j = 0; j < MazeSize; j++)
                {
                    Maze[i, j] = new Cell();
                    Maze[i, j].Visited = false;
                    Maze[i, j].TopWall = true;
                    Maze[i, j].BotWall = true;
                    Maze[i, j].RightWall = true;
                    Maze[i, j].LeftWall = true;
                    Maze[i, j].Path = false;
                    Maze[i, j].Solution = false;
                }
            }
            //ściany labiryntu ograniczają labirynt, tak, aby algorytm generujący nie wyszedł poza labirynt:
            for (int i = 1; i < MazeSize; i++)
            {
                for (int j = 1; j < MazeSize; j++)
                {
                    Maze[1, j].TopWall = false;
                    Maze[MazeSize - 2, j].BotWall = false;
                    Maze[i, MazeSize - 2].RightWall = false;
                    Maze[i, 1].LeftWall = false;
                }
            }

            Maze[StartCell.Y, StartCell.X].Path = true;

            stack = new Stack();
            stack.Push(currentCell);
        }

        public void GenerateMaze(int size = 25)
        {   //generator losowego labiryntu
            Initialize(size);

            while (stack.Count != 0)
            {
                FindNextCell(ref stack);
            }

        }

        public bool AnimateMazeGeneration()
            // calling Initialize() beforehand is neccessary
        {
            FindNextCell(ref stack);
            return stack.Count == 0;
        }

        void FindNextCell(ref Stack stack)
        {
            if (((currentCell.Y - 2 > 0 && Maze[currentCell.Y - 2, currentCell.X].Visited == false) && (Maze[currentCell.Y, currentCell.X].TopWall == true) && (Maze[currentCell.Y - 2, currentCell.X].BotWall == true)) ||
                   ((currentCell.Y + 2 < MazeSize && Maze[currentCell.Y + 2, currentCell.X].Visited == false) && (Maze[currentCell.Y, currentCell.X].BotWall == true) && (Maze[currentCell.Y + 2, currentCell.X].TopWall == true)) ||
                   ((currentCell.X - 2 > 0 && Maze[currentCell.Y, currentCell.X - 2].Visited == false) && (Maze[currentCell.Y, currentCell.X].LeftWall == true) && (Maze[currentCell.Y, currentCell.X - 2].RightWall == true)) ||
                   ((currentCell.X + 2 < MazeSize && Maze[currentCell.Y, currentCell.X + 2].Visited == false) && (Maze[currentCell.Y, currentCell.X].RightWall == true) && (Maze[currentCell.Y, currentCell.X + 2].LeftWall == true)))
            {
                Random random = new Random();
                int direction = random.Next(4) % 4;

                switch (direction)
                {
                    case UP:
                        {
                            if (currentCell.Y > 1 && Maze[currentCell.Y - 2, currentCell.X].Visited == false)
                            {
                                BreakWall(UP, stack, ref currentCell);
                            }
                        }
                        break;
                    case DOWN:
                        {
                            if (currentCell.Y < MazeSize - 2 && Maze[currentCell.Y + 2, currentCell.X].Visited == false)
                            {
                                BreakWall(DOWN, stack, ref currentCell);
                            }

                        }
                        break;
                    case RIGHT:
                        {
                            if (currentCell.X < MazeSize - 2 && Maze[currentCell.Y, currentCell.X + 2].Visited == false)
                            {
                                BreakWall(RIGHT, stack, ref currentCell);
                            }

                        }
                        break;
                    case LEFT:
                        {
                            if (currentCell.X > 1 && Maze[currentCell.Y, currentCell.X - 2].Visited == false)
                            {
                                BreakWall(LEFT, stack, ref currentCell);
                            }

                        }
                        break;
                }
            }
            else
            {
                //if point doesn't meet the condition, get last point on stack and then pop it up from stack
                currentCell = (Point)stack.Peek();
                stack.Pop();
            }
        }

        void BreakWall(int direction, Stack stack, ref Point p)
        // function is responsible for 'destroying' walls in certain direction and therefore creating path in maze
        {
            stack.Push(p);
            switch (direction)
            {
                case UP:
                    {
                        Maze[p.Y - 1, p.X].Visited = true;
                        Maze[p.Y - 1, p.X].Path = true;
                        Maze[p.Y, p.X].TopWall = false;
                        p.Y -= 2;
                        Maze[p.Y, p.X].BotWall = false;
                    }
                    break;
                case DOWN:
                    {
                        Maze[p.Y + 1, p.X].Visited = true;
                        Maze[p.Y + 1, p.X].Path = true;
                        Maze[p.Y, p.X].BotWall = false;
                        p.Y += 2;
                        Maze[p.Y, p.X].TopWall = false;
                    }
                    break;
                case RIGHT:
                    {
                        Maze[p.Y, p.X + 1].Visited = true;
                        Maze[p.Y, p.X + 1].Path = true;
                        Maze[p.Y, p.X].RightWall = false;
                        p.X += 2;
                        Maze[p.Y, p.X].LeftWall = false;
                    }
                    break;
                case LEFT:
                    {
                        Maze[p.Y, p.X - 1].Visited = true;
                        Maze[p.Y, p.X - 1].Path = true;
                        Maze[p.Y, p.X].LeftWall = false;
                        p.X -= 2;
                        Maze[p.Y, p.X].RightWall = false;
                    }
                    break;
            }
            Maze[p.Y, p.X].Visited = true;
            Maze[p.Y, p.X].Path = true;
        }

        public void AnimateSolvingMaze(Timer timer)
        {
            //if (FindPath() == )
        }

        bool FindPath(Point p)
        {
            currentCell = p;
            panel.Refresh();
            Thread.Sleep(20);

            if (p.X == FinishCell.X && p.Y == FinishCell.Y)
            {               //jeśli dojdzie do mety, zwraca prawdę i algorytm zakończy działanie
                maze[p.Y, p.X].Solution = true;
                return true;
            }


            if (maze[p.Y, p.X].Path == true && maze[p.Y, p.X].Solution == false)
            {          //sprawdza czy można wejść na dane pole
                maze[p.Y, p.X].Solution = true;                                         //dodaje pole do rozwiązania
                                                                                        //rekurencyjnie wywołuje poniższe funckje, które będą zwaracać prawdę dopóki znajdować będą drogę
                if (FindPath(new Point(p.X + 1, p.Y)) == true) return true;
                if (FindPath(new Point(p.X, p.Y - 1)) == true) return true;
                if (FindPath(new Point(p.X, p.Y + 1)) == true) return true;
                if (FindPath(new Point(p.X - 1, p.Y)) == true) return true;

                //jeśli nie znalazł drogi, usuwa pole z rozwiązania oraz zwraca fałsz
                maze[p.Y, p.X].Solution = false;
                return false;
            }
            return false;
        }

        public void SolveMaze()
        {
            currentCell = new Point((Size)StartCell);
            FindPath(StartCell);
        }

    }
}
