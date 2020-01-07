using System;
using System.Windows.Forms;

namespace AI_Search_Path_Project
{
    class custom_Canvas : Panel
    {
        public custom_Canvas()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
    }
}
