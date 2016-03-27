using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.Entities
{
    public abstract class ContactDetails
    {
        private int _Id;

        /// <summary>
        /// Affecte ou obtient l'id
        /// </summary>		
        public virtual int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private String _PhoneNumber;

        /// <summary>
        /// Affecte ou obtient le numéro de téléphone
        /// </summary>		
        public virtual String PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }


        private String _Address;

        /// <summary>
        /// Affecte ou obtient l'adresse
        /// </summary>		
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
        /// Affecte ou obtient la ville
        /// </summary>		
        public virtual String City
        {
            get { return _City; }
            set { _City = value; }
        }





    }
}
