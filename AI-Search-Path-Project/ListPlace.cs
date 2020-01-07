using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Search_Path_Project
{
    class ListPlace
    {
        private List<Place> place;
        private GMapControl gMap;
        public ListPlace()
        {    
            place = new List<Place>();
        }

        public void Add(Place p)
        {
            place.Add(p);
        }

        public List<string> GetListOfPlaceName()
        {
            List<string> list = new List<string>();
            foreach (var item in place)
            {
                list.Add(item.Name.Text);
            }
            return list;
        }
        public void Reset()
        {
            foreach(var item in place)
            {
                item.Reset();
            }
            gMap.Refresh();
        }
        public List< List<string> > GetPlaceData()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in place)
            {
                var subList = new List<string>();
                subList.Add(item.Name.Text);
                subList.Add(item.H.Text);
                list.Add(subList);
            }
            return list;
        }

        public void AddMap(GMapControl gMapMain)
        {
            gMap = gMapMain;
        }
    }
}
