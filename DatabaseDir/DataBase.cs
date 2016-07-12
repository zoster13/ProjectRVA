using CIM.IEC61970.Base.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRVA.Database
{
    public class DataBase
    {
        private static DataBase instance;
        private static BindingList<Substation> substations = new BindingList<Substation>();
        private static BindingList<ConnectivityNode> nodes = new BindingList<ConnectivityNode>();

        public static BindingList<Substation> Substations
        {
            get { return substations; }
            set { substations = value; }
        }

        public static BindingList<ConnectivityNode> Nodes
        {
            get { return nodes; }
            set { nodes = value; }
        }

        public static DataBase Instance()
        {
            if (instance == null)
                instance = new DataBase();

            return instance;
        }
        
    }
}
