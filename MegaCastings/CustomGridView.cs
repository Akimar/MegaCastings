using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace MegaCastings
{
    public class CustomGridView
    {

        #region Attributes & Properties

        private GridView _MainGridView;

        /// <summary>
        /// Affecte ou obtient le GridView de l'écran principal
        /// </summary>
        public GridView MainGridView
        {
            get { return _MainGridView; }
            set { _MainGridView = value; }
        }


        private String[] _ClientGridViewColumNames;

        /// <summary>
        /// Affecte ou obtient le tableau de chaines qui contient les nom des colonnes du gridview des clients
        /// </summary>
        private String[] ClientGridViewColumNames
        {
            get { return _ClientGridViewColumNames; }
            set { _ClientGridViewColumNames = value; }
        }


        private String[] _CollaboratorGridViewColumNames;

        /// <summary>
        /// Affecte ou obtient le tableau de chaines qui contient les nom des colonnes du gridview des partenaires
        /// </summary>
        private String[] CollaboratorGridViewColumNames
        {
            get { return _CollaboratorGridViewColumNames; }
            set { _CollaboratorGridViewColumNames = value; }
        }


        private String[] _OfferGridViewColumNames;

        /// <summary>
        ///  Affecte ou obtient le tableau de chaines qui contient les nom des colonnes du gridview des partenaires
        /// </summary>
        private String[] OfferGridViewColumNames
        {
            get { return _OfferGridViewColumNames; }
            set { _OfferGridViewColumNames = value; }
        }

        #endregion

        #region Constructor

        public CustomGridView()
        {
            MainGridView = new GridView();
            ClientGridViewColumNames = new String[6];
            CollaboratorGridViewColumNames = new String[5];
            OfferGridViewColumNames = new String[6];
        }

        #endregion


        #region Methods

        private String[] PopulateCollaboratorColumNamesArray()
        {

            return CollaboratorGridViewColumNames;
        }

        private String[] PopulateOfferColumNamesArray()
        {

            return OfferGridViewColumNames;
        }

        private String[] PopulateClientColumNamesArray()
        {
            ClientGridViewColumNames[0] = "Nom";
            ClientGridViewColumNames[1] = "Prénom";
            ClientGridViewColumNames[2] = "Téléphone";
            ClientGridViewColumNames[3] = "Adresse";
            ClientGridViewColumNames[4] = "Code Postal";
            ClientGridViewColumNames[5] = "Ville";

            return ClientGridViewColumNames;
        }


        /// <summary>
        /// Construit le gridview avec le nombre de colonnes et les noms des colonnes à afficher
        /// </summary>
        /// <param name="dataIndex">dataIndex permet de savoir quelles données doivent être affichées : 0 pour les clients, 1 pour les offres de casting et 2 pour les patenaires</param>
        public void BuildGridView(int dataIndex)
        {
            String[] columnNames = null;
            String[] bindingArray = null; 

            if (dataIndex == 0)
            {
                bindingArray = new String[] { "LastName", "FirstName", "PhoneNumber", "Address", "ZipCode", "City" };
                columnNames = PopulateClientColumNamesArray();

            }
            else if(dataIndex == 1)
            {
                bindingArray = new String[] {};
                columnNames = PopulateOfferColumNamesArray();
            }
            else if(dataIndex == 2)
            {
                bindingArray = new String[] { };
                columnNames = PopulateCollaboratorColumNamesArray();
            }
            

            for (int i = 0; i < columnNames.Length; i++)
            {
                GridViewColumn gridViewColumn = new GridViewColumn()
                {
                    Header = ClientGridViewColumNames[i],
                    DisplayMemberBinding = new Binding(bindingArray[i]),
                    Width = 269
                    
                };

                MainGridView.Columns.Add(gridViewColumn);
            }

        }
            #endregion
        }
}
