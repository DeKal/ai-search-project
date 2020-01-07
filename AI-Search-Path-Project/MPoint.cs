using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Search_Path_Project
{
    class MPoint
    {
        private double x;
        private double y;
        public MPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
        public PointLatLng ToPointLatLng()
        {
            return new PointLatLng(x,y);
        }

        internal PointLatLng Center(MPoint mPoint)
        {
            MPoint center = new MPoint(Math.Abs(x + mPoint.X) / 2, Math.Abs(y + mPoint.Y) / 2);
            return center.ToPointLatLng();
        }
    }
}
