using CIM.IEC61970.Base.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRVA.Prototype
{
    public static class Kloniraj
    {
        public static void Clone(Object obj)
        {
            //Kloniraj Substation - Ubaciti u Protorype
            if (obj.GetType() == typeof(Substation))
            {
                Substation sub = obj as Substation;

                Substation subCopy = new Substation();
                subCopy.name = sub.name + "Copy";
                subCopy.mRID = sub.mRID;
                subCopy.aliasName = sub.aliasName;
                subCopy.description = sub.description;
                //subCopy.ConnectivityNodes = sub.ConnectivityNodes;      //nece raditi!!!

                foreach(ConnectivityNode node in sub.ConnectivityNodes)
                {
                    ConnectivityNode newNode = new ConnectivityNode();
                    newNode.aliasName = node.aliasName;
                    newNode.name = node.name;
                    newNode.X = node.X;
                    newNode.Y = node.Y;
                    newNode.mRID = node.mRID;
                    newNode.Description = node.Description;
                    newNode.m_BaseVoltage = node.m_BaseVoltage;
                    
                    subCopy.ConnectivityNodes.Add(newNode);
                }

                Database.DataBase.Substations.Add(subCopy);
            }

            //Kloniraj ConnectivityNode
            if (obj.GetType() == typeof(ConnectivityNode))
            {
                ConnectivityNode node = obj as ConnectivityNode;

                ConnectivityNode nodeCopy = new ConnectivityNode();
                nodeCopy.name = node + "Copy";
                nodeCopy.mRID = node.mRID;
                nodeCopy.aliasName = node.aliasName;
                nodeCopy.description = node.description;
                nodeCopy.X = node.X + 10;
                nodeCopy.Y = node.Y + 10;
                nodeCopy.m_BaseVoltage = node.m_BaseVoltage;

                Database.DataBase.Nodes.Add(node);
            }
        }

    }
}
