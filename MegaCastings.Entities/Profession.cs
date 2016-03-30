using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.Entities
{
    public class Profession
    {
        #region Attributes & Properties

        private int _Id;

        /// <summary>
        /// Affecte ou obtient l'id de la profession
        /// </summary>
        public virtual int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private String _Name   ;
        
        /// <summary>
        /// Affecte ou obtient le nom de la profession
        /// </summary>
        public virtual String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Affecte ou obtient le domaine métier associé
        /// </summary>
        public virtual ProfessionField ProfessionField { get; set; }

        #endregion


        #region Constructors

        public Profession()
        {


        }


        public Profession(String name, ProfessionField professionField)
        {
            this.Name = name;
            this.ProfessionField = professionField;
        }
        #endregion

        public override int GetHashCode()
        {
            return ((!string.IsNullOrEmpty(Name) ? Name.GetHashCode() : 0));
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
