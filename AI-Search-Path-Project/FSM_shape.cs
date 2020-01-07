using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AI_Search_Path_Project.Properties;
using System.Windows.Forms;

namespace AI_Search_Path_Project
{
    class FSM_shape
    {
        private Pen myPen;
        private static Font font;
        private static StringFormat sf;

        protected Pen MyPen
        {
            get
            {
                return myPen;
            }

            set
            {
                myPen = value;
            }
        }

        public static Font Font
        {
            get
            {
                return font;
            }

            set
            {
                font = value;
            }
        }

        public static StringFormat Sf
        {
            get
            {
                return sf;
            }

            set
            {
                sf = value;
            }
        }

        public FSM_shape()
        {
            myPen = new Pen(Color.Black);
            
            if (font == null)
            {
                Font = new Font("Arial", 12);
            }

            if (sf == null)
            {
                sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
            }
        }

        public virtual void Translate(int vx, int vy)
        {
            Console.Out.WriteLine("Translate: vx = %d, vy = %d", vx, vy);
        }

        public virtual void Draw(Graphics graph)
        {
            Console.Out.WriteLine("Draw nothing.");
        }

        public virtual bool ContainPoint(Point m)
        {
            Console.Out.WriteLine("Check if contain: %d - %d", m.X, m.Y);
            return false;
        }
    }
}
