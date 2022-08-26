using System.ComponentModel;
using System.Reflection;

namespace Maze
{
    public partial class Form1 : Form
    {
        MazeGenerator mazeGenerator;
        bool isMazeGenerated = false;

        public Form1()
        {
            InitializeComponent();
            labelMinimumValue.Text = slideBar.Minimum.ToString();
            labelMaximumValue.Text = slideBar.Maximum.ToString();
            label.Text = "Size: " + slideBar.Value + "x" + slideBar.Value;

            DoubleBuffered = true;
            mazeGenerator = new MazeGenerator(panel);
            mazeGenerator.Initialize(slideBar.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // enabling double buffering for panel 
            typeof(Panel).InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null,
            panel,
            new object[] { true });
        }


        private void createButton_Click(object sender, EventArgs e)
        {
            mazeGenerator.Initialize(slideBar.Value);
            timer.Start();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Cell[,] maze = mazeGenerator.Maze;
            Brush color;
            int cellWidth = panel.Width / mazeGenerator.MazeSize;
            int cellHeight = panel.Height / mazeGenerator.MazeSize;
            for (int j = 0; j < maze.GetLength(0); j++)
            {
                for (int i = 0; i < maze.GetLength(1); i++)
                {
                    if (mazeGenerator.CurrentCell.X == i && mazeGenerator.CurrentCell.Y == j)
                        color = Brushes.Yellow;
                    else if ((mazeGenerator.StartCell.X == i && mazeGenerator.StartCell.Y == j) || (mazeGenerator.FinishCell.X == i && mazeGenerator.FinishCell.Y == j))
                        color = Brushes.Green;
                    else if (maze[j,i].Solution == true)
                        color = Brushes.Red;
                    else if (maze[j,i].Path == true)
                        color = Brushes.White;
                    else
                        color = Brushes.Black;

                    canvas.FillRectangle(color, new Rectangle(new Point(i * cellWidth, j * cellHeight), new Size(cellWidth, cellHeight)));
                }
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            if (isMazeGenerated)
            {
                mazeGenerator.SolveMaze();
                panel.Invalidate();
            }
        }

        private void slideBar_ValueChanged(object sender, EventArgs e)
        {
            timer.Stop();
            int trackValue = slideBar.Value;


            if (trackValue % 2 == 0)
            {
                trackValue--;

                slideBar.Value = trackValue;

            }

            label.Text = "Size: " + slideBar.Value + "x" + slideBar.Value;
            isMazeGenerated = false;
            solveButton.Enabled = false;
            mazeGenerator.Initialize(slideBar.Value);
            panel.Refresh();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (mazeGenerator.AnimateMazeGeneration())
            {
                isMazeGenerated = true;
                timer.Stop();
                solveButton.Enabled = true;
            }
            panel.Refresh();
        }


    }
}
