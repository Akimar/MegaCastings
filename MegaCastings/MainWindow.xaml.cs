﻿
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using MegaCastings.Entities;
using NHibernate;
using System;
using System.Reflection;
using FluentNHibernate.Cfg;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using MegaCastings.DBLib.Maps;

namespace MegaCastings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes & Properties
        // Création de la session de bdd
        private ISessionFactory isessionfactory = CreateSessionFactory();

        private BindingList<Client> BindingClient { get; set; }

        private BindingList<CastingOffer> BindingCastings { get; set; }

        private BindingList<Collaborator> BindingCollaborator { get; set; }

        #endregion

        #region Constructors
        public MainWindow()
        {
            //Initialisation des propriétes de binding
            InitializeComponent();

            using (ISession session = isessionfactory.OpenSession())//ouverture
            {
                BindingClient = new BindingList<Client>(session.QueryOver<Client>().List());
                BindingCastings = new BindingList<CastingOffer>(session.QueryOver<CastingOffer>().List());
                BindingCollaborator = new BindingList<Collaborator>(session.QueryOver<Collaborator>().List());
                isessionfactory.Close();
            }
            DataGridClients.ItemsSource = BindingClient;
            DataGridCastings.ItemsSource = BindingCastings;
            DataGridPartenaires.ItemsSource = BindingCollaborator;
        }

        #endregion

        #region Methods
        #region Button Events
        /// <summary>
        /// Ferme l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Ouvre une fenêtre modale pour ajouter un client ou bien une offre de casting, ou encore un partenaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (GroupBoxClients.Visibility == Visibility.Visible)
            {
                AddClient AddClientFrame = new AddClient();
                AddClientFrame.ShowDialog();
                BindingClient.Add(AddClientFrame.AddedClient);
            }
            else if (GroupBoxCastings.Visibility == Visibility.Visible)
            {

            }

            else if (GroupBoxCollaborators.Visibility == Visibility.Visible)
            {

            }
        }

        /// <summary>
        /// /// Ouvre une fenêtre modale pour modifier un client ou bien une offre de casting, ou encore un partenaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Manage(object sender, RoutedEventArgs e)
        {
            if (GroupBoxClients.Visibility == Visibility.Visible)
            {
                Client toModifie = null;
                if (DataGridClients.SelectedItem != null)
                {
                    toModifie = (Client)DataGridClients.SelectedItem;
                    AddClient AddClientFrame = new AddClient(toModifie);
                    AddClientFrame.ShowDialog();
                    BindingClient[BindingClient.IndexOf(toModifie)] = AddClientFrame.AddedClient;
                    BindingClient.RaiseListChangedEvents = true;
                }
            }
            else if (GroupBoxCastings.Visibility == Visibility.Visible)
            {

            }

            else if (GroupBoxCollaborators.Visibility == Visibility.Visible)
            {

            }
        }

        /// Ouvre une fenêtre modale pour supprimer un client ou bien une offre de casting, ou encore un partenaire
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (GroupBoxClients.Visibility == Visibility.Visible)
            {

            }
            else if (GroupBoxCastings.Visibility == Visibility.Visible)
            {

            }

            else if (GroupBoxCollaborators.Visibility == Visibility.Visible)
            {

            }
        }

        /// <summary>
        /// /// Affiche via le GridView la liste des clients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_DisplayClients(object sender, RoutedEventArgs e)
        {
            ShowDatagrid(GroupBoxClients);
        }

        /// <summary>
        /// Affiche via le GridView la liste des castings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_DisplayCastings(object sender, RoutedEventArgs e)
        {
            ShowDatagrid(GroupBoxCastings);
        }

        /// <summary>
        /// /// Affiche via le GridView la liste des partenaires
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_DisplayCollaborators(object sender, RoutedEventArgs e)
        {
            ShowDatagrid(GroupBoxCollaborators);
        }

        #endregion

        /// <summary>
        /// Rend visible le datagrid passé en parametre et cache les deux autres.
        /// </summary>
        /// <param name="dataGrid">datagrid à rendre visible</param>
        private void ShowDatagrid(GroupBox gb)
        {
            if (gb != GroupBoxCastings)
            {
                GroupBoxCastings.Visibility = Visibility.Hidden;
            }
            if (gb != GroupBoxClients)
            {
                GroupBoxClients.Visibility = Visibility.Hidden;
            }
            if (gb != GroupBoxCollaborators)
            {
                GroupBoxCollaborators.Visibility = Visibility.Hidden;
            }
            gb.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Créer l'objet base de donnée et la construit si besoin (connexion string dans app.config)
        /// </summary>
        /// <param name="typeBDD">A FAIRE</param>
        /// <returns>Objet de base de données</returns>
        public static ISessionFactory CreateSessionFactory()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[System.Configuration.ConfigurationManager.AppSettings["currentConnectionString"]].ConnectionString;
            string typeBDD = System.Configuration.ConfigurationManager.AppSettings["DatabaseType"];
            FluentNHibernate.Cfg.Db.IPersistenceConfigurer BDD = null ;
            switch (typeBDD)
            {
                case "MySQL":
                    BDD = FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard.ConnectionString(connectionString);
                    break;

                case "SQLServer2012":
                    BDD = FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2012.ConnectionString(connectionString);
                    break;
                case "SQLServer2008":
                    BDD = FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008.ConnectionString(connectionString);
                    break;

            }

            Assembly ass = Assembly.Load("MegaCastings.DBLib");

            FluentConfiguration Fluconfig = Fluently.Configure()
                .Database(BDD)
              .Mappings(m =>
                m.FluentMappings.AddFromAssembly(ass));

            Configuration config = Fluconfig.BuildConfiguration();

            // Création du schéma de base de données
            new SchemaUpdate(config).Execute(true, true);

            // Démarrage de la session factory
            return config.BuildSessionFactory();
        }

        #endregion
    }
}
