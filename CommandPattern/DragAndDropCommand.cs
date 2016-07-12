using CIM.IEC61970.Base.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRVA.CommandPattern
{
    public class DragAndDropCommand : Command
    {
        private double novoX;
        private double novoY;
        private Substation substation;
        
        public DragAndDropCommand(double x,double y, Substation substation)
        {
            this.novoX = x;
            this.novoY = y;
            this.substation = substation;
        }

        public override void Execute()
        {
            
            foreach(Substation sub in Database.DataBase.Substations)
            {
                if(sub == substation)
                {
                    sub.X = novoX;
                    sub.Y = novoY;
                    break;
                }
            }

            serializeUtil.SerializeSubstations(Database.DataBase.Substations);
        }

        public override void UnExecute()
        {
           // throw new NotImplementedException();
        }
    }
}
