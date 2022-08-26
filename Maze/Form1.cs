using System.ComponentModel;
using System.Reflection;

namespace Maze
{
    public partial class Form1 : Form
    {
        MazeGenerator mazeGenerator;
        bool isMazeGenerated = false;
        Thread solveThread;

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

        // initiating generation animation
        private void createButton_Click(object sender, EventArgs e)
        {
            mazeGenerator.Initialize(slideBar.Value);
            timer.Start();
        }

        // drawing maze on panel
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

        // initiating solving animation
        private void solveButton_Click(object sender, EventArgs e)
        {
            if (isMazeGenerated)
            {
                // disabling track bar and create button
                slideBar.Enabled = false;
                createButton.Enabled = false;
                // starting new thread which executes solving maze
                // when solving is done, track bar and create button are enabled again
                solveThread = new Thread(() =>
                                {
                                    Thread.CurrentThread.IsBackground = true;
                                    if (mazeGenerator.SolveMaze())
                                    {
                                        slideBar.Invoke((MethodInvoker)delegate {
                                            slideBar.Enabled = true;
                                        });
                                        createButton.Invoke((MethodInvoker)delegate {
                                            createButton.Enabled = true;
                                        });
                                    }
                                    panel.Invalidate();
                                    Console.WriteLine("Hello, world");
                                });
                solveThread.Start();            
            }
        }

        // track bar which allows to choose maze size
        private void slideBar_ValueChanged(object sender, EventArgs e)
        {
            // when value is changed stop generating maze
            timer.Stop();

            int trackValue = slideBar.Value;
            // if slideBar.Value is even make it odd (because due to how generation algorithm works maze can be only of odd size)
            if (trackValue % 2 == 0)
            {
                trackValue--;
                slideBar.Value = trackValue;
            }
            // update label text
            label.Text = "Size: " + slideBar.Value + "x" + slideBar.Value;
            isMazeGenerated = false;
            solveButton.Enabled = false;
            // initializing maze with new size so it is displayed correctly
            mazeGenerator.Initialize(slideBar.Value);
            panel.Refresh();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // when maze generation is over AnimateMazeGeneration returns true and timer is stopped
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
