using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.DBLib
{
    public partial class Client
    {
     
        public void FormatPhoneNumberForDisplay()
        {
            int i = 2;

            String phoneNumber = PhoneNumber.Substring(0, 2);

            while (i< PhoneNumber.Length)
            {
             phoneNumber = String.Format("{0}-{1}", phoneNumber, PhoneNumber.Substring(i, 2));

                i += 2;
            }

            PhoneNumber = phoneNumber;
        }

        public void BuildGridView()
        {
            
        }
    }
}
