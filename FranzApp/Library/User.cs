using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranzApp.Library
{
    class User
    {
        public int userID { get; set; }

        public String lastname { get; set; }
        public String firstname { get; set; }

        public String passcode { get; set; }

        public String eMail { get; set; }

        public Boolean admin { get; set; }
        public Boolean teacher { get; set; }
        public Boolean student { get; set; }
        public Boolean guest { get; set; }

        public Boolean darkMode { get; set; }

        public String group { get; set; }
    }
}
