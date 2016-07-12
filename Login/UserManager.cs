using ProjectRVA.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectRVA.Login
{
    public class UserManager
    {
        private static UserManager userManger;
        public static List<User> users = new List<User>();

        SerializeUtil.SerializeUtil serializeUtil = SerializeUtil.SerializeUtil.Instance();
        DataBase db = DataBase.Instance();

        public UserManager() { }

        public static UserManager Instance()
        {
            if (userManger == null)
                userManger = new UserManager();

            return userManger;
        }

        public bool CheckUser(string username, string password)
        {
            //Deserijalizacija
            DataBase.Substations = serializeUtil.DeserializeSubstations();
            DataBase.Nodes = serializeUtil.DeserializeNodes();
            users = serializeUtil.DeserializeUsers();
           
            //korisnicko & pass
            foreach(User user in users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                    return true;
            }
            
            return false;
        }

    }
}
