using CIM.IEC61970.Base.Core;
using ProjectRVA.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRVA.CommandPattern
{
    public class DeleteSubstationCommand : Command
    {
        SerializeUtil.SerializeUtil serializeUtil = SerializeUtil.SerializeUtil.Instance();
        private string mRID;
        private List<Substation> deletedSubs;

        public DeleteSubstationCommand(string mrid)
        {
            this.mRID = mrid;
            deletedSubs = new List<Substation>();
        }

        public override void Execute()
        {
            Substation zaBrisanje = null;

            foreach(var sub in DataBase.Substations)
            {
                if (sub.mRID == mRID)
                    zaBrisanje = sub;
            }

            deletedSubs.Add(zaBrisanje);

            //Obrisi cvorove iz baze
            foreach (ConnectivityNode node in zaBrisanje.ConnectivityNodes)
            {
                for(int i=0; i<DataBase.Nodes.Count; i++)
                {
                    if(node.mRID.Equals(DataBase.Nodes[i].mRID))
                    {
                        DataBase.Nodes.Remove(DataBase.Nodes[i]);
                    }
                }
            }
            
            //Obrisi Substation iz baze
            DataBase.Substations.Remove(zaBrisanje);
            
            serializeUtil.SerializeSubstations(DataBase.Substations);
            serializeUtil.SerializeNodes(DataBase.Nodes);
        }

        public override void UnExecute()
        {
            Substation deleted = deletedSubs[deletedSubs.Count - 1];    //poslednji izbrisani Substation
            deletedSubs.Remove(deleted);

            foreach (ConnectivityNode node in deleted.ConnectivityNodes)
            {
                DataBase.Nodes.Add(node);
            }
            
            DataBase.Substations.Add(deleted);    
            serializeUtil.SerializeSubstations(DataBase.Substations);
            serializeUtil.SerializeNodes(DataBase.Nodes);
        }
    }
}
