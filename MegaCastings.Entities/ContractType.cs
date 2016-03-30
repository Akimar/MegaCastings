using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.Entities
{
   public class ContractType
    {

        #region Attributes & Properties

        private int _Id;

        /// <summary>
        /// Affecte ou obtient l'id du type de contrat
        /// </summary>
        public virtual int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }



        private String _ConType;

        /// <summary>
        /// Affecte ou obtient le type de contrat
        /// </summary>		
        public virtual String ConType
        {
            get { return _ConType; }
            set { _ConType = value; }
        }

        #endregion

        #region Constructors

        public ContractType()
        {

        }

        public ContractType(String conType)
        {
            this.ConType = conType;
        }

        #endregion

        public override int GetHashCode()
        {
            return ((!string.IsNullOrEmpty(ConType) ? ConType.GetHashCode() : 0));
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
