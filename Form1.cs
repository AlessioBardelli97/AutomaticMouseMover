using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace AutomaticMouseMover
{
  public partial class AutomaticMaouseMoverForm : Form
  {
    private bool mouseMove;
    private readonly Random Random;
    private Thread AnimationThread;

    private static readonly int AnimationDurationMilliseconds = 1200;
    private static readonly int AnimationSleepMilliseconds = 10;
    private static readonly int AnimationDelayMilliseconds = 300;

    public AutomaticMaouseMoverForm()
    {
      InitializeComponent();
      Random = new Random((int) GetTicksInMilliseconds());
      mouseMove = false;
      AnimationThread = null;
    }

    private void StartMouseMoveBtnClick(object sender, EventArgs e)
    {
      mouseMove = true;
      StopMouseMoveBtn.Enabled = true;
      StartMouseMoveBtn.Enabled = false;
      AnimationThread = new Thread(new ThreadStart(() =>
      {
        while (mouseMove)
        {
          var OldX = Cursor.Position.X;
          var OldY = Cursor.Position.Y;

          var TotalDx = Random.Next(0, Screen.PrimaryScreen.Bounds.Width) - OldX;
          var TotalDy = Random.Next(0, Screen.PrimaryScreen.Bounds.Height) - OldY;

          var startAnimation = GetTicksInMilliseconds();

          while (mouseMove && (GetTicksInMilliseconds() - startAnimation < AnimationDurationMilliseconds))
          {
            Thread.Sleep(AnimationSleepMilliseconds);

            if (!mouseMove)
              break;

            var currentTicks = GetTicksInMilliseconds();

            int dx = (int)(TotalDx * (currentTicks - startAnimation) / AnimationDurationMilliseconds);
            int dy = (int)(TotalDy * (currentTicks - startAnimation) / AnimationDurationMilliseconds);

            Cursor.Position = new Point(OldX + dx, OldY + dy);
          }

          Thread.Sleep(AnimationDelayMilliseconds);
        }

      }));
      AnimationThread.Start();
    }

    private void StopMouseMoveBtnClick(object sender, EventArgs e)
    {
      mouseMove = false;
      AnimationThread?.Join();
      StartMouseMoveBtn.Enabled = true;
      StopMouseMoveBtn.Enabled = false;
    }

    private void CloseBtnClick(object sender, EventArgs e)
    {
      mouseMove = false;
      AnimationThread?.Join();
      Application.Exit();
    }
    private static double GetTicksInMilliseconds()
    {
      return DateTime.Now.Ticks / 10_000.0;
    }
  }
}
