using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRVA.CommandPattern
{
    public class Commander
    {
        private static List<Command> history;
        private static int currentCommand;

        public Commander()
        {
            history = new List<Command>();
            currentCommand = 0;
        }

        public void AddAndExecute(Command command)
        {
            command.Execute();


            //Add command to undo list
            history.Add(command);
            //++currentCommand;
            currentCommand = history.Count;
        }

        public void Undo()
        {
            if (currentCommand != 0)
            {
                Command cmd = history[--currentCommand];
                cmd.UnExecute();
            }
        }
    }
}
