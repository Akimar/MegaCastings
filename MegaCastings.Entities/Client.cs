using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.Entities
{
    public class Client
    {

        #region Attributes & Properties

        private int _Id;

        /// <summary>
        /// Affecte ou obtient l'id du client
        /// </summary>
        public virtual int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }


        private String _Name;

        /// <summary>
        /// Affecte ou obtient le nom du client
        /// </summary
        public virtual String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private String _PhoneNumber;

        /// <summary>
        /// Affecte ou obtient le téléphone du client
        /// </summary
        public virtual String PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }


        private String _Address;

        /// <summary>
        /// Affecte ou obtient l'adresse du client
        /// </summary
        public virtual String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }


        private String _ZipCpde;

        /// <summary>
        /// Affecte ou obtient le code postal
        /// </summary>
        public virtual String ZipCode
        {
            get { return _ZipCpde; }
            set { _ZipCpde = value; }
        }

        private String _City;

        /// <summary>
        /// Affecte ou obtient la ville du client
        /// </summary>
        public virtual String  City
        {
            get { return _City; }
            set { _City = value; }
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

        #endregion

    }
}
