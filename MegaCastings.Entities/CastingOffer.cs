using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.Entities
{
    public class CastingOffer : IComparable<CastingOffer>
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


        private DateTime _BroadcastStartingDate;

        /// <summary>
        /// Affecte ou obtient la date de début de publication
        /// </summary>		
        public virtual DateTime BroadcastStartingDate
        {
            get { return _BroadcastStartingDate; }
            set { _BroadcastStartingDate = value; }
        }


        private DateTime _ContractStartingDate;

        /// <summary>
        /// Affecte ou obtient la date de début du contrat
        /// </summary>		
        public virtual DateTime ContractStartingDate
        {
            get { return _ContractStartingDate; }
            set { _ContractStartingDate = value; }
        }


        private String _BroadcastingTime;

        /// <summary>
        /// Affecte ou obtient la durée de diffusion
        /// </summary>		
        public virtual String BroadcastingTime
        {
            get { return _BroadcastingTime; }
            set { _BroadcastingTime = value; }
        }

        private String _Location;

        /// <summary>
        /// Affecte ou obtient le lieu de l'offre de castingss
        /// </summary>		
        public virtual String Location
        {
            get { return _Location; }
            set { _Location = value; }
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

        /// <summary>
        /// Affecte ou obtient le Domaine de contrat de l'offre
        /// </summary>
        public virtual DomaineOffer DomaineOffer { get; set; }


        #endregion


        #region Constructors


        public CastingOffer()
        {

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

        public virtual int CompareTo(CastingOffer other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }

    }
}
