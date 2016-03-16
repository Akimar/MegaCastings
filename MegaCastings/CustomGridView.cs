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
    public class CustomDataGrid
    {

        #region Attributes & Properties

        private DataGrid _MainDataGrid;

        /// <summary>
        /// Affecte ou obtient le DataGrid de l'écran principal
        /// </summary>
        public DataGrid MainDataGrid
        {
            get { return _MainDataGrid; }
            set { _MainDataGrid = value; }
        }


        private String[] _ClientDataGridColumNames;

        /// <summary>
        /// Affecte ou obtient le tableau de chaines qui contient les nom des colonnes du DataGrid des clients
        /// </summary>
        private String[] ClientDataGridColumNames
        {
            get { return _ClientDataGridColumNames; }
            set { _ClientDataGridColumNames = value; }
        }


        private String[] _CollaboratorDataGridColumNames;

        /// <summary>
        /// Affecte ou obtient le tableau de chaines qui contient les nom des colonnes du DataGrid des partenaires
        /// </summary>
        private String[] CollaboratorDataGridColumNames
        {
            get { return _CollaboratorDataGridColumNames; }
            set { _CollaboratorDataGridColumNames = value; }
        }


        private String[] _OfferDataGridColumNames;

        /// <summary>
        ///  Affecte ou obtient le tableau de chaines qui contient les nom des colonnes du DataGrid des partenaires
        /// </summary>
        private String[] OfferDataGridColumNames
        {
            get { return _OfferDataGridColumNames; }
            set { _OfferDataGridColumNames = value; }
        }

        #endregion

        #region Constructor

        public CustomDataGrid()
        {
            MainDataGrid = new DataGrid()
            {
                AutoGenerateColumns = false,
                GridLinesVisibility = DataGridGridLinesVisibility.None,
                
            };
            ClientDataGridColumNames = new String[6];
            CollaboratorDataGridColumNames = new String[6];
            OfferDataGridColumNames = new String[13];
        }

        #endregion


        #region Methods

        private String[] PopulateCollaboratorColumNamesArray()
        {
            CollaboratorDataGridColumNames[0] = "Nom";
            CollaboratorDataGridColumNames[1] = "Téléphone";
            CollaboratorDataGridColumNames[2] = "Adresse";
            CollaboratorDataGridColumNames[3] = "Code Postal";
            CollaboratorDataGridColumNames[4] = "Ville";

            return CollaboratorDataGridColumNames;
        }

        private String[] PopulateOfferColumNamesArray()
        {
            OfferDataGridColumNames[0] = "Intitulé";
            OfferDataGridColumNames[1] = "Référence";
            OfferDataGridColumNames[2] = "Date de début";
            OfferDataGridColumNames[3] = "Date de fin";
            OfferDataGridColumNames[4] = "Durée";
            OfferDataGridColumNames[5] = "Nombre de postes";
            OfferDataGridColumNames[6] = "Description du poste";
            OfferDataGridColumNames[7] = "Description du profil";
            OfferDataGridColumNames[8] = "Contact";
            OfferDataGridColumNames[9] = "Client";
            OfferDataGridColumNames[10] = "Métier";
            OfferDataGridColumNames[11] = "Domaine Métier";
            OfferDataGridColumNames[12] = "Type de contrat";

            return OfferDataGridColumNames;
        }

        private String[] PopulateClientColumNamesArray()
        {
            ClientDataGridColumNames[0] = "Nom";
            ClientDataGridColumNames[1] = "Téléphone";
            ClientDataGridColumNames[2] = "Adresse";
            ClientDataGridColumNames[3] = "Code Postal";
            ClientDataGridColumNames[4] = "Ville";
           // ClientDataGridColumNames[5] = "Représentants";

            return ClientDataGridColumNames;
        }


        /// <summary>
        /// Construit le DataGrid avec le nombre de colonnes et les noms des colonnes à afficher
        /// </summary>
        /// <param name="dataIndex">dataIndex permet de savoir quelles données doivent être affichées : 0 pour les clients, 1 pour les offres de casting et 2 pour les patenaires</param>
        public void BuildDataGrid(int dataIndex)
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
                DataGridTextColumn DataGridColumn = new DataGridTextColumn()
                {
                    Header = ClientDataGridColumNames[i],
                    Binding = new Binding(bindingArray[i]),
                    Width = 269
                };

                MainDataGrid.Columns.Add(DataGridColumn);
                
            }

            //DataTemplate toto = new DataTemplate(typeof(StackPanel));
            //FrameworkElementFactory test = new FrameworkElementFactory(typeof(StackPanel));
            //test.AppendChild(new FrameworkElementFactory(typeof(Button)));
            //toto.VisualTree = test;
            //DataGridColumn lastColumn = new DataGridColumn()
            //{
            //    Header = "Représentants",
            //    CellTemplate = toto,
            //    Width = 269

            //};

           // MainDataGrid.Columns.Add(lastColumn);

            DataTemplate toto = new DataTemplate("toto");

            //DataGridColumn DataGridColumn1 = new DataGridColumn()
            //{
            //    Header = ClientDataGridColumNames[ClientDataGridColumNames.Length - 1],
            //    Width = 269,
            //    CellTemplate = toto


            //};
            //MainDataGrid.Columns.Add(DataGridColumn1);
        }
            #endregion
        }
}
