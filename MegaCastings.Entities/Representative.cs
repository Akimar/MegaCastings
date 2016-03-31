using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.Entities
{
    public  class Representative : IComparable<Profession>
    {
        #region Attributes & Propeties

        private int _Id;

        /// <summary>
        /// Affecte ou obtient l'id
        /// </summary>
        public virtual int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private String _LastName;

        /// <summary>
        /// Affecte ou obtient le nom de famille 
        /// </summary>
        public virtual String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }


        private String _FirstName;

        /// <summary>
        /// Affecte ou obtient le prénom
        /// </summary>
        public virtual String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }


        private String _PhoneNumber;


        /// <summary>
        /// Affecte ou obtient le téléphone
        /// </summary>
        public virtual String PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }

        /// <summary>
        /// Affecte ou obtient l'organisation associée
        /// </summary>
        public virtual Client Client { get; set; }

        #endregion

        #region Constructors

        public Representative()
        {

        }

        public Representative(String lastName, String firstName, String phoneNumber, Client client)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.PhoneNumber = phoneNumber;
            this.Client = client;
        }

        #endregion


        public override int GetHashCode()
        {
            return (FirstName.GetHashCode() + LastName.GetHashCode() + PhoneNumber.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }

        public virtual int CompareTo(Profession other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
    }
}
