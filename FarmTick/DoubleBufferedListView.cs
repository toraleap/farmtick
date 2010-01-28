using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FarmTick
{
    public class DoubleBufferedListView : ListView 
    {
        public DoubleBufferedListView()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
    }      
}
