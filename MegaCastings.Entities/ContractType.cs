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



        private Boolean _ConType;

        /// <summary>
        /// Affecte ou obtient le booleen déterminant si le contrat est à durée déterminée ou non
        /// </summary>		
        public virtual Boolean ConType
        {
            get { return _ConType; }
            set { _ConType = value; }
        }

        #endregion

        #region Constructors

        public ContractType()
        {

        }

        public ContractType(Boolean conType)
        {
            this.ConType = conType;
        }

        #endregion

    }
}
