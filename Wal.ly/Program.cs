using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wal.ly
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IntPtr progman = W32.FindWindow("Progman", null);

            IntPtr result = IntPtr.Zero;

            W32.SendMessageTimeout(progman,
                                   0x052C,
                                   new IntPtr(0),
                                   IntPtr.Zero,
                                   W32.SendMessageTimeoutFlags.SMTO_NORMAL,
                                   1000,
                                   out result);

            IntPtr workerw = IntPtr.Zero;

            W32.EnumWindows(new W32.EnumWindowsProc((tophandle, topparamhandle) =>
            {
                IntPtr p = W32.FindWindowEx(tophandle,
                                            IntPtr.Zero,
                                            "SHELLDLL_DefView",
                                            IntPtr.Zero);

                if (p != IntPtr.Zero)
                {
                    workerw = W32.FindWindowEx(IntPtr.Zero,
                                               tophandle,
                                               "WorkerW",
                                               IntPtr.Zero);
                }

                return true;
            }), IntPtr.Zero);
            Wallpaper wall = new Wallpaper();
                wall.media.Source = new Uri(@"C:\Path\to\wallpaper.mp4");
                wall.media.Volume = 0.0;
                wall.media.Visibility = System.Windows.Visibility.Visible;
                wall.media.MediaEnded += delegate (object send, System.Windows.RoutedEventArgs args)
                {
                    wall.media.Position = TimeSpan.Zero;
                    wall.media.Play();
                };
                wall.media.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
                wall.media.Play();
                wall.media.Stretch = System.Windows.Media.Stretch.Fill;
                W32.SetParent(wall.Handle, workerw);
            Application.Run(wall);
        }
    }
}
