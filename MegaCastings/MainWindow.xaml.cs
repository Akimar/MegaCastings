
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
using System.Collections.Generic;

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
            this.DataContext = this;

            //Récupération des clients, offres et partenaires présents en base
            using (ISession session = isessionfactory.OpenSession())//ouverture
            {
                BindingClient = new BindingList<Client>(session.QueryOver<Client>().List());
                BindingCastings = new BindingList<CastingOffer>(session.QueryOver<CastingOffer>().Fetch(x => x.ContractType).Eager.Fetch(x => x.Profession).Eager.List());
                BindingCollaborator = new BindingList<Collaborator>(session.QueryOver<Collaborator>().List());
                isessionfactory.Close();
            }



            DataGridClients.ItemsSource = BindingClient;
            DataGridCastings.ItemsSource = BindingCastings;
            DataGridCollaborators.ItemsSource = BindingCollaborator;

            //affiche par défaut la liste des clients
            ShowDatagrid(GroupBoxClients);

            Tb_Name.Text = "Bonjour "+ System.Environment.UserName;
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
                ClientManagement AddClientFrame = new ClientManagement();
                if (AddClientFrame.ShowDialog().Value == true)
                {
                    BindingClient.Add(AddClientFrame.CurrentClient);
                }
            }
            else if (GroupBoxCastings.Visibility == Visibility.Visible)
            {
                OfferManagement AddOfferFrame = new OfferManagement();
                if (AddOfferFrame.ShowDialog().Value == true)
                {
                    BindingCastings.Add(AddOfferFrame.CurrentOffer);
                }
            }

            else if (GroupBoxCollaborators.Visibility == Visibility.Visible)
            {
                CollaboratorManagement CollaboratorManagementFrame = new CollaboratorManagement();
                if (CollaboratorManagementFrame.ShowDialog().Value == true)
                {
                    BindingCollaborator.Add(CollaboratorManagementFrame.CurrentCollaborator);
                }
            }
        }

        /// <summary>
        ///Ouvre une fenêtre modale pour modifier un client ou bien une offre de casting, ou encore un partenaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Manage(object sender, RoutedEventArgs e)
        {
            Manage();
        }

        /// Ouvre une fenêtre modale pour supprimer un client ou bien une offre de casting, ou encore un partenaire
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Delete();
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

        /// <summary>
        /// Au double clic sur un client, une offre ou un partenaire, ouverture de la fenêtre de modification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridClients_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Manage();
        }

        /// <summary>
        /// Au clic sur le lien graphique correspondant, affiche dans une fenêtre modale la description du profil de l'offre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkProfile_RequestNavigate(object sender, RoutedEventArgs e)
        {
            CastingOffer selected = DataGridCastings.SelectedItem as CastingOffer;
            MessageBox.Show(selected.ProfileDescription, "Profil recherché", MessageBoxButton.OK, MessageBoxImage.None);
        }

        /// <summary>
        /// Au clic sur le lien graphique correspondant, affiche dans une fenêtre modale la description du poste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkDescription_RequestNavigate(object sender, RoutedEventArgs e)
        {
            CastingOffer selected = DataGridCastings.SelectedItem as CastingOffer;
            MessageBox.Show(selected.PostDescription, "Description du poste", MessageBoxButton.OK, MessageBoxImage.None);
        }

        #endregion


        #region Member functions
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
        ///  Ouvre une fenêtre modale pour modifier un client ou bien une offre de casting, ou encore un partenaire en fonction du datagrid visible
        /// </summary>
        private void Manage()
        {
            if (GroupBoxClients.Visibility == Visibility.Visible)
            {
                Client toModify = null;
                if ((toModify = (Client)DataGridClients.SelectedItem) != null)
                {
                    ClientManagement AddClientFrame = new ClientManagement(toModify);
                    try
                    {
                        if (AddClientFrame.ShowDialog().Value == true)
                        {
                            BindingClient[BindingClient.IndexOf(toModify)] = AddClientFrame.CurrentClient;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (GroupBoxCastings.Visibility == Visibility.Visible)
            {
                CastingOffer toModify = null;
                if ((toModify = (CastingOffer)DataGridCastings.SelectedItem) != null)
                {
                    OfferManagement OfferManagementFrame = new OfferManagement(toModify);
                    try
                    {
                        if (OfferManagementFrame.ShowDialog().Value == true)
                        {
                            BindingCastings[BindingCastings.IndexOf(toModify)] = OfferManagementFrame.CurrentOffer;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            else if (GroupBoxCollaborators.Visibility == Visibility.Visible)
            {
                Collaborator toModify = null;
                if ((toModify = (Collaborator)DataGridCollaborators.SelectedItem) != null)
                {
                    CollaboratorManagement CollaboratorManagementFrame = new CollaboratorManagement(toModify);
                    try
                    {
                        if (CollaboratorManagementFrame.ShowDialog().Value == true)
                        {
                            BindingCollaborator[BindingCollaborator.IndexOf(toModify)] = CollaboratorManagementFrame.CurrentCollaborator;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void Delete()
        {
            if (GroupBoxClients.Visibility == Visibility.Visible)
            {
                Client toDel = null;
                if ((toDel = (Client)DataGridClients.SelectedItem) != null)
                {
                    if (MessageBox.Show("Voulez-vous supprimer le client " + toDel.Name + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        using (ISession session = isessionfactory.OpenSession())
                        {
                            using (var transaction = session.BeginTransaction())
                            {
                                try
                                {
                                    string queryString = string.Format("delete {0} where id = :id", typeof(Client));
                                    session.CreateQuery(queryString)
                                           .SetParameter("id", toDel.Id)
                                           .ExecuteUpdate();
                                    transaction.Commit();
                                    BindingClient.RemoveAt(BindingClient.IndexOf(toDel));
                                    MessageBox.Show("Supprimé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                transaction.Dispose();
                            }
                            isessionfactory.Close();
                        }
                    }
                }
            }
            else if (GroupBoxCastings.Visibility == Visibility.Visible)
            {
                CastingOffer toDel = null;
                if ((toDel = (CastingOffer)DataGridCastings.SelectedItem) != null)
                {
                    if (MessageBox.Show("Voulez-vous supprimer l'offre " + toDel.Reference + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        using (ISession session = isessionfactory.OpenSession())
                        {
                            using (var transaction = session.BeginTransaction())
                            {
                                try
                                {
                                    string queryString = string.Format("delete {0} where id = :id", typeof(CastingOffer));
                                    session.CreateQuery(queryString)
                                           .SetParameter("id", toDel.Id)
                                           .ExecuteUpdate();
                                    transaction.Commit();
                                    BindingCastings.RemoveAt(BindingCastings.IndexOf(toDel));
                                    MessageBox.Show("Supprimé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                transaction.Dispose();
                            }
                            isessionfactory.Close();
                        }
                    }
                }

            }

            else if (GroupBoxCollaborators.Visibility == Visibility.Visible)
            {
                Collaborator toDel = null;
                if ((toDel = (Collaborator)DataGridCollaborators.SelectedItem) != null)
                {
                    if (MessageBox.Show("Voulez-vous supprimer le partenaire " + toDel.Name + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        using (ISession session = isessionfactory.OpenSession())
                        {
                            using (var transaction = session.BeginTransaction())
                            {
                                try
                                {
                                    string queryString = string.Format("delete {0} where id = :id", typeof(Collaborator));
                                    session.CreateQuery(queryString)
                                           .SetParameter("id", toDel.Id)
                                           .ExecuteUpdate();
                                    transaction.Commit();
                                    BindingCollaborator.RemoveAt(BindingCollaborator.IndexOf(toDel));
                                    MessageBox.Show("Supprimé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                transaction.Dispose();
                            }
                            isessionfactory.Close();
                        }
                    }
                }
            }
        }
        #endregion

        #region Database 
        /// <summary>
        /// Crée l'objet base de donnée et la construit si besoin (connexion string dans app.config)
        /// </summary>
        /// <param name="typeBDD">A FAIRE</param>
        /// <returns>Objet de base de données</returns>
        public static ISessionFactory CreateSessionFactory()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[System.Configuration.ConfigurationManager.AppSettings["currentConnectionString"]].ConnectionString;
            string typeBDD = System.Configuration.ConfigurationManager.AppSettings["DatabaseType"];
            FluentNHibernate.Cfg.Db.IPersistenceConfigurer BDD = null;
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

        #endregion

        private void btnRepresentatives_Click(object sender, RoutedEventArgs e)
        {
            Client client = (Client) DataGridClients.SelectedItem;
            RepresentativesWindow windows = new RepresentativesWindow(client);
            windows.ShowDialog();
        }
    }
}
