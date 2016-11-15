using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ScoreSender.Entity
{
    public class CachPoint
    {
        public CachPoint()
        {
            email = "";
            address = "";
        }

        public CachPoint(string address, string email)
        {
            this.address = address;
            this.email = email;
        }

        public string Address 
        { 
            get { return address; }
            set { SetAddress(value); }
        }
        
        public string Email 
        { 
            get { return email; }
            set { SetEmail(value); }
        }

        private void SetAddress(string value)
        {
            address = value;
        }

        private void SetEmail(string value)
        {
            email = value;
        }

        public void Save(StreamWriter writer)
        {
            writer.WriteLine(address + "=" + email);
        }

        public void Read(string str)
        {
            string[] parts = str.Split('=');
            if (parts.Length != 2)
            {
                return;
            }
            address = parts[0].Trim();
            email = parts[1].Trim();
        }

        private string email;
        private string address;
    }
}
