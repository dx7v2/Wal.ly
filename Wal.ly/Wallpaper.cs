using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Wal.ly
{
    public partial class Wallpaper : Form
    {
        public Wallpaper()
        {
            InitializeComponent();
            elementHost1.Dock = DockStyle.Fill;
            elementHost1.Child = media;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            media.Width = this.Width;
            media.Height = this.Height;
        }
    }
}
