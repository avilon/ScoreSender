using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ScoreSender.Entity
{
    public class CachPointList
    {
        public CachPointList()
        {
            items = new List<CachPoint>();
        }

        public int Count { get { return items.Count; } }
        public CachPoint this[int index]
        {
            get { return items[index]; }
        }

        public void Add(CachPoint cp)
        {
            items.Add(cp);
        }

        public void UpdateByAddress(string address, CachPoint cp)
        {
            foreach(CachPoint item in items)
            {
                if (item.Address == cp.Address)
                {
                    item.Address = cp.Address;
                    item.Email = cp.Email;
                }
            }
        }

        public void Load(string fname)
        {
            if (!File.Exists(fname))
            {
                return;
            }
            fileName = fname;
            
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine())!= null)
                {
                    CachPoint cp = new CachPoint();
                    cp.Read(line);
                    items.Add(cp);
                }
            }
        }

        public void Save(string fname = "")
        {
            if (!String.IsNullOrEmpty(fname))
            {
                fileName = fname;
            }
            if (String.IsNullOrEmpty(fileName))
            {
                fileName = @"items.cfg";
            }

            using(StreamWriter writer = new StreamWriter(fileName))
            {
                foreach(CachPoint cp in items)
                {
                    cp.Save(writer);
                }
            }
        }

        private List<CachPoint> items;
        private string fileName;
    }
}
