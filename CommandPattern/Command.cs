using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRVA.CommandPattern
{
    public abstract class Command
    {
        public SerializeUtil.SerializeUtil serializeUtil = SerializeUtil.SerializeUtil.Instance();

        public Command()
        {

        }
        
        public abstract void Execute();

        public abstract void UnExecute();
        
    }
}
