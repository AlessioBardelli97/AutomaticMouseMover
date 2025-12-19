using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AutomaticMouseMover
{
  public partial class AutomaticMaouseMoverForm : Form
  {
    private bool mouseMove;
    private readonly Random Random;
    private Thread AnimationThread;
    private string ScreenDeviceName;

    private static readonly int AnimationDurationMilliseconds = 1200;
    private static readonly int AnimationSleepMilliseconds = 10;
    private static readonly int AnimationDelayMilliseconds = 300;

    public AutomaticMaouseMoverForm()
    {
      InitializeComponent();
      Random = new Random((int) GetTicksInMilliseconds());
      mouseMove = false;
      AnimationThread = null;
      ScreenDeviceName = null;

      Load += (s, e) => BuildScreenList();

      SystemEvents.DisplaySettingsChanged += (s, e) => {
#if DEBUG
        Console.WriteLine("User has changed the screens settings");
#endif
        StopMouseMoveBtnClick(s, e);
        ScreenBox.Controls.Clear();
        BuildScreenList();
        if (ScreenBox.Controls.Count == 1)
        {
          StartMouseMoveBtnClick(s, e);
          StopMouseMoveBtn.Focus();
        }
      };
    }

    private void BuildScreenList()
    {
      ushort i = 0;
      foreach (var screen in Screen.AllScreens.Reverse())
      {
        var radioBtn = new RadioButton
        {
          Text = $"Schermo ({screen.Bounds.Width} x {screen.Bounds.Height})",
          Name = screen.DeviceName,
          Location = new Point(10, (i + 1) * 25),
          AutoSize = true,
        };

        radioBtn.CheckedChanged += (s, e) => {
          if (radioBtn.Checked)
            ScreenDeviceName = radioBtn.Name;
#if DEBUG
          if (radioBtn.Checked)
            Console.WriteLine("Screen selection has changed. New screen selection: {0}", radioBtn.Name);
#endif
        };

        if (screen.Bounds.Contains(Bounds))
        {
          radioBtn.Checked = true;
          ScreenDeviceName = screen.DeviceName;
        }

        ScreenBox.Controls.Add(radioBtn);
        ++i;
      }
    }

    private void StartMouseMoveBtnClick(object sender, EventArgs e)
    {
      if (!SelectedScreenBounds.HasValue)
      {
        MessageBox.Show("Nessuno schermo selezionato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      mouseMove = true;
      StopMouseMoveBtn.Enabled = true;
      StartMouseMoveBtn.Enabled = false;
      AnimationThread = new Thread(new ThreadStart(() =>
      {
        while (mouseMove)
        {
          var OldX = Cursor.Position.X;
          var OldY = Cursor.Position.Y;

          int minX = SelectedScreenBounds?.X ?? 0;
          int maxX = minX + SelectedScreenBounds?.Width ?? 0;

          int minY = SelectedScreenBounds?.Y ?? 0;
          int maxY = minY + SelectedScreenBounds?.Height ?? 0;

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

    private Rectangle? SelectedScreenBounds
    {
      get
      {
        if (ScreenDeviceName != null)
          return Screen.AllScreens.First(screen => screen.DeviceName == ScreenDeviceName).Bounds;
        else return null;
      }
    }
  }
}
