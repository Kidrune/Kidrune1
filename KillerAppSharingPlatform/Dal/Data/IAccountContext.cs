using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerAppSharingPlatform.Classes;

namespace KillerAppSharingPlatform.Dal.Data
{
    interface IAccountContext
    {

        bool LoginUser(string username, string password);

        Client GetUserCredentials(string username);

        bool RegisterUser(Client client);

    }
}
