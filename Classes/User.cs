using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class User
    {
        public Client client { get; private set; }
        public string status { get; private set; }
        public string preference { get; private set; }
        public string gender { get; private set; }  
    }
}
