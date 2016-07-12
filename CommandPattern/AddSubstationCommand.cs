using CIM.IEC61970.Base.Core;
using ProjectRVA.FacadePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRVA.CommandPattern
{
    public class AddSubstationCommand : Command
    {
        private string name = "";
        private string voltageLevel = "";
        private string description = "";

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

        public AddSubstationCommand(string name, string vl, string desc)
        {
            this.Name = name;
            this.VoltageLevel = vl;
            this.Description = desc;
        }
        
        public override void Execute()
        {
            //Dodaj trafostanicu -> FACADE (jer zahtjeva postojanje nekih drugih elemenata)
            
            FacadaZaKreiranjeTrafostanice fasada = CreateFacade();

        }

        private FacadaZaKreiranjeTrafostanice CreateFacade()
        {
            //Create IdentifiedObject for Substation
            IdentifiedObject idObject = new IdentifiedObject();
            idObject.aliasName = "Substation";
            idObject.name = this.Name;
            idObject.description = this.Description;
            idObject.mRID = Guid.NewGuid().ToString();

            FacadaZaKreiranjeTrafostanice fasada =  new FacadaZaKreiranjeTrafostanice(idObject, voltageLevel);

            return fasada;
        }

        public override void UnExecute()
        {
            //Obrisi poselednju dodatu (???) brlja ovdje
            Database.DataBase.Substations.Remove(Database.DataBase.Substations[Database.DataBase.Substations.Count - 1]);

            //Serijalizuj
            serializeUtil.SerializeNodes(Database.DataBase.Nodes);
            serializeUtil.SerializeSubstations(Database.DataBase.Substations);
        }
    }
}
