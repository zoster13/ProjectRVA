using CIM.IEC61970.Base.Core;
using ProjectRVA.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRVA.FacadePattern
{
    public class CreateNodeFacade
    {

        SerializeUtil.SerializeUtil serializeUtil = SerializeUtil.SerializeUtil.Instance();

        public CreateNodeFacade(string name, string voltageLevel, string desc, string nameOfSubstation)
        {
            IdentifiedObject idObject = new IdentifiedObject();
            idObject.AliasName = "Node";
            idObject.Name = name;
            idObject.Description = desc;
            idObject.MRID = Guid.NewGuid().ToString();

            BaseVoltage baseVoltage = new BaseVoltage();
            baseVoltage.aliasName = "BaseVoltage";
            baseVoltage.name = voltageLevel;
            baseVoltage.nominalVoltage = float.Parse(voltageLevel);
            baseVoltage.mRID = Guid.NewGuid().ToString();

            ConnectivityNode node = new ConnectivityNode();
            node.name = idObject.name;
            node.aliasName = idObject.aliasName;
            node.description = idObject.description;
            node.mRID = idObject.mRID;
            node.m_BaseVoltage = baseVoltage;

            DataBase.Nodes.Add(node);
            
            //Dodavanje cvora trafostanicu
            foreach(Substation sub in DataBase.Substations)
            {
                if (sub.Name.Equals(nameOfSubstation))
                    sub.ConnectivityNodes.Add(node);
            }

            //Serijalizacija
            serializeUtil.SerializeNodes(DataBase.Nodes);
            serializeUtil.SerializeSubstations(DataBase.Substations);
        }
    }
}
