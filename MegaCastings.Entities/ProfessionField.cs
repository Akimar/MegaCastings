using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.Entities
{
   public class ProfessionField
    {

        #region Attributes & Properties

        private int _Id;

        /// <summary>
        /// Affecte ou obtient l'id du domaine métier
        /// </summary>
        public virtual int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private String _Title;

        /// <summary>
        /// Affecte ou obtient l'intitulé du domaine métier
        /// </summary>
        public virtual String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        /// <summary>
        /// Affecte ou obtient une collection de professions
        /// </summary>
        public virtual ICollection<Profession> Professions { get; set; }

        #endregion


        #region Constructors

        public ProfessionField()
        {
            this.Professions = new HashSet<Profession>();
        }

        public ProfessionField(String title) : this ()
        {
            this.Title = title;
        }

        #endregion

        public override int GetHashCode()
        {
            return ((!string.IsNullOrEmpty(Title) ? Title.GetHashCode() : 0));
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
