using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.DBLib
{
    public partial class Client
    {
        private String _Address;

        public String Adresse
        {
            get { return String.Format("{0} {1}", NumRue, NomRue); }
        }

        private String _FormatTelNumber;

        public String FormatPhoneNumber
        {
            get { return T; }
           
        }


    }
}
