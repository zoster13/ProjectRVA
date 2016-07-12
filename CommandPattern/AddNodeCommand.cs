using CIM.IEC61970.Base.Core;
using ProjectRVA.Database;
using ProjectRVA.FacadePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRVA.CommandPattern
{
    public class AddNodeCommand : Command
    {
        private string name = "";
        private string voltageLevel = "";
        private string description = "";
        private string nameOfSubstation = "";

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string VoltageLevel
        {
            get { return this.voltageLevel; }
            set { this.voltageLevel = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public string NameOfSubstation
        {
            get { return this.nameOfSubstation; }
            set { this.nameOfSubstation = value; }
        }


        public AddNodeCommand(string name, string vl, string desc, string substation)
        {
            this.Name = name;
            this.VoltageLevel = vl;
            this.Description = desc;
            this.nameOfSubstation = substation;
        }

        public override void Execute()
        {
            CreateNodeFacade nodeFacade = new CreateNodeFacade(Name,VoltageLevel,Description,NameOfSubstation);
        }

        public override void UnExecute()
        {
            //Obrisi poslednji dodati
            ConnectivityNode zaBrisanje = Database.DataBase.Nodes[Database.DataBase.Nodes.Count - 1];
            Database.DataBase.Nodes.Remove(zaBrisanje);

            //Obrisi iz Substationa
            Substation tempSub = null;
            foreach (Substation sub in DataBase.Substations)
            {
                foreach(ConnectivityNode node in sub.ConnectivityNodes)
                {
                    if(node == zaBrisanje)
                    {
                        tempSub = sub;
                        break;
                    }
                }
            }

            if (tempSub != null)
                tempSub.ConnectivityNodes.Remove(zaBrisanje);

            //Serijalizacija
            serializeUtil.SerializeNodes(DataBase.Nodes);
            serializeUtil.SerializeSubstations(DataBase.Substations);
        }
    }
}
