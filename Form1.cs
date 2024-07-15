using System;
using System.Drawing;
using System.Linq;
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

      ushort i = 0;
      foreach (var screen in Screen.AllScreens)
      {
        var radioBtn = new RadioButton
        {
          Text = $"Schermo {i+1}",
          Name = $"Screen{screen.GetHashCode()}",
          Location = new Point(10, (i+1) * 25),
          AutoSize = true,
        };

#if DEBUG
        radioBtn.CheckedChanged += RadioBtnCheckedChanged;
#endif

        if (screen.Equals(Screen.PrimaryScreen))
          radioBtn.Checked = true;

        ScreenBox.Controls.Add(radioBtn);
        ++i;
      }
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

          int minX = SelectedScreen.Bounds.X;
          int maxX = minX + SelectedScreen.Bounds.Width;

          int minY = SelectedScreen.Bounds.Y;
          int maxY = minY + SelectedScreen.Bounds.Height;

          var TotalDx = Random.Next(minX, maxX) - OldX;
          var TotalDy = Random.Next(minY, maxY) - OldY;

          var startAnimation = GetTicksInMilliseconds();

          while (mouseMove && (GetTicksInMilliseconds() - startAnimation < AnimationDurationMilliseconds))
          {
            Thread.Sleep(AnimationSleepMilliseconds);

            if (!mouseMove)
              break;

            var animationPercentage = (GetTicksInMilliseconds() - startAnimation) / AnimationDurationMilliseconds;

            int dx = (int)(TotalDx * animationPercentage);
            int dy = (int)(TotalDy * animationPercentage);

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

#if DEBUG
    private void RadioBtnCheckedChanged(object sender, EventArgs e)
    {
      if (((RadioButton)sender).Checked)
        Console.WriteLine("Screen selection has changed. New screen selection: {0}", ((RadioButton)sender).Name);
    }
#endif

    private Screen SelectedScreen
    {
      get
      {
        var radioBtn = ScreenBox.Controls.OfType<RadioButton>().First(rbtn => rbtn.Checked);
        var screenHashCode = int.Parse(radioBtn.Name.Substring(6));
        return Screen.AllScreens.First(screen => screen.GetHashCode() == screenHashCode);
      }
    }
  }
}
