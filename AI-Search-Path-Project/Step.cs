using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms;

namespace AI_Search_Path_Project
{
    class Step
    {
        private string place;
        private string slot;
        private string content;
        private static Label think;
        private static Label open;
        private static Label close;
        private static Label result;

        private string prvThink;
        private string prvOpen;
        private string prvClose;
        private string prvResult;

        private dynamic obj;
        private static List<GMapMarker> listMarker;
        private static GMapControl map;

        public string _Place
        {
            get
            {
                return place;
            }

            set
            {
                place = value;
            }
        }

        public string Slot
        {
            get
            {
                return slot;
            }

            set
            {
                slot = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public Step(dynamic obj)
        {
            this.obj = obj;

            int index = 0;
            foreach(var item in obj)
            {
                if (index++ == 0)
                    place = item.ToString();
                else
                {
                    int sindex = 0;
                    foreach (var subitem in item)
                    {
                        if (sindex++ == 0)
                            slot = subitem.ToString();
                        else
                        {
                            content = subitem.ToString();
                        }
                    }
                }
            }
        }
        public string ToString
        {
            get
            {
                return place + " : " + slot + " -> " + content;
            }
        }
        public static void Reset()
        {
            think.Text = "";
            open.Text = "";
            close.Text = "";
            result.Text = "";
        }
        public void Display()
        {
            //preserve to undo the step
            prvClose = close.Text;
            prvOpen = open.Text;
            prvThink = think.Text;
            prvResult = result.Text;
            //update 
            if (place == "board")
            {
                switch (slot)
                {
                    case "frontier":
                        open.Text = content;
                        break;
                    case "think":
                        think.Text = content;
                        break;
                    case "explored":
                        close.Text = content;
                        break;
                    case "result":
                        result.Text = content;
                        break;
                }
            }
            else
            {
                int index = Place.GetPlace(slot) - 1;
                listMarker[index].ToolTipText = slot + " : " + content;
                map.Refresh();
            }
            
        }

        public static void AddDisplayControl(Label t, Label o, Label c, Label r)
        {
            think = t;
            open = o;
            close = c;
            result = r;
        }

        public static void AddMarkersArray(List<GMapMarker> markers)
        {
            listMarker = markers;
        }

        internal static void AddMap(GMapControl gMapMain)
        {
            map = gMapMain;
        }

        internal void Undo()
        {
            if (place != "board")
            {
                int index = Place.GetPlace(slot) - 1;
                listMarker[index].ToolTipText = slot;
                map.Refresh();
            }
            else
            {
                //RESTORE
                open.Text = prvOpen;    
                think.Text = prvThink;
                close.Text = prvClose;
                result.Text = prvResult;
            }
        }
    }
}
