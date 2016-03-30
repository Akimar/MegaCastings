using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.Entities
{
    public class CastingOffer
    {

        #region Attributes & Properties

        private int _Id;

        /// <summary>
        /// Affecte ou obtient l'id
        /// </summary>		
        public virtual int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private String _Title;

        /// <summary>
        /// Affecte ou obtient l'intitulé de l'offre
        /// </summary>		
        public virtual String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private String _Reference;

        /// <summary>
        /// Affecte ou obtient la référence de l'offre
        /// </summary>		
        public virtual String Reference
        {
            get { return _Reference; }
            set { _Reference = value; }
        }


        private DateTime _StartingDate;

        /// <summary>
        /// Affecte ou obtient la date de début de l'offre
        /// </summary>		
        public virtual DateTime StartingDate
        {
            get { return _StartingDate; }
            set { _StartingDate = value; }
        }

        private DateTime _EndingDate;

        /// <summary>
        /// Affecte ou obtient la date de fin de l'offre
        /// </summary>		
        public virtual DateTime EndingDate
        {
            get { return _EndingDate; }
            set { _EndingDate = value; }
        }

        private DateTime _ValidityDuration;

        /// <summary>
        /// Affecte ou obtient la durée de validité de l'offre
        /// </summary>		
        public virtual DateTime ValidityDuration
        {
            get { return _ValidityDuration; }
            set { _ValidityDuration = value; }
        }

        private int _PostNumber;

        /// <summary>
        /// Affecte ou obtient le nombre de postes à pourvoir
        /// </summary>		
        public virtual int PostNumber
        {
            get { return _PostNumber; }
            set { _PostNumber = value; }
        }

        private String _PostDescription;

        /// <summary>
        /// Affecte ou obtient la description du poste
        /// </summary>		
        public virtual String PostDescription
        {
            get { return _PostDescription; }
            set { _PostDescription = value; }
        }

        private String _ProfileDescription;

        /// <summary>
        /// Affecte ou obtient la description du profil pour le poste
        /// </summary>		
        public virtual String ProfileDescription
        {
            get { return _ProfileDescription; }
            set { _ProfileDescription = value; }
        }

        private String _Contact;

        /// <summary>
        /// Affecte ou obtient le contavt pour l'offre
        /// </summary>		
        public virtual String Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }


        /// <summary>
        /// Affecte ou obtient le client à l'origine de l'offre de casting
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// Affecte ou obtient le domaine métier de l'offre
        /// </summary>
        public virtual ProfessionField ProfessionField { get; set; }


        /// <summary>
        /// Affecte ou obtient le métier relatif à l'offre
        /// </summary>
        public virtual Profession Profession { get; set; }



        /// <summary>
        /// Affecte ou obtient le type de contrat de l'offre
        /// </summary>
        public virtual ContractType ContractType { get; set; }



        /*GET HASHCODE, CompareTo et Equals A SURCHARGER*/
        #endregion


        #region Constructors


        public CastingOffer()
        {

        }

        public CastingOffer(String title, String reference, DateTime startingDate, DateTime endingDate, int postNumber, String location, String postDescription, String profilrDecription, String contact, Client client, ProfessionField profesionField, ContractType contractType, Profession profession)
        {

            this.Client = client;
            this.Contact = contact;
            this.EndingDate = endingDate;
            this.PostDescription = postDescription;
            this.PostNumber = postNumber;
            this.Profession = profession;
            this.ProfessionField = ProfessionField;
            this.ProfileDescription = profilrDecription;
            this.Reference = reference;
            this.StartingDate = startingDate;
            this.Title = title;
            this.ValidityDuration = ValidityDuration;
            this.ContractType = contractType;
           
        }

        #endregion

        public override int GetHashCode()
        {
            return ((!string.IsNullOrEmpty(Reference) ? Reference.GetHashCode() : 0));
        }

        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }

        public int CompareTo(CastingOffer other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }

    }
}
