using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectRVA.Login
{
    [Serializable]
    public class User
    {
        [XmlElement]
        private string username;
        [XmlElement]
        private string password;
        
        public User() { }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
    }
}
