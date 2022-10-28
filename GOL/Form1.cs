using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOL {
    public partial class Form1 : Form {

        static int speed = 500; // время итерации

        public static int WidthX = 200; // размер поля по X
        public static int WidthY = 300; // размер поля по Y 

        //const int WidthX = 325; // X dimension of cell grid
        //const int WidthY = 165; // Y dimension of cell grid

        public static int oldWidthX = WidthX; // X dimension of cell grid
        public static int oldWidthY = WidthY; // Y dimension of cell grid



        static Grid MainGrid = new Grid(WidthY, WidthX);

        // стандартные кисти цветов
        SolidBrush dotcolor = new SolidBrush(Color.LavenderBlush);
        SolidBrush backColorBrush = new SolidBrush(Color.DarkGray);

        // стандартные настройки генома клетки
        public bool[] genomeSetting = new bool[9] { false, false, false, false, false, false, false, false, false };

        //втф
        const int Xoffset = 160; //X offset from upper left corner of window
        const int Yoffset = 40;

        public static int cellSize = 6;    // размер клетки
        public static int borderSize = 1;   // размер границы
        public static int gridSize = cellSize + borderSize; // размер сетки
        

        public static bool gridChanged = false;
        public static bool T1wasRunning = false;

        //fullscreen stuff
        bool showFullScreen = false;
        Point oldLocation;
        bool hideControls = false;

        //brush 0 selected
        uint drawMode = 0;

        //Bitmap bmp = new Bitmap((WidthX * gridSize) + ((gridSize / 2) % 2 == 0 ? gridSize / 2 : gridSize / 2 + 1), (WidthY * gridSize) + ((gridSize / 2) % 2 == 0 ? gridSize / 2 : gridSize / 2 + 1));
        Bitmap bmp = new Bitmap((WidthX * gridSize) + (gridSize / 2), (WidthY * gridSize) + (gridSize / 2));

        static string patternCustomFileName = "pictures\\GOL1.bmp";

        static Tuple<int, int> mousePos = new Tuple<int, int>(0, 0);
        static Tuple<int, int> oldMousePos = new Tuple<int, int>(0, 0);
        static bool isMouseOverPic = false;



        Stopwatch frameStopwatch = new Stopwatch();
        double frameCounter = 0;
        double drawAvg = 0;
        double calcAvg = 0;


        
        //SolidBrush shadowcolor = new SolidBrush(Color.LightSalmon);

        
        //static Automata.FieldCell[,] board = new Automata.FieldCell[WidthX, WidthY];
        //static Automata.FieldCell[,] oldboard = new Automata.FieldCell[WidthX, WidthY];
        //static Automata.FieldCell[][,] rgbboardhistory = new Automata.FieldCell[7][,]; //[ new bool[WidthX,WidthY]; // = new bool[,]>();



        static Random rand = new Random();


        public static Timer timer1 = new Timer();

        public static Timer timer2 = new Timer();

        static Timer timer3 = new Timer();

        Bitmap image1;


        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
        //[DllImport("user32.dll")]
        //public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        /// <summary>
        /// Create a cursor from a bitmap without resizing and with the specified
        /// hot spot
        /// </summary>
        //public static Cursor CreateCursorNoResize(Bitmap bmp, int xHotSpot, int yHotSpot) {
        //    IntPtr ptr = bmp.GetHicon();
        //    IconInfo tmp = new IconInfo();
        //    GetIconInfo(ptr, ref tmp);
        //    tmp.xHotspot = xHotSpot;
        //    tmp.yHotspot = yHotSpot;
        //    tmp.fIcon = false;
        //    ptr = CreateIconIndirect(ref tmp);
        //    return new Cursor(ptr);
        //}



        public Form1() {
            InitializeComponent();

            resizePicBox();

            this.KeyPreview = true;

            int sizeX = (WidthX * gridSize) + /*(gridSize / 2)*/ + 5*borderSize;
            int sizeY = (WidthY * gridSize) + /*(gridSize / 2)*/ + 5*borderSize;

            //pictureBox1.Width = (WidthX + 1) * gridSize - (gridSize / 2);
            //pictureBox1.Height = (WidthY + 1) * gridSize - (gridSize / 2);

            pictureBox1.Width = sizeX;
            pictureBox1.Height = sizeY;

            Width = /*(WidthX + 1) * gridSize */sizeX + 220;
            Height = /*(WidthY + 1) * gridSize*/sizeY + 60;
            
            

            // фон
            using (var g = Graphics.FromImage(bmp)) {
                g.FillRectangle(backColorBrush, 0, 0, sizeX, sizeY);


                ////FillRectangle(g, backColorBrush, 0, 0, (WidthX * gridSize) + 2 * gridSize + (gridSize / 2), (WidthY * gridSize) + 2 * gridSize + (gridSize / 2))
                //Rectangle rect = new Rectangle(0, 0, (WidthX * gridSize) + 2 * gridSize + (gridSize / 2), (WidthY * gridSize) + 2 * gridSize + (gridSize / 2));

                //// Fill rectangle to screen.
                //g.FillRectangle(backColorBrush, rect);

                this.pictureBox1.Image = bmp;
            }



            //for (int n = 0; n < 7; n++)
            //    rgbboardhistory[n] = new Automata.FieldCell[WidthX, WidthY];



            //for (int i = 0; i < WidthX; i++)
            //    for (int j = 0; j < WidthY; j++) {

            //        board[i, j] = new Automata.FieldCell();
            //    }
            MainGrid.Clear();
            drawBoard();

            timer1.Interval = speed;
            timer1.Tick += Timer1_Tick;

            timer2.Interval = 333;
            timer2.Tick += Timer2_Tick;

            timer3.Interval = 30;
            timer3.Tick += Timer3_Tick;

        }


        private void resizePicBox() {
            //this.Size = new Size(WidthX * gridSize - 220, WidthY * gridSize - 120);

            //pictureBox1.Width = ((WidthX * gridSize) + (gridSize / 2 + (gridSize % 2 > 0 ? 1 : 0))); // x/y + (x % y > 0 ? 1 : 0)
            //pictureBox1.Height = ((WidthY * gridSize) + (gridSize / 2 + (gridSize % 2 > 0 ? 1 : 0)));
            //pictureBox1.Refresh();


        }

        private void Timer1_Tick(object sender, EventArgs e) {


            frameStopwatch.Start();
            //board = calculateNextBoard();
            //board = algorithm.calculateNextBoard(board);

            //board = calculateNextBoard(board);
                
            //Grid.NextGen
            frameStopwatch.Stop();
            calcAvg += (double)frameStopwatch.Elapsed.TotalMilliseconds;
            frameStopwatch.Reset();

            frameStopwatch.Start();
            MainGrid.NextGen();
            //if (drawMode == 0)
            //    drawChangedCells(oldboard, board);
            drawBoard();
            frameStopwatch.Stop();
            drawAvg += (double)frameStopwatch.Elapsed.TotalMilliseconds;
            frameStopwatch.Reset();

            frameCounter++;

        }

        private void Timer2_Tick(object sender, EventArgs e) {
            double drawavg = drawAvg / frameCounter;
            double calcavg = calcAvg / frameCounter;
            //label5.Text = calcavg.ToString("0.000") + " ms";
            //label6.Text = drawavg.ToString("0.000") + " ms";
            //label4.Text = ((drawAvg + calcAvg) / frameCounter).ToString("0.000") + " ms";
            frameCounter = 0;
            drawAvg = 0;
            calcAvg = 0;

        }

        private void Timer3_Tick(object sender, EventArgs e) {
            drawBoard();
            //using (var g = Graphics.FromImage(bmp)) {
            //    delPreviewImage(g, oldMousePos.Item1, oldMousePos.Item2);

            //    oldMousePos = mousePos;

            //    if (isMouseOverPic == true) {
            //        previewImage(g, oldMousePos.Item1, oldMousePos.Item2);

            //    }
            //}
        }

        private void buttonStartStopClick(object sender, EventArgs e) {
            if (timer1.Enabled) {
                buttonStartStop.Text = "Start / Stop";
                timer1.Stop();
                timer2.Stop();
            }
            else {
                buttonStartStop.Text = "Stop";
                timer1.Start();
                timer2.Start();
            }

        }

        private void stopTimer() {
            if (timer1.Enabled) {
                buttonStartStop.Text = "Start / Stop";
                timer1.Stop();
                timer2.Stop();
            }
        }

        void createRandomBoard() {
            Random rand = new Random();
            for (int i = 0; i < MainGrid.Cols; i++)
                for (int j = 0; j < MainGrid.Rows; j++) {
                    bool rnd = rand.NextDouble() > 0.5;
                    if (rnd) MainGrid.gridCells[i,j] = new Cell();
                    else MainGrid.gridCells[i,j] = new Cell(new bool[]{ rand.NextDouble() > 0.9, rand.NextDouble() > 0.9, rand.NextDouble() > 0.9, rand.NextDouble() > 0.9, rand.NextDouble() > 0.9, rand.NextDouble() > 0.9, rand.NextDouble() > 0.9, rand.NextDouble() > 0.9, rand.NextDouble() > 0.9 });
                }
        }

        void drawBoard() {
            //Graphics myGraphics = base.CreateGraphics();
            // Pen myPen = new Pen(Color.Red);
            // Pen blankPen = new Pen(BackColor);
            //SolidBrush mySolidBrush = dotcolor;
            //SolidBrush myBlankBrush = backcolor;
            //myGraphics.DrawEllipse(myPen, 50, 50, 150, 150);


            using (var g = Graphics.FromImage(bmp)) {
                for (int i = 0; i < WidthX; i++)
                    for (int j = 0; j < WidthY; j++) {

                        if (MainGrid[i, j].IsAlive)
                            FillRectangle(g, new SolidBrush(MainGrid[i, j].Color), i * gridSize + (gridSize / 2) + 2 * borderSize, j * gridSize + (gridSize / 2) + 2 * borderSize, cellSize);
                        else
                            FillRectangle(g, backColorBrush, i * gridSize + (gridSize / 2) + 2 * borderSize, j * gridSize + (gridSize / 2) + 2 * borderSize, cellSize);

                    }
                this.pictureBox1.Image = bmp;
            }

        }



        //void drawChangedCells(Automata.FieldCell[,] oldboard, Automata.FieldCell[,] Tempboard) {

        //    using (var g = Graphics.FromImage(bmp)) {
        //        delPreviewImage(g, oldMousePos.Item1, oldMousePos.Item2);


        //        for (int i = 0; i < WidthX; i++) {
        //            for (int j = 0; j < WidthY; j++) {
        //                if ((oldboard[i, j].fd == false) && (Tempboard[i, j].fd == true))
        //                    GraphicsExtensions.FillRectangle(g, new SolidBrush(Tempboard[i, j].getColor()), i * gridSize + cellSize, j * gridSize + cellSize, cellSize);
        //                else if ((oldboard[i, j].fd == true) && (Tempboard[i, j].fd == false))
        //                    GraphicsExtensions.FillRectangle(g, backcolor, i * gridSize + cellSize, j * gridSize + cellSize, cellSize);
        //            }
        //        }

        //        oldMousePos = mousePos;

        //        if (isMouseOverPic == true) {
        //            previewImage(g, oldMousePos.Item1, oldMousePos.Item2);

        //        }

        //        this.pictureBox1.Image = bmp;
        //    }

        //}

        

        private void pictureBox1_Click(object sender, EventArgs e) {
            MouseEventArgs me = (MouseEventArgs)e;
            //Point coordinates = me.Location;
            //Debug.WriteLine(coordinates.ToString());
            if (me.Button == MouseButtons.Left)
                DrawCell(me.X, me.Y);
                //loadImagetoPos("1pxblack.BMP", coordinates.X, coordinates.Y);


            if (timer1.Enabled == false)
                drawBoard();
        }

        private void DrawCell(int mouseX, int mouseY) {
            
            // Determine grid index from grid location and cell size.
            int locX = (mouseX - (gridSize / 2) + 2) / gridSize;
            int locY = (mouseY - (gridSize / 2) + 2) / gridSize;

            if (locX >= MainGrid.Cols || locY >= MainGrid.Rows) return;

            // Flip cell status between dead and alive.
            ref Cell temp = ref MainGrid[locX, locY];
            
            if (!temp.IsAlive) temp = new Cell(genomeSetting);
            else temp.IsAlive = false;
            using (var g = Graphics.FromImage(bmp)) {
                FillRectangle(g, new SolidBrush(temp.Color), locX * gridSize + (gridSize / 2) + 2 * borderSize, locY * gridSize + (gridSize / 2) + 2 * borderSize, cellSize);

            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {

            if (e.Button == MouseButtons.Left)
                if (e.X >= 0 && e.Y >= 0)
                    DrawCell(e.X, e.Y);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e) {
            isMouseOverPic = true;
            pictureBox1.Cursor = Cursors.Cross;
            if (timer1.Enabled == false)
                timer3.Start();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e) {
            isMouseOverPic = false;
            pictureBox1.Cursor = Cursors.Default;
            if (timer1.Enabled == false)
                timer3.Stop();
            using (var g = Graphics.FromImage(bmp)) {
                //delPreviewImage(g, oldMousePos.Item1, oldMousePos.Item2);
                oldMousePos = mousePos;

            }
        }



        //private void GoFullscreen(bool fullscreen) {
        //    if (fullscreen) {


        //        if (timer1.Enabled) {
        //            timer1.Stop();
        //            timer2.Stop();
        //            T1wasRunning = true;
        //        }

        //        var newbounds = Screen.PrimaryScreen.Bounds;
        //        int newWidthX = newbounds.Width / gridSize;
        //        int newWidthY = newbounds.Height / gridSize;

        //        Automata.FieldCell[,] newboard = new Automata.FieldCell[newWidthX, newWidthY];
        //        Automata.FieldCell[,] newoldboard = new Automata.FieldCell[newWidthX, newWidthY];


        //        oldLocation = pictureBox1.Location;
        //        pictureBox1.Location = new Point(0, 0);
        //        pictureBox1.Width = newbounds.Width;
        //        pictureBox1.Height = newbounds.Height;
        //        pictureBox1.SendToBack();

        //        bmp = null;
        //        bmp = new Bitmap((newWidthX * gridSize) + (2 * gridSize), (newWidthY * gridSize) + (2 * gridSize), System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

        //        using (var g = Graphics.FromImage(bmp)) {

        //            Rectangle rect = new Rectangle(0, 0, (newWidthX * gridSize) + 2 * gridSize + (gridSize / 2), (newWidthY * gridSize) + 2 * gridSize + (gridSize / 2));

        //            // Fill rectangle to screen.
        //            g.FillRectangle(backcolor, rect);

        //            this.pictureBox1.Image = bmp;
        //        }

        //        if (WidthX <= newWidthX) {
        //            for (int x = 0; x < WidthX; x++) {
        //                if (WidthY <= newWidthY) {
        //                    for (int y = 0; y < WidthY; y++) {
        //                        newboard[x, y] = board[x, y];
        //                        newoldboard[x, y] = oldboard[x, y];
        //                    }
        //                }
        //                else {
        //                    for (int y = 0; y < newWidthY; y++) {
        //                        newboard[x, y] = board[x, y];
        //                        newoldboard[x, y] = oldboard[x, y];
        //                    }
        //                }

        //            }
        //        }
        //        else {
        //            for (int x = 0; x < newWidthX; x++) {
        //                if (WidthY <= newWidthY) {
        //                    for (int y = 0; y < WidthY; y++) {
        //                        newboard[x, y] = board[x, y];
        //                        newoldboard[x, y] = oldboard[x, y];
        //                    }
        //                }
        //                else {
        //                    for (int y = 0; y < newWidthY; y++) {
        //                        newboard[x, y] = board[x, y];
        //                        newoldboard[x, y] = oldboard[x, y];
        //                    }
        //                }

        //            }
        //        }

        //        //board = new bool[newWidthX, newWidthY];
        //        board = newboard;
        //        //oldboard = new bool[newWidthX, newWidthY];
        //        oldboard = newoldboard;

        //        newboard = null;
        //        newoldboard = null;


        //        oldWidthX = WidthX;
        //        oldWidthY = WidthY;
        //        WidthX = newWidthX;
        //        WidthY = newWidthY;

        //        drawBoard();

        //        if (T1wasRunning) {
        //            timer1.Start();
        //            timer2.Start();
        //            T1wasRunning = false;
        //        }

        //        this.WindowState = FormWindowState.Normal;
        //        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        //        this.Bounds = Screen.PrimaryScreen.Bounds;
        //    }
        //    else // exit fullscreen
        //    {
        //        if (timer1.Enabled) {
        //            timer1.Stop();
        //            timer2.Stop();
        //            T1wasRunning = true;
        //        }



        //        pictureBox1.Location = oldLocation;
        //        pictureBox1.Width = oldWidthX * gridSize;
        //        pictureBox1.Height = oldWidthY * gridSize;

        //        //bmp = null;
        //        bmp = new Bitmap((oldWidthX * gridSize) + (2 * gridSize), (oldWidthY * gridSize) + (2 * gridSize), System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
        //        using (var g = Graphics.FromImage(bmp)) {

        //            Rectangle rect = new Rectangle(0, 0, (oldWidthX * gridSize) + 2 * gridSize + (gridSize / 2), (oldWidthY * gridSize) + 2 * gridSize + (gridSize / 2));

        //            // Fill rectangle to screen.
        //            g.FillRectangle(backcolor, rect);

        //            this.pictureBox1.Image = bmp;
        //        }

        //        Automata.FieldCell[,] newboard = new Automata.FieldCell[oldWidthX, oldWidthY];
        //        Automata.FieldCell[,] newoldboard = new Automata.FieldCell[oldWidthX, oldWidthY];

        //        if (WidthX <= oldWidthX)
        //            for (int x = 0; x < WidthX; x++) {
        //                if (WidthY <= oldWidthY)
        //                    for (int y = 0; y < WidthY; y++) {
        //                        newboard[x, y] = board[x, y];
        //                        newoldboard[x, y] = oldboard[x, y];
        //                    }
        //                else
        //                    for (int y = 0; y < oldWidthY; y++) {
        //                        newboard[x, y] = board[x, y];
        //                        newoldboard[x, y] = oldboard[x, y];
        //                    }

        //            }
        //        else
        //            for (int x = 0; x < oldWidthX; x++) {
        //                if (WidthY <= oldWidthY)
        //                    for (int y = 0; y < WidthY; y++) {
        //                        newboard[x, y] = board[x, y];
        //                        newoldboard[x, y] = oldboard[x, y];
        //                    }
        //                else
        //                    for (int y = 0; y < oldWidthY; y++) {
        //                        newboard[x, y] = board[x, y];
        //                        newoldboard[x, y] = oldboard[x, y];
        //                    }

        //            }

        //        board = newboard;
        //        oldboard = newoldboard;

        //        newboard = null;
        //        newoldboard = null;


        //        WidthX = oldWidthX;
        //        WidthY = oldWidthY;

        //        drawBoard();

        //        if (T1wasRunning) {
        //            timer1.Start();
        //            timer2.Start();
        //            T1wasRunning = false;
        //        }


        //        this.WindowState = FormWindowState.Maximized;
        //        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        //    }
        //}


        //private void Form1_KeyDown(object sender, KeyEventArgs e) {

        //    if (e.Alt && e.KeyCode == Keys.Enter) {
        //        // ...
        //        showFullScreen = !showFullScreen;

        //        if (showFullScreen)
        //            GoFullscreen(true);
        //        else
        //            GoFullscreen(false);
        //    }
        //    if (e.Alt && e.KeyCode == Keys.F) {
        //        if (showFullScreen) {
        //            if (!(hideControls))
        //                pictureBox1.BringToFront();
        //            else
        //                pictureBox1.SendToBack();
        //            hideControls = !hideControls;
        //        }
        //    }
        //    if (e.Alt && e.KeyCode == Keys.R) {
        //        bool isTimer1Enabled = false;
        //        if (timer1.Enabled)
        //            isTimer1Enabled = true;

        //        if (isTimer1Enabled)
        //            timer1.Stop();
        //        drawBoard();
        //        if (isTimer1Enabled)
        //            timer1.Start();
        //    }
        //}

        private void buttonClear_Click(object sender, EventArgs e) {
            stopTimer();
            MainGrid.Clear();
            drawBoard();
        }

        private void buttonRandomFillClick(object sender, EventArgs e) {
            stopTimer();
            createRandomBoard();
            if (!(timer1.Enabled))
                drawBoard();
        }

        private void trackBarTime_ValueChanged(object sender, EventArgs e) {
            timer1.Interval = trackBarTime.Value + 1;
            labelTime.Text = trackBarTime.Value + " ms";
        }

        private void genome_Changed(object sender, EventArgs e) {
            genomeSetting = new bool[9] { genomeCheckBox0.Checked, genomeCheckBox1.Checked, genomeCheckBox2.Checked, genomeCheckBox3.Checked, genomeCheckBox4.Checked, genomeCheckBox5.Checked, genomeCheckBox6.Checked, genomeCheckBox7.Checked, genomeCheckBox8.Checked };
        }

        public static void FillRectangle(Graphics g, Brush brush, int posX, int posY, int cellSize) {
            g.FillRectangle(brush, posX - (cellSize / 2), posY - (cellSize / 2), cellSize, cellSize);
        }

        private void buttonLoad_Click(object sender, EventArgs e) {
            stopTimer();
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            stopTimer();
        }
    }


    public class Grid {
        //public List<Cell> gridCells = new List<Cell>();
        public Cell[,] gridCells;


        

        private int gRows;
        private int gCols;

        //public Grid(int rows, int columns) {
        //    Rows = rows;
        //    Cols = columns;
        //    gridCells = new Cell[rows * columns];
        //}

        public Grid(int rows, int columns) {
            gridCells = new Cell[columns, rows];
            Rows = rows;
            Cols = columns;
            
        }

        public ref Cell this[int posX, int posY] {
            get
            {
                if (posX < gCols && posY < gRows) return ref gridCells[posX, posY];
                throw new IndexOutOfRangeException();
            }
        }

        //public ref Cell this[int posX, int posY] {
        //    get {
        //        if (posX < gCols && posY < gRows) return ref gridCells[(posY * gCols) + posX];
        //        throw new IndexOutOfRangeException();
        //    }
        //}

        //public int Length {
        //    get => gridCells.Length;
        //}

        //public Cell this[int posX, int posY] {
        //    get { return gridCells[(posY * gCols) + posX]; }
        //}

        public void Clear() {
            for (int i = 0; i < Cols; i++)
                for (int j = 0; j < Rows; j++)
                    gridCells[i,j] = new Cell();
        }

        private bool AliveCheck(int posX, int posY) {
            if ((posX < gCols && posY < gRows) && (posX >= 0 && posY >= 0)) return this[posX, posY].IsAlive;
            return false;
        }

        public int Neighbours(int posX, int posY) {
            int amount = 0;
            if (AliveCheck(posX, posY - 1)) amount++;
            if (AliveCheck(posX - 1, posY - 1)) amount++;
            if (AliveCheck(posX - 1, posY)) amount++;
            if (AliveCheck(posX - 1, posY + 1)) amount++;
            if (AliveCheck(posX, posY + 1)) amount++;
            if (AliveCheck(posX + 1, posY + 1)) amount++;
            if (AliveCheck(posX + 1, posY)) amount++;
            if (AliveCheck(posX + 1, posY - 1)) amount++;
            return amount;
        }

        //public bool IsAttractive(int i, int j) {
        //    if (this[i, j][Neighbours(i, j)]) return true;
        //    return false;
        //}

        public void NextGen() {


            for (int i = 0; i < Cols; i++) {
                for (int j = 0; j < Rows; j++) {
                    if (this[i, j].IsAlive) {
                        if (!this[i, j][Neighbours(i, j)]) {
                            this[i, j] = new Cell(false);
                        }
                        try {
                            //do {
                                if (this[i, j][Neighbours(i, j - 1)]) { this[i, j - 1] = this[i, j]; continue; }
                                if (this[i, j][Neighbours(i - 1, j - 1)]) { this[i - 1, j - 1] = this[i, j]; continue; }
                                if (this[i, j][Neighbours(i - 1, j)]) { this[i - 1, j] = this[i, j]; continue; }
                                if (this[i, j][Neighbours(i - 1, j + 1)]) { this[i - 1, j + 1] = this[i, j]; continue; } 
                                if (this[i, j][Neighbours(i, j + 1)]) { this[i, j + 1] = this[i, j]; continue; }
                                if (this[i, j][Neighbours(i + 1, j + 1)]) { this[i + 1, j + 1] = this[i, j]; continue; }
                                if (this[i, j][Neighbours(i + 1, j)]) { this[i + 1, j] = this[i, j]; continue; }
                                if (this[i, j][Neighbours(i + 1, j - 1)]) { this[i + 1, j - 1] = this[i, j]; continue; }
                            //} while (false);
                                
                        }
                        catch (Exception) {

                        }
                        
                            
                            
                    }



                }
            }


        }

        


        public int Rows {
            get { return gRows; }
            set { gRows = value; }
        }

        public int Cols {
            get { return gCols; }
            set { gCols = value; }
        }

        //public int LiveAdjacent(Cell cell) {
        //    // Function to return number of active neighboring cells.
        //    // Use cell index numbers to search range of cells for active neighbors.

        //    int liveAdjacent = 0;

        //    // Get range of cells to be examined for active neighbors.
        //    int cellIndex = (cell.YPos * Cols) + cell.XPos;
        //    int startIndex = cellIndex - Cols - 2;
        //    int endIndex = cellIndex + Cols + 2;

        //    // Ensure that the start and end indexes don't exceed the grid range.
        //    startIndex = (startIndex < 0) ? 0 : startIndex;
        //    endIndex = (endIndex > (Grid.gridCells.Count - 1)) ? Grid.gridCells.Count - 1 : endIndex;

        //    // Iterate through the defined range and look for active neighbors.
        //    for (int x = startIndex; x < endIndex; x++) {
        //        if (Math.Abs(cell.XPos - gridCells[x].XPos) < 2 && Math.Abs(cell.YPos - gridCells[x].YPos) < 2) {
        //            if (Grid.gridCells[x].Location != cell.Location) {
        //                if (gridCells[x].IsAlive) {
        //                    liveAdjacent++;
        //                }
        //            }
        //        }
        //    }

        //    return liveAdjacent;
        //}

        //public int LiveAdjacent(int i, int j) {
        //    // Function to return number of active neighboring cells.
        //    // Use cell index numbers to search range of cells for active neighbors.

        //    int liveAdjacent = 0;

        //    // Get range of cells to be examined for active neighbors.
        //    int cellIndex = (cell.YPos * Cols) + cell.XPos;
        //    int startIndex = cellIndex - Cols - 2;
        //    int endIndex = cellIndex + Cols + 2;

        //    // Ensure that the start and end indexes don't exceed the grid range.
        //    startIndex = (startIndex < 0) ? 0 : startIndex;
        //    endIndex = (endIndex > (Grid.gridCells.Count - 1)) ? Grid.gridCells.Count - 1 : endIndex;

        //    // Iterate through the defined range and look for active neighbors.
        //    for (int x = startIndex; x < endIndex; x++) {
        //        if (Math.Abs(cell.XPos - gridCells[x].XPos) < 2 && Math.Abs(cell.YPos - gridCells[x].YPos) < 2) {
        //            if (Grid.gridCells[x].Location != cell.Location) {
        //                if (gridCells[x].IsAlive) {
        //                    liveAdjacent++;
        //                }
        //            }
        //        }
        //    }

        //    return liveAdjacent;
        //}

        public void filler() { }

        //public void LoadGrid(string filePath, Size displaySize) {
        //    string lineText;
        //    string startText = "", gridString = "";
        //    int cellSize = 10, rows, cols, maxSize, cellCount;
        //    Cell newCell;

        //    try {
        //        // Clear the list of cells.
        //        gridCells.Clear();

        //        // Read file.
        //        using (StreamReader loadFile = new StreamReader(filePath)) {
        //            while (!loadFile.EndOfStream) {
        //                // Get line from file.
        //                lineText = loadFile.ReadLine();

        //                if (lineText != null) {
        //                    // Get the first character.
        //                    startText = lineText.Substring(0, 1);

        //                    if (lineText.Substring(0, 4) == "Cell") {
        //                        // If the line starts with "Cell", it's the cell size.
        //                        int.TryParse(lineText.Substring(lineText.IndexOf(":") + 1), out int result);
        //                        cellSize = result;
        //                    }
        //                    else if (startText == "0" || startText == "1") {
        //                        // If the line starts with 0 or 1, treat it as part of the grid.
        //                        gridString += lineText;
        //                    }
        //                }
        //            }
        //        }

        //        // Determine maximum cell size supported by number of cells and the display size.
        //        // If it's smaller than the current spec, update the assumed cell size.
        //        maxSize = (int)Math.Sqrt((displaySize.Width * displaySize.Height) / gridString.Length);
        //        maxSize = maxSize > 25 ? 25 : maxSize;
        //        cellSize = (maxSize < cellSize) ? maxSize : cellSize;

        //        // Determine the number of rows and columns in the grid.
        //        rows = displaySize.Height / cellSize;
        //        cols = displaySize.Width / cellSize;

        //        Rows = rows;
        //        Cols = cols;

        //        // Create the cells in the List<Cell> collection. 
        //        cellCount = 0;
        //        for (int y = 0; y < rows; y++) {
        //            for (int x = 0; x < cols; x++) {
        //                // Create new cell and turn it on or off as specified.
        //                // If the number of cells needed exceeds the number of cells specified
        //                // in the file, set all the ones after to IsAlive = False.
        //                newCell = new Cell(x, y, cellSize);

        //                if (cellCount < gridString.Length)
        //                    newCell.IsAlive = (gridString[cellCount]) == '1' ? true : false;
        //                else
        //                    newCell.IsAlive = false;

        //                cellCount++;
        //            }
        //        }

        //        // Sort the grid at the end.  
        //        Grid.gridCells = Grid.gridCells.OrderBy(c => c.XPos).OrderBy(c => c.YPos).ToList();
        //    }
        //    catch (Exception) {
        //        throw;
        //    }


        //}

        //public void SaveGrid(string filePath) {
        //    string rowString = "";
        //    int cellIndex = 0;

        //    try {
        //        using (StreamWriter saveFile = new StreamWriter(filePath)) {
        //            saveFile.WriteLine($"Cell size: {gridCells[0].CellSize.Width.ToString()} ");
        //            saveFile.WriteLine("-- BEGIN GRID --");
        //            // Save the current grid to a text file.
        //            for (int y = 0; y < Rows; y++) {
        //                for (int x = 0; x < Cols; x++) {
        //                    rowString += gridCells[cellIndex].IsAlive ? "1" : "0";
        //                    cellIndex++;
        //                }
        //                saveFile.WriteLine(rowString);
        //                rowString = "";
        //            }
        //            saveFile.WriteLine("-- END GRID --");
        //            saveFile.Flush();
        //            saveFile.Close();

        //        }
        //    }
        //    catch (Exception) {
        //        throw;
        //    }

        //}

    }


    public class Cell {
        private bool[] cGenome;
        private Boolean cIsAlive;
        private Color cShade;

        public Cell() {
            cGenome = new bool[9] { false, false, false, false, false, false, false, false, false };
            cIsAlive = false;
            cShade = Color.White;
        }

        public Cell(bool isAlive) {
            cGenome = new bool[9] { false, false, false, false, false, false, false, false, false };
            cIsAlive = isAlive;
            cShade = Color.White;
        }

        public Cell(bool[] genome) {
            cGenome = genome;
            cIsAlive = true;
            this.SetColor();
        }

        public Cell(Cell parent) {
            cGenome = parent.cGenome;
            cIsAlive = parent.cIsAlive;
            cShade = parent.cShade;
        }

        public void SetColor() {
            List<Color> clrArr = new List<Color>();

            if (cGenome[0]) clrArr.Add(Color.Blue);
            if (cGenome[1]) clrArr.Add(Color.Aquamarine);
            if (cGenome[2]) clrArr.Add(Color.Green);
            if (cGenome[3]) clrArr.Add(Color.LightGreen);
            if (cGenome[4]) clrArr.Add(Color.GreenYellow);
            if (cGenome[5]) clrArr.Add(Color.Yellow);
            if (cGenome[6]) clrArr.Add(Color.Orange);
            if (cGenome[7]) clrArr.Add(Color.OrangeRed);
            if (cGenome[8]) clrArr.Add(Color.Orchid);

            if (clrArr.Count < 1) {
                cShade = Color.White;
                return;
            }

            int r = 0;
            int g = 0;
            int b = 0;
            foreach (Color color in clrArr) {
                r += color.R;
                g += color.G;
                b += color.B;
            }
            r = r / clrArr.Count;
            g = g / clrArr.Count;
            b = b / clrArr.Count;
            cShade = Color.FromArgb(r, g, b);

        }


        //public Cell(int CellSize) {
        //    Grid.gridCells.Add(this);
        //    this.CellSize = new Size(CellSize, CellSize);
        //}
        //public Cell(Point location, int X, int Y) {
        //    int cellSize;
        //    // Set object settings and add to grid.
        //    Location = location;
        //    YPos = Y;
        //    XPos = X;
        //    Grid.gridCells.Add(this);
        //    // If location is not 0, divide pixel location by grid location to get the size of the cell.
        //    cellSize = (X == 0) ? 0 : location.X / X;
        //}

        //public Cell(int X, int Y, int CellSize) {
        //    Location = new Point(X * CellSize, Y * CellSize);
        //    XPos = X;
        //    YPos = Y;
        //    this.CellSize = new Size(CellSize, CellSize);
        //    Grid.gridCells.Add(this);
        //}

        public bool this[int i] {
            get => cGenome[i];
            set => cGenome[i] = value;
        }

        public Boolean IsAlive {
            // Indicates if cell has been activated.
            get { return cIsAlive; }
            set { cIsAlive = value; }
        }

        public Color Color { get => cShade; }

    }
}