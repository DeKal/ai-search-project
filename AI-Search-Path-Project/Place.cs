using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_Search_Path_Project
{
    class Place
    {
        private Label id;
        private TextBox name;
        private TextBox h;
        private GMarkerGoogle marker;
        private static GMapControl gMap;
        private static Dictionary<string, int> places = new Dictionary<string, int>();

        public GMarkerGoogle Marker
        {
            get
            {
                return marker;
            }

            set
            {
                marker = value;
            }
        }

        public TextBox Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Label Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public TextBox H
        {
            get
            {
                return h;
            }

            set
            {
                h = value;
            }
        }

        public Place(int id, PointLatLng point)
        {
            // new control
            this.id = CreateNewLabel(id.ToString());

            //set marker
            marker = new GMarkerGoogle(point, GMarkerGoogleType.arrow);
            

            //find address of marker
            string place_name;
            //List<Placemark> plc = null;
            //var st = GMapProviders.GoogleMap.GetPlacemarks(point, out plc);
            //if (st == GeoCoderStatusCode.G_GEO_SUCCESS && plc != null)
            //{
            //    place_name = plc[0].Address.ToString();
            //}
            //else
            place_name = id.ToString();

            h = CreateNewTextBox("");

            name = CreateNewTextBox(place_name);
            name.LostFocus += changeMarkerToolTip_TextChanged;

            marker.ToolTip = new GMapToolTip(marker);
            marker.ToolTipText = place_name;
            marker.ToolTipMode = MarkerTooltipMode.Always;
            places[place_name] = id;
        }
        //dynamically create new label
        private Label CreateNewLabel(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            return label;
        }

        public static int GetPlace(string text)
        {
            if (places.ContainsKey(text))
                return places[text];
            else
                return -1;
        }

        //dynamically create new textbox
        private TextBox CreateNewTextBox(string text)
        {
            TextBox tb = new TextBox();
            tb.Text = text;
            tb.Dock = System.Windows.Forms.DockStyle.Fill;
            tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tb.Margin = new System.Windows.Forms.Padding(5,0,5,10);
            return tb;
        }

        private void changeMarkerToolTip_TextChanged(object sender, EventArgs e)
        {
            marker.ToolTip.Dispose();
            marker.ToolTip = new GMapToolTip(marker);

            places.Remove(marker.ToolTipText);
            places[name.Text] = int.Parse(id.Text);
            marker.ToolTipText = name.Text;

            marker.ToolTipMode = MarkerTooltipMode.Always;
            gMap.Refresh();
            
            
        }

        public static void SetMap(GMapControl gMapMain)
        {
            gMap = gMapMain;
        }
        public void Reset()
        {
            marker.ToolTipText = name.Text;
        }
    }
}
