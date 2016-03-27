using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.Entities
{
    public class Collaborator : ContactDetails
    {
        #region Attributes & Properties
   
        private String _Login;

        /// <summary>
        /// Affecte ou obtient le login du partenaire
        /// </summary>		
        public virtual String Login
        {
            get { return _Login; }
            set { _Login = value; }
        }

        private String _Password;

        /// <summary>
        /// Affecte ou obtient le mot de passe (hash) du partenaire
        /// </summary>		
        public virtual String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }


        private String _Name;

        /// <summary>
        /// Affecte ou obtient le nom du partenaire
        /// </summary>		
        public virtual String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Affecte ou obtient les offres de casting du client
        /// </summary>
        public virtual ICollection<CastingOffer> CastingOffers { get; set; }

        #endregion

        #region Constructors

        public Collaborator()
        {
            this.CastingOffers = new HashSet<CastingOffer>();
        }



        public Collaborator(String login, String password, String name, String phoneNumber, String zipCode, String address, String city) : this()
        {
            this.Login = login;
            this.Password = password;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.ZipCode = zipCode;
            this.Address = address;
            this.City = city;
        }
        #endregion

    }
}
