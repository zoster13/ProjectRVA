using CIM.IEC61970.Base.Core;
using ProjectRVA.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRVA.FacadePattern
{
    public class FacadaZaKreiranjeTrafostanice
    {
        PowerSystemResource psr = new PowerSystemResource();
        Equipment equipment = new Equipment();
        EquipmentContainer equipmnetContainer = new EquipmentContainer();

        DataBase db = DataBase.Instance();
        SerializeUtil.SerializeUtil serializeUtil = SerializeUtil.SerializeUtil.Instance();
       
        public FacadaZaKreiranjeTrafostanice(IdentifiedObject idObject, string nominalVoltage)
        {
            
            BaseVoltage baseVoltage = new BaseVoltage();
            baseVoltage.AliasName = "BaseVoltage";
            baseVoltage.name = nominalVoltage + "kv";
            baseVoltage.mRID = Guid.NewGuid().ToString();
            baseVoltage.nominalVoltage = float.Parse(nominalVoltage);

            VoltageLevel voltageLevel = new VoltageLevel();
            voltageLevel.AliasName = "VoltageLevel";
            voltageLevel.name = nominalVoltage + "kv";
            voltageLevel.mRID = Guid.NewGuid().ToString();
            voltageLevel.BaseVoltage = baseVoltage;

            Substation substation = new Substation();
            substation.AliasName = idObject.AliasName;
            substation.Name = idObject.name;
            substation.description = idObject.description;
            substation.mRID = idObject.mRID;
            substation.VoltageLevels.Add(voltageLevel);

            //Dodaj u listu
            DataBase.Substations.Add(substation);
            serializeUtil.SerializeSubstations(DataBase.Substations);
        }
    }
}
