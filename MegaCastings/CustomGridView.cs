using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            CollaboratorGridViewColumNames = new String[6];
            OfferGridViewColumNames = new String[13];
        }

        #endregion


        #region Methods

        private String[] PopulateCollaboratorColumNamesArray()
        {
            CollaboratorGridViewColumNames[0] = "Nom";
            CollaboratorGridViewColumNames[1] = "Téléphone";
            CollaboratorGridViewColumNames[2] = "Adresse";
            CollaboratorGridViewColumNames[3] = "Code Postal";
            CollaboratorGridViewColumNames[4] = "Ville";

            return CollaboratorGridViewColumNames;
        }

        private String[] PopulateOfferColumNamesArray()
        {
            OfferGridViewColumNames[0] = "Intitulé";
            OfferGridViewColumNames[1] = "Référence";
            OfferGridViewColumNames[2] = "Date de début";
            OfferGridViewColumNames[3] = "Date de fin";
            OfferGridViewColumNames[4] = "Durée";
            OfferGridViewColumNames[5] = "Nombre de postes";
            OfferGridViewColumNames[6] = "Description du poste";
            OfferGridViewColumNames[7] = "Description du profil";
            OfferGridViewColumNames[8] = "Contact";
            OfferGridViewColumNames[9] = "Client";
            OfferGridViewColumNames[10] = "Métier";
            OfferGridViewColumNames[11] = "Domaine Métier";
            OfferGridViewColumNames[12] = "Type de contrat";

            return OfferGridViewColumNames;
        }

        private String[] PopulateClientColumNamesArray()
        {
            ClientGridViewColumNames[0] = "Nom";
            ClientGridViewColumNames[1] = "Téléphone";
            ClientGridViewColumNames[2] = "Adresse";
            ClientGridViewColumNames[3] = "Code Postal";
            ClientGridViewColumNames[4] = "Ville";
           // ClientGridViewColumNames[5] = "Représentants";

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
                bindingArray = new String[] { "Name", "PhoneNumber", "Address", "ZipCode", "City" };
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
            

            for (int i = 0; i < columnNames.Length-1; i++)
            {
                GridViewColumn gridViewColumn = new GridViewColumn()
                {
                    Header = ClientGridViewColumNames[i],
                    DisplayMemberBinding = new Binding(bindingArray[i]),
                    Width = 269
                    
                };

                MainGridView.Columns.Add(gridViewColumn);
                
            }

            String toto = "toto";

            GridViewColumn lastColumn = new GridViewColumn()
            {
                Header = "Représentants",
                CellTemplate = new DataTemplate(toto),
                Width = 269

            };

            MainGridView.Columns.Add(lastColumn);

            //DataTemplate toto = new DataTemplate("toto");

            //GridViewColumn gridViewColumn1 = new GridViewColumn()
            //{
            //    Header = ClientGridViewColumNames[ClientGridViewColumNames.Length - 1],
            //    Width = 269,
            //    CellTemplate = toto


            //};
            // MainGridView.Columns.Add(gridViewColumn1);
        }
            #endregion
        }
}
