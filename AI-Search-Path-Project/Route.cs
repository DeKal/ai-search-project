using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Drawing;
using GMap.NET.WindowsForms.Markers;
using AI_Search_Path_Project.Properties;

namespace AI_Search_Path_Project
{
    class Route
    {
        
        private TextBox from;
        private TextBox to;
        private TextBox weight;
        private TableLayoutPanel tableRoute;
        private System.EventHandler addNewRouteRow;
        private static List<MPoint> pLocation;
        private static GMapOverlay pOverlay;
        private static GMapOverlay mOverlay;

        private GMarkerGoogle wMarker;
        private GMapPolygon polygon = null;
        private static GMapControl gMap;

        private TextBox CreateNewTextBox()
        {
            TextBox tb = new TextBox();
            tb.Dock = System.Windows.Forms.DockStyle.Fill;
            tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            return tb;
        }

        
        public Route(TableLayoutPanel tableRoute, System.EventHandler addNewRouteRow) 
        {
            this.addNewRouteRow = addNewRouteRow;
            this.tableRoute = tableRoute;

            from = CreateNewTextBox();
            from.LostFocus += drawRoute;
            to = CreateNewTextBox();
            to.LostFocus += drawRoute;
            weight = CreateNewTextBox();
            weight.TextChanged += addNewRouteRow;
            weight.LostFocus += changeWeight;

            int row = tableRoute.RowCount++;
            tableRoute.Controls.Add(from, 0 /* Column Index */, row /* Row index */);
            tableRoute.Controls.Add(to, 1 /* Column Index */, row /* Row index */);
            tableRoute.Controls.Add(weight, 2 /* Column Index */, row /* Row index */);
        }

        private void changeWeight(object sender, EventArgs e)
        {
            if (wMarker != null)
                wMarker.ToolTipText = weight.Text;
            gMap.Refresh();
        }

        private void drawRoute(object sender, EventArgs e)
        {
            if (from.Text == "" || to.Text == "")
                return;
             
            int iFrom = Place.GetPlace(from.Text) - 1;

            if (iFrom < 0)
            {
                return;
            }
            int iTo = Place.GetPlace(to.Text) - 1;

            if (iTo < 0)
            {
                return;
            }
            List<PointLatLng> points = new List<PointLatLng>();
            
            points.Add(pLocation[iFrom].ToPointLatLng());
            points.Add(pLocation[iTo].ToPointLatLng());

            //if the line  exist, erase it
            if (polygon != null) 
                pOverlay.Polygons.Remove(polygon);
            //draw a line
            polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 2);
            pOverlay.Polygons.Add(polygon);


            //if the marker  exist, erase it
            if (wMarker != null)
                mOverlay.Markers.Remove(wMarker);

            //draw the weight
            var bmp = new Bitmap(Resources.w);
            wMarker = new GMarkerGoogle(pLocation[iFrom].Center(pLocation[iTo]), bmp);
            wMarker.ToolTip = new GMapToolTip(wMarker);
            wMarker.ToolTipText = weight.Text;
            wMarker.ToolTipMode = MarkerTooltipMode.Always;
            mOverlay.Markers.Add(wMarker);
        
        }

        public void RemoveEvent()
        {
            weight.TextChanged -= addNewRouteRow;
        }

        public TextBox From
        {
            get
            {
                return from;
            }

            set
            {
                from = value;
            }
        }

        public TextBox To
        {
            get
            {
                return to;
            }

            set
            {
                to = value;
            }
        }

        public TextBox Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }       

        internal static void AddMap(List<MPoint> location, GMapOverlay polyOverlay, GMapOverlay markersOverlay, GMapControl gMapMain)
        {
            pLocation = location;
            pOverlay = polyOverlay;
            mOverlay = markersOverlay;
            gMap = gMapMain;
        }

        public void RemoveRoute()
        {

            //if the line  exist, erase it
            if (polygon != null)
                pOverlay.Polygons.Remove(polygon);

            //if the marker  exist, erase it
            if (wMarker != null)
                mOverlay.Markers.Remove(wMarker);
            gMap.Refresh();
        }

        public List<String> GetInfo()
        {
            List<String> list = new List<String>();
            list.Add(from.Text);
            list.Add(to.Text);
            list.Add(Weight.Text);
            return list;
        }

       
    }
}
