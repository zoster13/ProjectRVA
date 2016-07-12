using CIM.IEC61970.Base.Core;
using ProjectRVA.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRVA.CommandPattern
{
    class DeleteNodeCommand : Command
    {
        private List<ConnectivityNode> deletedNodes;
        private Substation deletedFromSub;
        private string mRID;

        public DeleteNodeCommand(string mrid)
        {
            deletedNodes = new List<ConnectivityNode>();
            deletedFromSub = new Substation();
            this.mRID = mrid;
        }


        public override void Execute()
        {
            ConnectivityNode zaBrisanje = null;
            Substation substation = null;

            foreach (var node in DataBase.Nodes)
            {
                if (node.mRID == mRID)
                    zaBrisanje = node;
            }
            
            //Obrisi iz Substation-a
            foreach(Substation sub in DataBase.Substations)
            {
                foreach(ConnectivityNode node in sub.ConnectivityNodes)
                {
                    if(node.mRID == zaBrisanje.mRID)
                    {
                        substation = sub;
                        break;
                    }
                }
            }
            if (substation != null)
            {
                deletedFromSub = substation;
                substation.ConnectivityNodes.Remove(zaBrisanje);
            }
            deletedNodes.Add(zaBrisanje);
            DataBase.Nodes.Remove(zaBrisanje);

            serializeUtil.SerializeNodes(DataBase.Nodes);
            serializeUtil.SerializeSubstations(DataBase.Substations);
        }

        public override void UnExecute()
        {
            //Vratim izbrisani cvor u njegov Substation i u listu ConnectivityNodes
            DataBase.Nodes.Add(deletedNodes[deletedNodes.Count - 1]);

            foreach(Substation sub in DataBase.Substations)
            {
                if(sub.mRID == deletedFromSub.mRID)
                {
                    sub.ConnectivityNodes.Add(deletedNodes[deletedNodes.Count - 1]);
                }
            }

            //Reset
            deletedNodes.Remove(deletedNodes[deletedNodes.Count - 1]);
            deletedFromSub = null;

            serializeUtil.SerializeNodes(DataBase.Nodes);
            serializeUtil.SerializeSubstations(DataBase.Substations);
        }
    }
}
