using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace LifeScreenSaver
{
  public partial class FormApp : Form
  {
    enum State
    {
      Alive = 0,
      Dying,
      Dying2,
      Dead
    }

    #region Variables
    // Starting square size to reduce from
    private readonly int maxSqSize = 16;
    
    // Life board parameters
    int xMax = 0;
    int yMax = 0;
    int sqSize;
    int gridSize = 8;
    int generation = 0;
    State[,] lifeBoard1;
    State[,] lifeBoard2;
    bool isBoard2Current;

    // Handles mouse movement events
    int mouseX = -1;
    int mouseY = -1;

    // Brush colors
    Brush microbeBrush;
    Brush dyingColorBrush;
    Brush dying2ColorBrush;

    // For reduction of size
    int genPerSq = 0;
    int nextGenRedux = 0;
    int hitCount = 0;
    #endregion

    #region Win32 Dlls
    [DllImport("user32.dll")]
    static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    [DllImport("user32.dll")]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
    [DllImport("user32.dll", SetLastError = true)]
    static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    [DllImport("user32.dll")]
    static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);
    #endregion

    #region Constructors
    /// <summary>
    /// Constructor
    /// </summary>
    public FormApp()
    {
      InitializeComponent();
      timer1.Interval = 40;
      GetScreenSize();
      isBoard2Current = false;
      Location = new Point(0, 0);
    }  // End Constructor

    /// <summary>
    /// Constructor for preview
    /// </summary>
    public FormApp(IntPtr wHandle)
    {
      InitializeComponent();

      SetParent(this.Handle, wHandle);
      SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));
      Rectangle ParentRect;
      GetClientRect(wHandle, out ParentRect);
      Size = ParentRect.Size;
      Location = new Point(0, 0);

      timer1.Interval = 40;
      isBoard2Current = false;

      sqSize = 1;
      gridSize = 2;
      xMax = (int)Math.Round(((double)Size.Width / (double)gridSize) + 1);
      yMax = (int)Math.Round(((double)Size.Height / (double)gridSize) + 1);
    }  // End Constructor
    #endregion

    #region Initialization
    /// <summary>
    /// Gets the maximum screen size from the current monitor set up and
    /// sets the xMax and yMax using the screen size / grid size
    /// </summary>
    private void GetScreenSize()
    {
      Screen[] screens = Screen.AllScreens;
      foreach (Screen screen in screens)
      {
        Rectangle rect = screen.Bounds;
        if ((rect.X + rect.Width) > xMax)
          xMax = (rect.X + rect.Width);
        if ((rect.Y + rect.Height) > yMax)
          yMax = (rect.Y + rect.Height);
      }
      xMax = (int)Math.Round(((double)xMax / (double)gridSize) + 1);
      yMax = (int)Math.Round(((double)yMax / (double)gridSize) + 1);
    }  // End method GetScreenSize

    /// <summary>
    /// Initializes the seed, starts timer and draws the life board
    /// </summary>
    /// <param name="sender">This</param>
    /// <param name="e">Load Event</param>
    private void Form1_Load(object sender, EventArgs e)
    {
      Cursor.Hide();
      Utilities.LoadFile();
      
      microbeBrush = new SolidBrush(Utilities.MicrobeColor);
      dyingColorBrush = new SolidBrush(Color.FromArgb(120, Utilities.MicrobeColor));
      dying2ColorBrush = new SolidBrush(Color.FromArgb(60, Utilities.MicrobeColor));
      Reset();
      this.TopMost = true;
    }  // End method Form1_Load

    /// <summary>
    /// Resets the data for the next iteration of Life computation
    /// </summary>
    private void Reset()
    {
      generation = 0;
      lifeBoard1 = new State[xMax, yMax];
      lifeBoard2 = new State[xMax, yMax];
      this.isBoard2Current = false;
      seed();
      sqSize = maxSqSize;
      genPerSq = 5;// (Utilities.Generations / sqSize);
      nextGenRedux = genPerSq;
      hitCount = 0;
      timer1.Start();
    }  // End Method Reset

    /// <summary>
    /// Creates the seed values of the life board
    /// </summary>
    /// <param name="g">Graphics to draw to</param>
    private void seed()
    {
      Random rand = new Random();
      for (int x = 0; x < xMax; x++)
      {
        for (int y = 0; y < yMax; y++)
        {
          if (rand.Next(100) < Utilities.SeedPerc)
            lifeBoard1[x, y] = State.Alive;
          else
            lifeBoard1[x, y] = State.Dead;
        }  //End for
      }  //End for
    }  //End Method seed
    #endregion

    #region Timed events
    /// <summary>
    /// Calls Redraw and recalculates the living cells
    /// </summary>
    /// <param name="sender">Timer</param>
    /// <param name="e">Tick Event</param>
    private void timer1_Tick(object sender, EventArgs e)
    {
      drawLife();
    }  // End method timer1_Tick

    /// <summary>
    /// Updates then calls paint function of life board
    /// </summary>
    /// <param name="sender">this</param>
    /// <param name="e">Paint event</param>
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      if (generation > Utilities.Generations && Utilities.Generations != -1)
      {
        timer1.Stop();
        Reset();
      }

      if(generation > nextGenRedux)
      {
        hitCount++;
        nextGenRedux += (genPerSq * hitCount);
        if (sqSize > gridSize) sqSize--;
      }

      State[,] cBoard = isBoard2Current ? lifeBoard2 : lifeBoard1;
      for (int y = 0; y < yMax; y++)  //for x direction
      {
        for (int col = 0; col < xMax; col++)
        {
          if (cBoard[col, y] == State.Alive)
            e.Graphics.FillEllipse(microbeBrush, col * gridSize, y * gridSize, sqSize, sqSize);
          else if (cBoard[col, y] == State.Dying)
            e.Graphics.FillEllipse(dyingColorBrush, col * gridSize, y * gridSize, sqSize, sqSize);
          else if (cBoard[col, y] == State.Dying2)
            e.Graphics.FillEllipse(dying2ColorBrush, col * gridSize, y * gridSize, sqSize, sqSize);
        }
      }
      e.Dispose();
    }  //End Method Form1_Paint
    #endregion

    #region Life Board Parsing
    /// <summary>
    /// Recreates the life board based on the current board
    /// </summary>
    /// <param name="g">Graphics object to write to</param>
    private void drawLife()
    {
      generation++;
      State[,] cBoard = isBoard2Current ? lifeBoard2 : lifeBoard1;
      State[,] nBoard = isBoard2Current ? lifeBoard1 : lifeBoard2;
      isBoard2Current = !isBoard2Current;
      processMatrix(cBoard, nBoard);
      this.Invalidate(this.Region);
    }  // End method drawLife

    /// <summary>
    /// Gets the number of living cells around target cell
    /// </summary>
    /// <param name="x">x position of target cell</param>
    /// <param name="y">y position of target cell</param>
    /// <returns>Number of living cells around target cell</returns>
    private int getNumberofSurroundingPoints(int x, int y, State[,] cBoard)
    {
      int lastX = getLastXPos(x);
      int lasty = getLastYPos(y);
      int nextX = getNextXPos(x);
      int nextY = getNextYPos(y);
      return (cBoard[lastX, lasty] == State.Alive ? 1 : 0)
      + (cBoard[x, lasty] == State.Alive ? 1 : 0)
      + (cBoard[nextX, lasty] == State.Alive ? 1 : 0)
      + (cBoard[nextX, y] == State.Alive ? 1 : 0)
      + (cBoard[nextX, nextY] == State.Alive ? 1 : 0)
      + (cBoard[x, nextY] == State.Alive ? 1 : 0)
      + (cBoard[lastX, nextY] == State.Alive ? 1 : 0)
      + (cBoard[lastX, y] == State.Alive ? 1 : 0);
    }  // End method getNumberofSurroundingPoints

    /// <summary>
    /// Gets the x position to the left of the current position
    /// </summary>
    /// <param name="pos">target x position</param>
    /// <returns>x position to the left of the current position</returns>
    private int getLastXPos(int pos)
    {
      if (pos < 1)
        return xMax - 1;
      return pos - 1;
    }  // End method getLastXPos

    /// <summary>
    /// Gets the y position to the left of the current position
    /// </summary>
    /// <param name="pos">target y position</param>
    /// <returns>y position to the left of the current position</returns>
    private int getLastYPos(int pos)
    {
      if (pos < 1)
        return yMax - 1;
      return pos - 1;
    }  // End method getLastYPos

    /// <summary>
    /// Gets the x position to the right of the current position
    /// </summary>
    /// <param name="pos">target x position</param>
    /// <returns>x position to the right of the current position</returns>
    private int getNextXPos(int pos)
    {
      if (pos == (xMax - 1))
        return 0;
      return pos + 1;
    }  // End method getNextXPos

    /// <summary>
    /// Gets the y position to the right of the current position
    /// </summary>
    /// <param name="pos">target y position</param>
    /// <returns>y position to the right of the current position</returns>
    private int getNextYPos(int pos)
    {
      if (pos == (yMax - 1))
        return 0;
      return pos + 1;
    }  // End method getNextYPos

    /// <summary>
    /// Updates the target matrix
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <param name="ge"></param>
    private void processMatrix(State[,] source, State[,] target)
    {
      for (int y = 0; y < yMax; y++)  //for x direction
      {
        for (int col = 0; col < xMax; col++)
        {
          int survived = getNumberofSurroundingPoints(col, y, source);
          if (source[col, y] == State.Alive)  //if alive
          {
            if (survived == 2 || survived == 3) //check if 2 or 3 neighbors
              target[col, y] = State.Alive;
            else  //died
              target[col, y] = State.Dying;
          }
          else  //if not alive
          {
            if (survived == 3) //if 3 neighbors, spawn
              target[col, y] = State.Alive;
            else if (source[col, y] == State.Dying)
              target[col, y] = State.Dying2;
            else
              target[col, y] = State.Dead;  //stay not alive
          }
        }
      }
    }
    #endregion

    #region Input handlers
    /// <summary>
    /// Mouse movements exit application
    /// </summary>
    /// <param name="sender">Form</param>
    /// <param name="e">Not used</param>
    private void FormApp_MouseMove(object sender, MouseEventArgs e)
    {
      if (mouseX == -1)
      {
        mouseX = e.X;
        mouseY = e.Y;
      }
      else if (Math.Abs(mouseX - e.X) > 10 || Math.Abs(mouseY - e.Y) > 10)
        this.Close();
    }  // End method FormApp_MouseMove

    /// <summary>
    /// Keyboard presses exit application
    /// </summary>
    /// <param name="sender">Form</param>
    /// <param name="e">Not used</param>
    private void FormApp_KeyDown(object sender, KeyEventArgs e)
    {
      this.Close();
    }  // End method FormApp_KeyDown

    /// <summary>
    /// Handles the mouse click event.  Closes the dialog
    /// </summary>
    /// <param name="sender">Form Click Event</param>
    /// <param name="e">Click Event</param>
    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
      this.Close();
    }  // End method MouseClick
    #endregion
  }  // End class Form1
}  // End namespace WindowsApplication1