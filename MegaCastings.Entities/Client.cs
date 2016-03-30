using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.Entities
{
    public class Client : ContactDetails
    {

        #region Attributes & Properties


        private String _Name;

        /// <summary>
        /// Affecte ou obtient le nom du client
        /// </summary
        public virtual String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

   
        /// <summary>
        /// Affecte ou obtient une collection de représentants
        /// </summary>
        public virtual ICollection<Representative> Representatives { get; set; }

        #endregion


        #region Constructors



        public Client()
        {
            this.Representatives = new HashSet<Representative>();
        }

        public Client(String name, String phoneNumber, String address, String zipCode, String city) :this ()
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.ZipCode = zipCode;
            this.City = city;
        }

        public override string ToString()
        {
            return this.Name;
        }
        #endregion

    }
}
