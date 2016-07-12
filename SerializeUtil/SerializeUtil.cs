using CIM.IEC61970.Base.Core;
using ProjectRVA.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectRVA.SerializeUtil
{
    public class SerializeUtil
    {
        private static SerializeUtil instance;

        public static SerializeUtil Instance()
        {
            if (instance == null)
                instance = new SerializeUtil();

            return instance;
        }

        //Deserijalizacija korisnika
        public List<User> DeserializeUsers()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<User>));
            if (File.Exists("users.xml"))
            {
                using (TextReader reader = new StreamReader("users.xml"))
                {
                    List<User> users = (List<User>)deserializer.Deserialize(reader);
                    return users;
                }
            }
            return null;
        }


        //Serijalizacija trafostanica
        public void SerializeSubstations(BindingList<Substation> substations)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Substation>));
            using (TextWriter textWriter = new StreamWriter("substations.xml"))
            {
                serializer.Serialize(textWriter, substations);
            }
        }

        //Deserijalizacija trafostanica
        public BindingList<Substation> DeserializeSubstations()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(BindingList<Substation>));
            if (File.Exists("substations.xml"))
            {
                using (TextReader reader = new StreamReader("substations.xml"))
                {
                    BindingList<Substation> substations = (BindingList<Substation>)deserializer.Deserialize(reader);
                    return substations;
                }
            }
            return null;
        }
        

        //Deserijalizacija cvorova
        public BindingList<ConnectivityNode> DeserializeNodes()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(BindingList<ConnectivityNode>));
            if (File.Exists("nodes.xml"))
            {
                using (TextReader reader = new StreamReader("nodes.xml"))
                {
                    BindingList<ConnectivityNode> nodes = (BindingList<ConnectivityNode>)deserializer.Deserialize(reader);
                    return nodes;
                }
            }
            return null;
        }

        //Serijalizacija cvorova
        public void SerializeNodes(BindingList<ConnectivityNode> nodes)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<ConnectivityNode>));
            using (TextWriter textWriter = new StreamWriter("nodes.xml"))
            {
                serializer.Serialize(textWriter, nodes);
            }
        }

    }
}
