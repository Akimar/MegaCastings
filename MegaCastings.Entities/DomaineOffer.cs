using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.Entities
{
    public class DomaineOffer
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
        /// Affecte ou obtient l'intitulé du domaine
        /// </summary>		
        public virtual String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private String _Description;

        /// <summary>
        /// Affecte ou obtient la description du domaine
        /// </summary>		
        public virtual String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }


        #endregion

        #region Constructors

        public DomaineOffer()
        {

        }

        #endregion

        public override string ToString()
        {
            return Title;
        }
    }
}
